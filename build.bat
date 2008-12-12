@echo off


if %COMPUTERNAME%==CODEPLEX-BUILD set ArchivePath=D:\Builds\Zips\ColorCode

if "%1" == "" goto :WithoutTarget

:WithTarget
%windir%\Microsoft.NET\Framework\v3.5\MSBuild.exe ColorCode.msbuild /p:Configuration=Debug /logger:Kobush.Build.Logging.XmlLogger,"3rdParty\Kobush.Build.dll";BuildResults.xml /t:%*
goto :End

:WithoutTarget
%windir%\Microsoft.NET\Framework\v3.5\MSBuild.exe ColorCode.msbuild /p:Configuration=Debug /logger:Kobush.Build.Logging.XmlLogger,"3rdParty\Kobush.Build.dll";BuildResults.xml

:End