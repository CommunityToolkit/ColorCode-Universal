using Xunit;

namespace ColorCode.SqlAcceptanceTests
{
    public class SqlScenarioTests
    {
        public class Transform
        {
            [Fact]
            public void WillStyleSimpleSelectStatement()
            {
                string source =
    @"SELECT * FROM [TableName]";
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">SELECT</span> * <span style=""color:Blue;"">FROM</span> [TableName]
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleSelectStatementWithJoin()
            {
                string source =
    @"SELECT [ColumnOneName], [ColumnTwoName] FROM [TableName] a INNER JOIN [AnotherTableName] b ON a.[ColumnName] = b.[ColumnName]";
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">SELECT</span> [ColumnOneName], [ColumnTwoName] <span style=""color:Blue;"">FROM</span> [TableName] a <span style=""color:Blue;"">INNER</span> <span style=""color:Blue;"">JOIN</span> [AnotherTableName] b <span style=""color:Blue;"">ON</span> a.[ColumnName] = b.[ColumnName]
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleInsertStatement()
            {
                string source =
    @"INSERT INTO [TableName] ([ColumnOneName], [ColumnTwoName]) VALUES ('Planned', 0)";
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">INSERT</span> <span style=""color:Blue;"">INTO</span> [TableName] ([ColumnOneName], [ColumnTwoName]) <span style=""color:Blue;"">VALUES</span> (<span style=""color:#A31515;"">'Planned'</span>, 0)
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleUpdateStatement()
            {
                string source =
    @"UPDATE [TableName]
SET [ColumnOneName] = 'value' 
WHERE [ColumnTwoName] > '2008-5-13'";
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">UPDATE</span> [TableName]
<span style=""color:Blue;"">SET</span> [ColumnOneName] = <span style=""color:#A31515;"">'value'</span> 
<span style=""color:Blue;"">WHERE</span> [ColumnTwoName] &gt; <span style=""color:#A31515;"">'2008-5-13'</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleAlterTableStatement()
            {
                string source =
    @"ALTER TABLE [TableName]
ADD [NewColumnName] VARCHAR(20) NOT NULL CONSTRAINT [ConstraintName] DEFAULT('DefaultValue');";
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">ALTER</span> <span style=""color:Blue;"">TABLE</span> [TableName]
<span style=""color:Blue;"">ADD</span> [NewColumnName] <span style=""color:Blue;"">VARCHAR</span>(20) <span style=""color:Blue;"">NOT</span> <span style=""color:Blue;"">NULL</span> <span style=""color:Blue;"">CONSTRAINT</span> [ConstraintName] <span style=""color:Blue;"">DEFAULT</span>(<span style=""color:#A31515;"">'DefaultValue'</span>);
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleComment()
            {
                string source =
    @"-- This is a comment.";
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Green;"">-- This is a comment.</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleCommentFollowedByAnotherComment()
            {
                string source =
    @"-- This is a comment.
-- This is another comment.";
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Green;"">-- This is a comment.</span>
<span style=""color:Green;"">-- This is another comment.</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleCreateStatementWithIdentityColumn()
            {
                string source =
    @"CREATE TABLE [TableName]
(
    [ColumnOne] int IDENTITY(1,1),
    [ColumnTwo] varchar (20)
)";
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">CREATE</span> <span style=""color:Blue;"">TABLE</span> [TableName]
(
    [ColumnOne] <span style=""color:Blue;"">int</span> <span style=""color:Blue;"">IDENTITY</span>(1,1),
    [ColumnTwo] <span style=""color:Blue;"">varchar</span> (20)
)
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleSimpleCursorUseage()
            {
                string source =
    @"USE databaseName
GO

DECLARE @columnNameOne varchar(50)

DECLARE cursorName CURSOR FOR
SELECT columnNameOne FROM tableName
WHERE columnNameOne LIKE 'SomeText'
ORDER BY columnNameOne

OPEN cursorName

FETCH NEXT FROM cursorName
INTO @columnNameOne

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'Column StyleName One: ' + @columnOneName

    FETCH NEXT FROM cursorName
    INTO @columnNameOne
END

CLOSE cursorName
DEALLOCATE cursorName

GO";
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> databaseName
GO

<span style=""color:Blue;"">DECLARE</span> @columnNameOne <span style=""color:Blue;"">varchar</span>(50)

<span style=""color:Blue;"">DECLARE</span> cursorName <span style=""color:Blue;"">CURSOR</span> <span style=""color:Blue;"">FOR</span>
<span style=""color:Blue;"">SELECT</span> columnNameOne <span style=""color:Blue;"">FROM</span> tableName
<span style=""color:Blue;"">WHERE</span> columnNameOne <span style=""color:Blue;"">LIKE</span> <span style=""color:#A31515;"">'SomeText'</span>
<span style=""color:Blue;"">ORDER</span> <span style=""color:Blue;"">BY</span> columnNameOne

<span style=""color:Blue;"">OPEN</span> cursorName

<span style=""color:Blue;"">FETCH</span> <span style=""color:Blue;"">NEXT</span> <span style=""color:Blue;"">FROM</span> cursorName
<span style=""color:Blue;"">INTO</span> @columnNameOne

<span style=""color:Blue;"">WHILE</span> @@FETCH_STATUS = 0
<span style=""color:Blue;"">BEGIN</span>
    <span style=""color:Blue;"">PRINT</span> <span style=""color:#A31515;"">'Column StyleName One: '</span> + @columnOneName

    <span style=""color:Blue;"">FETCH</span> <span style=""color:Blue;"">NEXT</span> <span style=""color:Blue;"">FROM</span> cursorName
    <span style=""color:Blue;"">INTO</span> @columnNameOne
<span style=""color:Blue;"">END</span>

<span style=""color:Blue;"">CLOSE</span> cursorName
<span style=""color:Blue;"">DEALLOCATE</span> cursorName

GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleSimpleCreateProcedureStatement()
            {
                string source =
    @"CREATE PROCEDURE procedureName
AS
    SELECT columnName
    FROM tableName;
GO";
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">CREATE</span> <span style=""color:Blue;"">PROCEDURE</span> procedureName
<span style=""color:Blue;"">AS</span>
    <span style=""color:Blue;"">SELECT</span> columnName
    <span style=""color:Blue;"">FROM</span> tableName;
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleSimpleCreateProcStatement()
            {
                string source =
    @"CREATE PROC procedureName
AS
    SELECT columnName
    FROM tableName;
GO";
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">CREATE</span> <span style=""color:Blue;"">PROC</span> procedureName
<span style=""color:Blue;"">AS</span>
    <span style=""color:Blue;"">SELECT</span> columnName
    <span style=""color:Blue;"">FROM</span> tableName;
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillNotStyleKeywordInsideStraightBraces()
            {
                string source =
    @"[SELECT]";
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
[SELECT]
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillNotStyleKeywordsPrecededByAtSign()
            {
                string source =
    @"@size";
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
@size
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillNotStyleKeywordsPrecededByAtDot()
            {
                string source =
    @"aliasName.StyleName";
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
aliasName.StyleName
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillNotStyleKeywordInsideStraightBracesWithSpaceBeforeAndAfter()
            {
                string source =
    @"[ SELECT ]";
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
[ SELECT ]
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleMultiLineString()
            {
                string source =
    @"SET @doc ='
<ROOT>
<Customer CustomerID=""VINET"" ContactName=""Paul Henriot"">
    <Order CustomerID=""VINET"" EmployeeID=""5"" OrderDate=""1996-07-04T00:00:00"">
        <OrderDetail OrderID=""10248"" ProductID=""11"" Quantity=""12""/>
        <OrderDetail OrderID=""10248"" ProductID=""42"" Quantity=""10""/>
    </Order>
</Customer>
<Customer CustomerID=""LILAS"" ContactName=""Carlos Gonzlez"">
    <Order CustomerID=""LILAS"" EmployeeID=""3"" OrderDate=""1996-08-16T00:00:00"">
        <OrderDetail OrderID=""10283"" ProductID=""72"" Quantity=""3""/>
    </Order>
</Customer>
</ROOT>'";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">SET</span> @doc =<span style=""color:#A31515;"">'
&lt;ROOT&gt;
&lt;Customer CustomerID=&quot;VINET&quot; ContactName=&quot;Paul Henriot&quot;&gt;
    &lt;Order CustomerID=&quot;VINET&quot; EmployeeID=&quot;5&quot; OrderDate=&quot;1996-07-04T00:00:00&quot;&gt;
        &lt;OrderDetail OrderID=&quot;10248&quot; ProductID=&quot;11&quot; Quantity=&quot;12&quot;/&gt;
        &lt;OrderDetail OrderID=&quot;10248&quot; ProductID=&quot;42&quot; Quantity=&quot;10&quot;/&gt;
    &lt;/Order&gt;
&lt;/Customer&gt;
&lt;Customer CustomerID=&quot;LILAS&quot; ContactName=&quot;Carlos Gonzlez&quot;&gt;
    &lt;Order CustomerID=&quot;LILAS&quot; EmployeeID=&quot;3&quot; OrderDate=&quot;1996-08-16T00:00:00&quot;&gt;
        &lt;OrderDetail OrderID=&quot;10283&quot; ProductID=&quot;72&quot; Quantity=&quot;3&quot;/&gt;
    &lt;/Order&gt;
&lt;/Customer&gt;
&lt;/ROOT&gt;'</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleDoubleQuotedLineString()
            {
                string source =
    @"SELECT ""foo""";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">SELECT</span> <span style=""color:#A31515;"">&quot;foo&quot;</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.Sql);

                Assert.Equal(expected, actual);
            }
        }
    }
}