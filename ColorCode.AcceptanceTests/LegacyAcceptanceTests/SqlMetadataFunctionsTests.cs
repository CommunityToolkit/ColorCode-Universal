using Xunit;

namespace ColorCode.SqlAcceptanceTests
{
    public class SqlMetadataFunctionsTests
    {
        public class Transform
        {
            [Fact]
            public void WillStyleColLengthFunction()
            {
                string sourceText =
@"USE AdventureWorks;
GO
CREATE TABLE t1
    (c1 varchar(40),
    c2 nvarchar(40)
    );
GO
SELECT COL_LENGTH('t1','c1')AS 'VarChar',
    COL_LENGTH('t1','c2')AS 'NVarChar';
GO
DROP TABLE t1;";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">CREATE</span> <span style=""color:Blue;"">TABLE</span> t1
    (c1 <span style=""color:Blue;"">varchar</span>(40),
    c2 <span style=""color:Blue;"">nvarchar</span>(40)
    );
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">COL_LENGTH</span>(<span style=""color:#A31515;"">'t1'</span>,<span style=""color:#A31515;"">'c1'</span>)<span style=""color:Blue;"">AS</span> <span style=""color:#A31515;"">'VarChar'</span>,
    <span style=""color:Blue;"">COL_LENGTH</span>(<span style=""color:#A31515;"">'t1'</span>,<span style=""color:#A31515;"">'c2'</span>)<span style=""color:Blue;"">AS</span> <span style=""color:#A31515;"">'NVarChar'</span>;
GO
<span style=""color:Blue;"">DROP</span> <span style=""color:Blue;"">TABLE</span> t1;
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleColNameFunction()
            {
                string sourceText =
@"USE AdventureWorks;
GO
SET NOCOUNT OFF;
GO
SELECT COL_NAME(OBJECT_ID('HumanResources.Employee'), 1) AS 'Column StyleName';
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SET</span> <span style=""color:Blue;"">NOCOUNT</span> <span style=""color:Blue;"">OFF</span>;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">COL_NAME</span>(<span style=""color:Blue;"">OBJECT_ID</span>(<span style=""color:#A31515;"">'HumanResources.Employee'</span>), 1) <span style=""color:Blue;"">AS</span> <span style=""color:#A31515;"">'Column StyleName'</span>;
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleColumnPropertyFunction()
            {
                string sourceText =
@"USE AdventureWorks;
GO
SELECT COLUMNPROPERTY( OBJECT_ID('Person.Contact'),'LastName','PRECISION')AS 'Column Length';
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">COLUMNPROPERTY</span>( <span style=""color:Blue;"">OBJECT_ID</span>(<span style=""color:#A31515;"">'Person.Contact'</span>),<span style=""color:#A31515;"">'LastName'</span>,<span style=""color:#A31515;"">'PRECISION'</span>)<span style=""color:Blue;"">AS</span> <span style=""color:#A31515;"">'Column Length'</span>;
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleDatabasePropertyFunction()
            {
                string sourceText =
@"USE master;
GO
SELECT DATABASEPROPERTY('master', 'IsTruncLog');";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> master;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">DATABASEPROPERTY</span>(<span style=""color:#A31515;"">'master'</span>, <span style=""color:#A31515;"">'IsTruncLog'</span>);
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleDbIdFunction()
            {
                string sourceText =
@"SELECT DB_ID() AS [Database ID];
GO

SELECT DB_ID(N'AdventureWorks') AS [Database ID];
GO

DECLARE @db_id smallint;
DECLARE @object_id int;
SET @db_id = DB_ID(N'AdventureWorks');
SET @object_id = OBJECT_ID(N'AdventureWorks.Person.Address');
IF @db_id IS NULL 
    BEGIN;
        PRINT N'Invalid database';
    END;
ELSE IF @object_id IS NULL
    BEGIN;
        PRINT N'Invalid object';
    END;
ELSE
    BEGIN;
        SELECT * FROM sys.dm_db_index_operational_stats(@db_id, @object_id, NULL, NULL);
    END;
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">DB_ID</span>() <span style=""color:Blue;"">AS</span> [Database ID];
GO

<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">DB_ID</span>(N<span style=""color:#A31515;"">'AdventureWorks'</span>) <span style=""color:Blue;"">AS</span> [Database ID];
GO

<span style=""color:Blue;"">DECLARE</span> @db_id <span style=""color:Blue;"">smallint</span>;
<span style=""color:Blue;"">DECLARE</span> @object_id <span style=""color:Blue;"">int</span>;
<span style=""color:Blue;"">SET</span> @db_id = <span style=""color:Blue;"">DB_ID</span>(N<span style=""color:#A31515;"">'AdventureWorks'</span>);
<span style=""color:Blue;"">SET</span> @object_id = <span style=""color:Blue;"">OBJECT_ID</span>(N<span style=""color:#A31515;"">'AdventureWorks.Person.Address'</span>);
<span style=""color:Blue;"">IF</span> @db_id <span style=""color:Blue;"">IS</span> <span style=""color:Blue;"">NULL</span> 
    <span style=""color:Blue;"">BEGIN</span>;
        <span style=""color:Blue;"">PRINT</span> N<span style=""color:#A31515;"">'Invalid database'</span>;
    <span style=""color:Blue;"">END</span>;
<span style=""color:Blue;"">ELSE</span> <span style=""color:Blue;"">IF</span> @object_id <span style=""color:Blue;"">IS</span> <span style=""color:Blue;"">NULL</span>
    <span style=""color:Blue;"">BEGIN</span>;
        <span style=""color:Blue;"">PRINT</span> N<span style=""color:#A31515;"">'Invalid object'</span>;
    <span style=""color:Blue;"">END</span>;
<span style=""color:Blue;"">ELSE</span>
    <span style=""color:Blue;"">BEGIN</span>;
        <span style=""color:Blue;"">SELECT</span> * <span style=""color:Blue;"">FROM</span> sys.dm_db_index_operational_stats(@db_id, @object_id, <span style=""color:Blue;"">NULL</span>, <span style=""color:Blue;"">NULL</span>);
    <span style=""color:Blue;"">END</span>;
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleDbNameFunction()
            {
                string sourceText =
@"SELECT DB_NAME() AS [Current Database];
GO

USE master;
GO
SELECT DB_NAME(3)AS [Database StyleName];
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">DB_NAME</span>() <span style=""color:Blue;"">AS</span> [Current Database];
GO

<span style=""color:Blue;"">USE</span> master;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">DB_NAME</span>(3)<span style=""color:Blue;"">AS</span> [Database StyleName];
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleFileIdFunction()
            {
                string sourceText =
@"USE AdventureWorks;
GO
SELECT FILE_ID('AdventureWorks_Data')AS 'File ID';
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">FILE_ID</span>(<span style=""color:#A31515;"">'AdventureWorks_Data'</span>)<span style=""color:Blue;"">AS</span> <span style=""color:#A31515;"">'File ID'</span>;
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleFileNameFunction()
            {
                string sourceText =
@"USE AdventureWorks;
GO
SELECT FILE_NAME(1) AS 'File StyleName 1', FILE_NAME(2) AS 'File StyleName 2';
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">FILE_NAME</span>(1) <span style=""color:Blue;"">AS</span> <span style=""color:#A31515;"">'File StyleName 1'</span>, <span style=""color:Blue;"">FILE_NAME</span>(2) <span style=""color:Blue;"">AS</span> <span style=""color:#A31515;"">'File StyleName 2'</span>;
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleFilegroupIdFunction()
            {
                string sourceText =
@"USE AdventureWorks;
GO
SELECT FILEGROUP_ID('PRIMARY') AS [Filegroup ID];
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">FILEGROUP_ID</span>(<span style=""color:#A31515;"">'PRIMARY'</span>) <span style=""color:Blue;"">AS</span> [Filegroup ID];
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleFilegroupNameFunction()
            {
                string sourceText =
@"USE AdventureWorks;
GO
SELECT FILEGROUP_NAME(1) AS [Filegroup StyleName];
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">FILEGROUP_NAME</span>(1) <span style=""color:Blue;"">AS</span> [Filegroup StyleName];
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleFilegrouppropertyFunction()
            {
                string sourceText =
@"USE AdventureWorks;
GO
SELECT FILEGROUPPROPERTY('PRIMARY', 'IsDefault') AS 'DefaultStyleSheet Filegroup';
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">FILEGROUPPROPERTY</span>(<span style=""color:#A31515;"">'PRIMARY'</span>, <span style=""color:#A31515;"">'IsDefault'</span>) <span style=""color:Blue;"">AS</span> <span style=""color:#A31515;"">'DefaultStyleSheet Filegroup'</span>;
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleFilepropertyFunction()
            {
                string sourceText =
@"USE AdventureWorks;
GO
SELECT FILEPROPERTY('AdventureWorks_Data', 'IsPrimaryFile')AS [Primary File];
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">FILEPROPERTY</span>(<span style=""color:#A31515;"">'AdventureWorks_Data'</span>, <span style=""color:#A31515;"">'IsPrimaryFile'</span>)<span style=""color:Blue;"">AS</span> [Primary File];
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleFulltextcatalogpropertyFunction()
            {
                string sourceText =
@"USE AdventureWorks;
GO
SELECT fulltextcatalogproperty('Cat_Desc', 'ItemCount');
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">fulltextcatalogproperty</span>(<span style=""color:#A31515;"">'Cat_Desc'</span>, <span style=""color:#A31515;"">'ItemCount'</span>);
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleFulltextservicepropertyFunction()
            {
                string sourceText =
@"SELECT fulltextserviceproperty('IsFulltextInstalled')";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">fulltextserviceproperty</span>(<span style=""color:#A31515;"">'IsFulltextInstalled'</span>)
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleIndexColFunction()
            {
                string sourceText =
@"USE AdventureWorks;
GO
SELECT 
    INDEX_COL (N'AdventureWorks.Sales.SalesOrderDetail', 1,1) AS
        [CaptureIndex Column 1], 
    INDEX_COL (N'AdventureWorks.Sales.SalesOrderDetail', 1,2) AS
        [CaptureIndex Column 2]
;
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> 
    <span style=""color:Blue;"">INDEX_COL</span> (N<span style=""color:#A31515;"">'AdventureWorks.Sales.SalesOrderDetail'</span>, 1,1) <span style=""color:Blue;"">AS</span>
        [CaptureIndex Column 1], 
    <span style=""color:Blue;"">INDEX_COL</span> (N<span style=""color:#A31515;"">'AdventureWorks.Sales.SalesOrderDetail'</span>, 1,2) <span style=""color:Blue;"">AS</span>
        [CaptureIndex Column 2]
;
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleIndexkeyPropertyFunction()
            {
                string sourceText =
@"USE AdventureWorks;
GO
SELECT 
    INDEXKEY_PROPERTY(OBJECT_ID('Production.Location', 'U'),
        1,1,'ColumnId') AS [Column ID],
    INDEXKEY_PROPERTY(OBJECT_ID('Production.Location', 'U'),
        1,1,'IsDescending') AS [Asc or Desc order];";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> 
    <span style=""color:Blue;"">INDEXKEY_PROPERTY</span>(<span style=""color:Blue;"">OBJECT_ID</span>(<span style=""color:#A31515;"">'Production.Location'</span>, <span style=""color:#A31515;"">'U'</span>),
        1,1,<span style=""color:#A31515;"">'ColumnId'</span>) <span style=""color:Blue;"">AS</span> [Column ID],
    <span style=""color:Blue;"">INDEXKEY_PROPERTY</span>(<span style=""color:Blue;"">OBJECT_ID</span>(<span style=""color:#A31515;"">'Production.Location'</span>, <span style=""color:#A31515;"">'U'</span>),
        1,1,<span style=""color:#A31515;"">'IsDescending'</span>) <span style=""color:Blue;"">AS</span> [Asc or Desc order];
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleIndexpropertyFunction()
            {
                string sourceText =
@"USE AdventureWorks;
GO
SELECT 
    INDEXPROPERTY(OBJECT_ID('HumanResources.Employee'),
        'PK_Employee_EmployeeID','IsClustered')AS [Is Clustered],
    INDEXPROPERTY(OBJECT_ID('HumanResources.Employee'),
        'PK_Employee_EmployeeID','IndexDepth') AS [CaptureIndex Depth],
    INDEXPROPERTY(OBJECT_ID('HumanResources.Employee'),
        'PK_Employee_EmployeeID','IndexFillFactor') AS [Fill Factor];
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> 
    <span style=""color:Blue;"">INDEXPROPERTY</span>(<span style=""color:Blue;"">OBJECT_ID</span>(<span style=""color:#A31515;"">'HumanResources.Employee'</span>),
        <span style=""color:#A31515;"">'PK_Employee_EmployeeID'</span>,<span style=""color:#A31515;"">'IsClustered'</span>)<span style=""color:Blue;"">AS</span> [Is Clustered],
    <span style=""color:Blue;"">INDEXPROPERTY</span>(<span style=""color:Blue;"">OBJECT_ID</span>(<span style=""color:#A31515;"">'HumanResources.Employee'</span>),
        <span style=""color:#A31515;"">'PK_Employee_EmployeeID'</span>,<span style=""color:#A31515;"">'IndexDepth'</span>) <span style=""color:Blue;"">AS</span> [CaptureIndex Depth],
    <span style=""color:Blue;"">INDEXPROPERTY</span>(<span style=""color:Blue;"">OBJECT_ID</span>(<span style=""color:#A31515;"">'HumanResources.Employee'</span>),
        <span style=""color:#A31515;"">'PK_Employee_EmployeeID'</span>,<span style=""color:#A31515;"">'IndexFillFactor'</span>) <span style=""color:Blue;"">AS</span> [Fill Factor];
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleObjectIdFunction()
            {
                string sourceText =
@"USE master;
GO
SELECT OBJECT_ID(N'AdventureWorks.Production.WorkOrder') AS 'Object ID';
GO

USE AdventureWorks;
GO
IF OBJECT_ID (N'dbo.AWBuildVersion', N'U') IS NOT NULL
DROP TABLE dbo.AWBuildVersion;
GO

DECLARE @db_id smallint;
DECLARE @object_id int;
SET @db_id = DB_ID(N'AdventureWorks');
SET @object_id = OBJECT_ID(N'AdventureWorks.Person.Address');
IF @db_id IS NULL 
    BEGIN;
        PRINT N'Invalid database';
    END;
ELSE IF @object_id IS NULL
    BEGIN;
        PRINT N'Invalid object';
    END;
ELSE
    BEGIN;
        SELECT * FROM sys.dm_db_index_operational_stats(@db_id, @object_id, NULL, NULL);
    END;
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> master;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">OBJECT_ID</span>(N<span style=""color:#A31515;"">'AdventureWorks.Production.WorkOrder'</span>) <span style=""color:Blue;"">AS</span> <span style=""color:#A31515;"">'Object ID'</span>;
GO

<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">IF</span> <span style=""color:Blue;"">OBJECT_ID</span> (N<span style=""color:#A31515;"">'dbo.AWBuildVersion'</span>, N<span style=""color:#A31515;"">'U'</span>) <span style=""color:Blue;"">IS</span> <span style=""color:Blue;"">NOT</span> <span style=""color:Blue;"">NULL</span>
<span style=""color:Blue;"">DROP</span> <span style=""color:Blue;"">TABLE</span> dbo.AWBuildVersion;
GO

<span style=""color:Blue;"">DECLARE</span> @db_id <span style=""color:Blue;"">smallint</span>;
<span style=""color:Blue;"">DECLARE</span> @object_id <span style=""color:Blue;"">int</span>;
<span style=""color:Blue;"">SET</span> @db_id = <span style=""color:Blue;"">DB_ID</span>(N<span style=""color:#A31515;"">'AdventureWorks'</span>);
<span style=""color:Blue;"">SET</span> @object_id = <span style=""color:Blue;"">OBJECT_ID</span>(N<span style=""color:#A31515;"">'AdventureWorks.Person.Address'</span>);
<span style=""color:Blue;"">IF</span> @db_id <span style=""color:Blue;"">IS</span> <span style=""color:Blue;"">NULL</span> 
    <span style=""color:Blue;"">BEGIN</span>;
        <span style=""color:Blue;"">PRINT</span> N<span style=""color:#A31515;"">'Invalid database'</span>;
    <span style=""color:Blue;"">END</span>;
<span style=""color:Blue;"">ELSE</span> <span style=""color:Blue;"">IF</span> @object_id <span style=""color:Blue;"">IS</span> <span style=""color:Blue;"">NULL</span>
    <span style=""color:Blue;"">BEGIN</span>;
        <span style=""color:Blue;"">PRINT</span> N<span style=""color:#A31515;"">'Invalid object'</span>;
    <span style=""color:Blue;"">END</span>;
<span style=""color:Blue;"">ELSE</span>
    <span style=""color:Blue;"">BEGIN</span>;
        <span style=""color:Blue;"">SELECT</span> * <span style=""color:Blue;"">FROM</span> sys.dm_db_index_operational_stats(@db_id, @object_id, <span style=""color:Blue;"">NULL</span>, <span style=""color:Blue;"">NULL</span>);
    <span style=""color:Blue;"">END</span>;
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleObjectNameFunction()
            {
                string sourceText =
@"USE AdventureWorks;
GO
SELECT DISTINCT OBJECT_NAME(object_id)
FROM master.sys.objects;
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">DISTINCT</span> <span style=""color:Blue;"">OBJECT_NAME</span>(<span style=""color:Blue;"">object_id</span>)
<span style=""color:Blue;"">FROM</span> master.sys.objects;
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleObjectpropertyFunction()
            {
                string sourceText =
@"USE AdventureWorks;
GO
IF OBJECTPROPERTY (OBJECT_ID(N'Production.UnitMeasure'),'ISTABLE') = 1
    PRINT 'UnitMeasure is a table.'
ELSE IF OBJECTPROPERTY (OBJECT_ID(N'Production.UnitMeasure'),'ISTABLE') = 0
    PRINT 'UnitMeasure is not a table.'
ELSE IF OBJECTPROPERTY (OBJECT_ID(N'Production.UnitMeasure'),'ISTABLE') IS NULL
    PRINT 'ERROR: UnitMeasure is not a valid object.';
GO

USE AdventureWorks;
GO
SELECT OBJECTPROPERTY(OBJECT_ID('dbo.ufnGetProductDealerPrice'), 'IsDeterministic');
GO

USE AdventureWorks;
GO
SELECT name, object_id, type_desc
FROM sys.objects 
WHERE OBJECTPROPERTY(object_id, N'SchemaId') = SCHEMA_ID(N'Production')
ORDER BY type_desc, name;
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">IF</span> <span style=""color:Blue;"">OBJECTPROPERTY</span> (<span style=""color:Blue;"">OBJECT_ID</span>(N<span style=""color:#A31515;"">'Production.UnitMeasure'</span>),<span style=""color:#A31515;"">'ISTABLE'</span>) = 1
    <span style=""color:Blue;"">PRINT</span> <span style=""color:#A31515;"">'UnitMeasure is a table.'</span>
<span style=""color:Blue;"">ELSE</span> <span style=""color:Blue;"">IF</span> <span style=""color:Blue;"">OBJECTPROPERTY</span> (<span style=""color:Blue;"">OBJECT_ID</span>(N<span style=""color:#A31515;"">'Production.UnitMeasure'</span>),<span style=""color:#A31515;"">'ISTABLE'</span>) = 0
    <span style=""color:Blue;"">PRINT</span> <span style=""color:#A31515;"">'UnitMeasure is not a table.'</span>
<span style=""color:Blue;"">ELSE</span> <span style=""color:Blue;"">IF</span> <span style=""color:Blue;"">OBJECTPROPERTY</span> (<span style=""color:Blue;"">OBJECT_ID</span>(N<span style=""color:#A31515;"">'Production.UnitMeasure'</span>),<span style=""color:#A31515;"">'ISTABLE'</span>) <span style=""color:Blue;"">IS</span> <span style=""color:Blue;"">NULL</span>
    <span style=""color:Blue;"">PRINT</span> <span style=""color:#A31515;"">'ERROR: UnitMeasure is not a valid object.'</span>;
GO

<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">OBJECTPROPERTY</span>(<span style=""color:Blue;"">OBJECT_ID</span>(<span style=""color:#A31515;"">'dbo.ufnGetProductDealerPrice'</span>), <span style=""color:#A31515;"">'IsDeterministic'</span>);
GO

<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">name</span>, <span style=""color:Blue;"">object_id</span>, type_desc
<span style=""color:Blue;"">FROM</span> sys.objects 
<span style=""color:Blue;"">WHERE</span> <span style=""color:Blue;"">OBJECTPROPERTY</span>(<span style=""color:Blue;"">object_id</span>, N<span style=""color:#A31515;"">'SchemaId'</span>) = SCHEMA_ID(N<span style=""color:#A31515;"">'Production'</span>)
<span style=""color:Blue;"">ORDER</span> <span style=""color:Blue;"">BY</span> type_desc, <span style=""color:Blue;"">name</span>;
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleSqlVariantPropertyFunction()
            {
                string sourceText =
@"CREATE TABLE tableA(colA sql_variant, colB int)
INSERT INTO tableA values ( cast (46279.1 as decimal(8,2)), 1689)
SELECT SQL_VARIANT_PROPERTY(colA,'BaseType') AS 'Base Type',
       SQL_VARIANT_PROPERTY(colA,'Precision') AS 'Precision',
       SQL_VARIANT_PROPERTY(colA,'Scale') AS 'Scale'
FROM tableA
WHERE colB = 1689";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">CREATE</span> <span style=""color:Blue;"">TABLE</span> tableA(colA <span style=""color:Blue;"">sql_variant</span>, colB <span style=""color:Blue;"">int</span>)
<span style=""color:Blue;"">INSERT</span> <span style=""color:Blue;"">INTO</span> tableA <span style=""color:Blue;"">values</span> ( <span style=""color:Blue;"">cast</span> (46279.1 <span style=""color:Blue;"">as</span> <span style=""color:Blue;"">decimal</span>(8,2)), 1689)
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">SQL_VARIANT_PROPERTY</span>(colA,<span style=""color:#A31515;"">'BaseType'</span>) <span style=""color:Blue;"">AS</span> <span style=""color:#A31515;"">'Base Type'</span>,
       <span style=""color:Blue;"">SQL_VARIANT_PROPERTY</span>(colA,<span style=""color:#A31515;"">'Precision'</span>) <span style=""color:Blue;"">AS</span> <span style=""color:#A31515;"">'Precision'</span>,
       <span style=""color:Blue;"">SQL_VARIANT_PROPERTY</span>(colA,<span style=""color:#A31515;"">'Scale'</span>) <span style=""color:Blue;"">AS</span> <span style=""color:#A31515;"">'Scale'</span>
<span style=""color:Blue;"">FROM</span> tableA
<span style=""color:Blue;"">WHERE</span> colB = 1689
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleTypepropertyFunction()
            {
                string sourceText =
@"SELECT TYPEPROPERTY(SCHEMA_NAME(schema_id) + '.' + name, 'OwnerId') AS owner_id, name, system_type_id, user_type_id, schema_id
FROM sys.types;

SELECT TYPEPROPERTY( 'tinyint', 'PRECISION');";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">TYPEPROPERTY</span>(SCHEMA_NAME(schema_id) + <span style=""color:#A31515;"">'.'</span> + <span style=""color:Blue;"">name</span>, <span style=""color:#A31515;"">'OwnerId'</span>) <span style=""color:Blue;"">AS</span> owner_id, <span style=""color:Blue;"">name</span>, system_type_id, user_type_id, schema_id
<span style=""color:Blue;"">FROM</span> sys.types;

<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">TYPEPROPERTY</span>( <span style=""color:#A31515;"">'tinyint'</span>, <span style=""color:#A31515;"">'PRECISION'</span>);
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }
        }
    }
}