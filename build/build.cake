#module nuget:?package=Cake.LongPath.Module&version=1.0.1

#addin nuget:?package=Cake.FileHelpers&version=4.0.1
#addin nuget:?package=Cake.Powershell&version=1.0.1
#addin nuget:?package=Cake.GitVersioning&version=3.4.244

#tool nuget:?package=vswhere&version=2.8.4

using System;
using System.Linq;
using System.Text.RegularExpressions;

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

var baseDir = MakeAbsolute(Directory("../")).ToString();
var buildDir = baseDir + "/build";

var Solution = baseDir + "/ColorCode.sln";
var nupkgDir = buildDir + "/nupkg";

string Version = null;

//////////////////////////////////////////////////////////////////////
// METHODS
//////////////////////////////////////////////////////////////////////

void VerifyHeaders(bool Replace)
{
    var header = FileReadText("header.txt") + "\r\n";
    bool hasMissing = false;

    Func<IFileSystemInfo, bool> exclude_objDir =
        fileSystemInfo => !fileSystemInfo.Path.Segments.Contains("obj");

    var files = GetFiles(baseDir + "/**/*.cs", new GlobberSettings { Predicate = exclude_objDir }).Where(file =>
    {
        var path = file.ToString();
        return !(path.EndsWith(".g.cs") || path.EndsWith(".i.cs") || System.IO.Path.GetFileName(path).Contains("TemporaryGeneratedFile"));
    });

    Information("\nChecking " + files.Count() + " file header(s)");
    foreach(var file in files)
    {
        var oldContent = FileReadText(file);
		if(oldContent.Contains("// <auto-generated>"))
		{
		   continue;
		}
        var rgx = new Regex("^(//.*\r?\n)*\r?\n");
        var newContent = header + rgx.Replace(oldContent, "");

        if(!newContent.Equals(oldContent, StringComparison.Ordinal))
        {
            if(Replace)
            {
                Information("\nUpdating " + file + " header...");
                FileWriteText(file, newContent);
            }
            else
            {
                Error("\nWrong/missing header on " + file);
                hasMissing = true;
            }
        }
    }

    if(!Replace && hasMissing)
    {
        throw new Exception("Please run UpdateHeaders.bat or '.\\build.ps1 -target=UpdateHeaders' and commit the changes.");
    }
}

void RetrieveVersion()
{
    Information("\nRetrieving version...");
    Version = GitVersioningGetVersion().NuGetPackageVersion;
    Information("\nBuild Version: " + Version);
}

void UpdateToolsPath(MSBuildSettings buildSettings)
{
    // Workaround for https://github.com/cake-build/cake/issues/2128
	var vsInstallation = VSWhereLatest(new VSWhereLatestSettings { Requires = "Microsoft.Component.MSBuild", IncludePrerelease = false });

	if (vsInstallation != null)
	{
		buildSettings.ToolPath = vsInstallation.CombineWithFilePath(@"MSBuild\Current\Bin\MSBuild.exe");
		if (!FileExists(buildSettings.ToolPath))
			buildSettings.ToolPath = vsInstallation.CombineWithFilePath(@"MSBuild\15.0\Bin\MSBuild.exe");
	}
}

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    Information("\nCleaning Package Directory");
    CleanDirectory(nupkgDir);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetCoreRestore(Solution);
});

Task("Verify")
    .Description("Run pre-build verifications")
    .IsDependentOn("Clean")
    .Does(() =>
{
    VerifyHeaders(false);

    StartPowershellFile("./Find-WindowsSDKVersions.ps1");
});

Task("Version")
    .Description("Updates the version information in all Projects")
    .IsDependentOn("Verify")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    RetrieveVersion();
});

Task("Build")
    .IsDependentOn("Version")
    .Does(() =>
{
    Information("\nBuilding Solution");
    var buildSettings = new MSBuildSettings
    {
        MaxCpuCount = 0
    }
    .SetConfiguration("Release")
    .WithTarget("Pack")
    .WithProperty("GenerateLibraryLayout", "true")
    .WithProperty("PackageOutputPath", nupkgDir);

    buildSettings.BinaryLogger = new MSBuildBinaryLogSettings();
    buildSettings.BinaryLogger.Enabled = true;
    buildSettings.BinaryLogger.FileName = baseDir + "/msbuild.binlog";

    UpdateToolsPath(buildSettings);

    EnsureDirectoryExists(nupkgDir);
    
    MSBuild(Solution, buildSettings);
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Build");

Task("UpdateHeaders")
    .Description("Updates the headers in *.cs files")
    .Does(() =>
{
    VerifyHeaders(true);
});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
