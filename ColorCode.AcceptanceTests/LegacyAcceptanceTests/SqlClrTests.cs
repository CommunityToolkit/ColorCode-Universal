using Xunit;

namespace ColorCode.SqlAcceptanceTests
{
    public class SqlClrTests
    {
        public class Transform
        {
            [Fact]
            public void WillStyleCreateAssembly()
            {
                string sourceText =
                    @"DECLARE @SamplesPath nvarchar(1024)
SELECT @SamplesPath = REPLACE(physical_name, 
    'Microsoft SQL Server\MSSQL.1\MSSQL\DATA\master.mdf', 
    'Microsoft SQL Server\90\Samples\Engine\Programmability\CLR\') 
FROM master.sys.database_files 
WHERE name = 'master';
CREATE ASSEMBLY HelloWorld 
FROM @SamplesPath + 'HelloWorld\CS\HelloWorld\bin\debug\HelloWorld.dll'
WITH PERMISSION_SET = SAFE;";
                string expected =
                    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">DECLARE</span> @SamplesPath <span style=""color:Blue;"">nvarchar</span>(1024)
<span style=""color:Blue;"">SELECT</span> @SamplesPath = <span style=""color:Blue;"">REPLACE</span>(physical_name, 
    <span style=""color:#A31515;"">'Microsoft SQL Server\MSSQL.1\MSSQL\DATA\master.mdf'</span>, 
    <span style=""color:#A31515;"">'Microsoft SQL Server\90\Samples\Engine\Programmability\CLR\'</span>) 
<span style=""color:Blue;"">FROM</span> master.sys.database_files 
<span style=""color:Blue;"">WHERE</span> <span style=""color:Blue;"">name</span> = <span style=""color:#A31515;"">'master'</span>;
<span style=""color:Blue;"">CREATE</span> <span style=""color:Blue;"">ASSEMBLY</span> HelloWorld 
<span style=""color:Blue;"">FROM</span> @SamplesPath + <span style=""color:#A31515;"">'HelloWorld\CS\HelloWorld\bin\debug\HelloWorld.dll'</span>
<span style=""color:Blue;"">WITH</span> PERMISSION_SET = SAFE;
</pre></div>";

                string actual = ColorCode.Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleAlterAssembly()
            {
                string sourceText =
                    @"ALTER ASSEMBLY MyClass 
ADD FILE FROM 'C:\MyClassProject\Class1.cs';";
                string expected =
                    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">ALTER</span> <span style=""color:Blue;"">ASSEMBLY</span> MyClass 
<span style=""color:Blue;"">ADD</span> <span style=""color:Blue;"">FILE</span> <span style=""color:Blue;"">FROM</span> <span style=""color:#A31515;"">'C:\MyClassProject\Class1.cs'</span>;
</pre></div>";

                string actual = ColorCode.Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleDropAssembly()
            {
                string sourceText =
                    @"DROP ASSEMBLY Helloworld";
                string expected =
                    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">DROP</span> <span style=""color:Blue;"">ASSEMBLY</span> Helloworld
</pre></div>";

                string actual = ColorCode.Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleCreateAggregate()
            {
                string sourceText =
                    @"USE AdventureWorks;
GO
DECLARE @SamplesPath nvarchar(1024)
-- You may have to modify the value of the this variable if you have
--installed the sample some location other than the default location.
SELECT @SamplesPath = REPLACE(physical_name, 'Microsoft SQL Server\MSSQL.1\MSSQL\DATA\master.mdf', 'Microsoft SQL Server\90\Samples\Engine\Programmability\CLR\') 
    FROM master.sys.database_files 
    WHERE name = 'master';
CREATE ASSEMBLY StringUtilities FROM @SamplesPath + 'StringUtilities\CS\StringUtilities\bin\debug\StringUtilities.dll'
WITH PERMISSION_SET=SAFE;
GO

CREATE AGGREGATE Concatenate(@input nvarchar(4000))
RETURNS nvarchar(4000)
EXTERNAL NAME [StringUtilities].[Microsoft.Samples.SqlServer.Concatenate];
GO";
                string expected =
                    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">DECLARE</span> @SamplesPath <span style=""color:Blue;"">nvarchar</span>(1024)
<span style=""color:Green;"">-- You may have to modify the value of the this variable if you have</span>
<span style=""color:Green;"">--installed the sample some location other than the default location.</span>
<span style=""color:Blue;"">SELECT</span> @SamplesPath = <span style=""color:Blue;"">REPLACE</span>(physical_name, <span style=""color:#A31515;"">'Microsoft SQL Server\MSSQL.1\MSSQL\DATA\master.mdf'</span>, <span style=""color:#A31515;"">'Microsoft SQL Server\90\Samples\Engine\Programmability\CLR\'</span>) 
    <span style=""color:Blue;"">FROM</span> master.sys.database_files 
    <span style=""color:Blue;"">WHERE</span> <span style=""color:Blue;"">name</span> = <span style=""color:#A31515;"">'master'</span>;
<span style=""color:Blue;"">CREATE</span> <span style=""color:Blue;"">ASSEMBLY</span> StringUtilities <span style=""color:Blue;"">FROM</span> @SamplesPath + <span style=""color:#A31515;"">'StringUtilities\CS\StringUtilities\bin\debug\StringUtilities.dll'</span>
<span style=""color:Blue;"">WITH</span> PERMISSION_SET=SAFE;
GO

<span style=""color:Blue;"">CREATE</span> <span style=""color:Blue;"">AGGREGATE</span> Concatenate(@input <span style=""color:Blue;"">nvarchar</span>(4000))
<span style=""color:Blue;"">RETURNS</span> <span style=""color:Blue;"">nvarchar</span>(4000)
<span style=""color:Blue;"">EXTERNAL</span> <span style=""color:Blue;"">NAME</span> [StringUtilities].[Microsoft.Samples.SqlServer.Concatenate];
GO
</pre></div>";

                string actual = ColorCode.Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleDropAggregate()
            {
                string sourceText = @"DROP AGGREGATE dbo.Concatenate";
                string expected =
                    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">DROP</span> <span style=""color:Blue;"">AGGREGATE</span> dbo.Concatenate
</pre></div>";

                string actual = ColorCode.Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleCreateType()
            {
                string sourceText = @"CREATE ASSEMBLY utf8string
FROM '\\ComputerName\utf8string\utf8string.dll' ;
GO
CREATE TYPE Utf8String 
EXTERNAL NAME utf8string.[Microsoft.Samples.SqlServer.utf8string] ;
GO";
                string expected =
                    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">CREATE</span> <span style=""color:Blue;"">ASSEMBLY</span> utf8string
<span style=""color:Blue;"">FROM</span> <span style=""color:#A31515;"">'\\ComputerName\utf8string\utf8string.dll'</span> ;
GO
<span style=""color:Blue;"">CREATE</span> TYPE Utf8String 
<span style=""color:Blue;"">EXTERNAL</span> <span style=""color:Blue;"">NAME</span> utf8string.[Microsoft.Samples.SqlServer.utf8string] ;
GO
</pre></div>";

                string actual = ColorCode.Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleDropType()
            {
                string sourceText = @"DROP TYPE ssn ;";
                string expected =
                    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">DROP</span> TYPE ssn ;
</pre></div>";

                string actual = ColorCode.Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }
        }
    }
}