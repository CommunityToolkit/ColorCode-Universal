using Xunit;

namespace ColorCode.SqlAcceptanceTests
{
    public class SqlMatchFunctionsTests
    {
        public class Transform
        {
            [Fact]
            public void WillStyleAbsFunction()
            {
                string sourceText =
@"SELECT ABS(-1.0), ABS(0.0), ABS(1.0)";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">ABS</span>(-1.0), <span style=""color:Blue;"">ABS</span>(0.0), <span style=""color:Blue;"">ABS</span>(1.0)
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleAcosFunction()
            {
                string sourceText =
@"SET NOCOUNT OFF;
DECLARE @angle float;
SET @angle = -1.0;
SELECT 'The ACOS of the angle is: ' + CONVERT(varchar, ACOS(@angle));";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">SET</span> <span style=""color:Blue;"">NOCOUNT</span> <span style=""color:Blue;"">OFF</span>;
<span style=""color:Blue;"">DECLARE</span> @angle <span style=""color:Blue;"">float</span>;
<span style=""color:Blue;"">SET</span> @angle = -1.0;
<span style=""color:Blue;"">SELECT</span> <span style=""color:#A31515;"">'The ACOS of the angle is: '</span> + <span style=""color:Blue;"">CONVERT</span>(<span style=""color:Blue;"">varchar</span>, <span style=""color:Blue;"">ACOS</span>(@angle));
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleAsinFunction()
            {
                string sourceText =
@"/* The first value will be -1.01. This fails because the value is 
outside the range.*/
DECLARE @angle float
SET @angle = -1.01
SELECT 'The ASIN of the angle is: ' + CONVERT(varchar, ASIN(@angle))
GO

-- The next value is -1.00.
DECLARE @angle float
SET @angle = -1.00
SELECT 'The ASIN of the angle is: ' + CONVERT(varchar, ASIN(@angle))
GO

-- The next value is 0.1472738.
DECLARE @angle float
SET @angle = 0.1472738
SELECT 'The ASIN of the angle is: ' + CONVERT(varchar, ASIN(@angle))
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Green;"">/* The first value will be -1.01. This fails because the value is 
outside the range.*/</span>
<span style=""color:Blue;"">DECLARE</span> @angle <span style=""color:Blue;"">float</span>
<span style=""color:Blue;"">SET</span> @angle = -1.01
<span style=""color:Blue;"">SELECT</span> <span style=""color:#A31515;"">'The ASIN of the angle is: '</span> + <span style=""color:Blue;"">CONVERT</span>(<span style=""color:Blue;"">varchar</span>, <span style=""color:Blue;"">ASIN</span>(@angle))
GO

<span style=""color:Green;"">-- The next value is -1.00.</span>
<span style=""color:Blue;"">DECLARE</span> @angle <span style=""color:Blue;"">float</span>
<span style=""color:Blue;"">SET</span> @angle = -1.00
<span style=""color:Blue;"">SELECT</span> <span style=""color:#A31515;"">'The ASIN of the angle is: '</span> + <span style=""color:Blue;"">CONVERT</span>(<span style=""color:Blue;"">varchar</span>, <span style=""color:Blue;"">ASIN</span>(@angle))
GO

<span style=""color:Green;"">-- The next value is 0.1472738.</span>
<span style=""color:Blue;"">DECLARE</span> @angle <span style=""color:Blue;"">float</span>
<span style=""color:Blue;"">SET</span> @angle = 0.1472738
<span style=""color:Blue;"">SELECT</span> <span style=""color:#A31515;"">'The ASIN of the angle is: '</span> + <span style=""color:Blue;"">CONVERT</span>(<span style=""color:Blue;"">varchar</span>, <span style=""color:Blue;"">ASIN</span>(@angle))
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleAtanFunction()
            {
                string sourceText =
@"SELECT 'The ATAN of -45.01 is: ' + CONVERT(varchar, ATAN(-45.01))
SELECT 'The ATAN of -181.01 is: ' + CONVERT(varchar, ATAN(-181.01))
SELECT 'The ATAN of 0 is: ' + CONVERT(varchar, ATAN(0))
SELECT 'The ATAN of 0.1472738 is: ' + CONVERT(varchar, ATAN(0.1472738))
SELECT 'The ATAN of 197.1099392 is: ' + CONVERT(varchar, ATAN(197.1099392))
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">SELECT</span> <span style=""color:#A31515;"">'The ATAN of -45.01 is: '</span> + <span style=""color:Blue;"">CONVERT</span>(<span style=""color:Blue;"">varchar</span>, <span style=""color:Blue;"">ATAN</span>(-45.01))
<span style=""color:Blue;"">SELECT</span> <span style=""color:#A31515;"">'The ATAN of -181.01 is: '</span> + <span style=""color:Blue;"">CONVERT</span>(<span style=""color:Blue;"">varchar</span>, <span style=""color:Blue;"">ATAN</span>(-181.01))
<span style=""color:Blue;"">SELECT</span> <span style=""color:#A31515;"">'The ATAN of 0 is: '</span> + <span style=""color:Blue;"">CONVERT</span>(<span style=""color:Blue;"">varchar</span>, <span style=""color:Blue;"">ATAN</span>(0))
<span style=""color:Blue;"">SELECT</span> <span style=""color:#A31515;"">'The ATAN of 0.1472738 is: '</span> + <span style=""color:Blue;"">CONVERT</span>(<span style=""color:Blue;"">varchar</span>, <span style=""color:Blue;"">ATAN</span>(0.1472738))
<span style=""color:Blue;"">SELECT</span> <span style=""color:#A31515;"">'The ATAN of 197.1099392 is: '</span> + <span style=""color:Blue;"">CONVERT</span>(<span style=""color:Blue;"">varchar</span>, <span style=""color:Blue;"">ATAN</span>(197.1099392))
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleAtn2Function()
            {
                string sourceText =
@"DECLARE @x float
DECLARE @y float
SET @x = 35.175643
SET @y = 129.44
SELECT 'The ATN2 of the angle is: ' + CONVERT(varchar,ATN2(@x,@y ))
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">DECLARE</span> @x <span style=""color:Blue;"">float</span>
<span style=""color:Blue;"">DECLARE</span> @y <span style=""color:Blue;"">float</span>
<span style=""color:Blue;"">SET</span> @x = 35.175643
<span style=""color:Blue;"">SET</span> @y = 129.44
<span style=""color:Blue;"">SELECT</span> <span style=""color:#A31515;"">'The ATN2 of the angle is: '</span> + <span style=""color:Blue;"">CONVERT</span>(<span style=""color:Blue;"">varchar</span>,<span style=""color:Blue;"">ATN2</span>(@x,@y ))
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleCeilingFunction()
            {
                string sourceText =
@"SELECT CEILING($123.45), CEILING($-123.45), CEILING($0.0)
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">CEILING</span>($123.45), <span style=""color:Blue;"">CEILING</span>($-123.45), <span style=""color:Blue;"">CEILING</span>($0.0)
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleCosFunction()
            {
                string sourceText =
@"DECLARE @angle float
SET @angle = 14.78
SELECT 'The COS of the angle is: ' + CONVERT(varchar,COS(@angle))
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">DECLARE</span> @angle <span style=""color:Blue;"">float</span>
<span style=""color:Blue;"">SET</span> @angle = 14.78
<span style=""color:Blue;"">SELECT</span> <span style=""color:#A31515;"">'The COS of the angle is: '</span> + <span style=""color:Blue;"">CONVERT</span>(<span style=""color:Blue;"">varchar</span>,<span style=""color:Blue;"">COS</span>(@angle))
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleCotFunction()
            {
                string sourceText =
@"DECLARE @angle float
SET @angle = 124.1332
SELECT 'The COT of the angle is: ' + CONVERT(varchar,COT(@angle))
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">DECLARE</span> @angle <span style=""color:Blue;"">float</span>
<span style=""color:Blue;"">SET</span> @angle = 124.1332
<span style=""color:Blue;"">SELECT</span> <span style=""color:#A31515;"">'The COT of the angle is: '</span> + <span style=""color:Blue;"">CONVERT</span>(<span style=""color:Blue;"">varchar</span>,<span style=""color:Blue;"">COT</span>(@angle))
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleDegreesFunction()
            {
                string sourceText =
@"SELECT 'The number of degrees in PI/2 radians is: ' + 
CONVERT(varchar, DEGREES((PI()/2)));
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">SELECT</span> <span style=""color:#A31515;"">'The number of degrees in PI/2 radians is: '</span> + 
<span style=""color:Blue;"">CONVERT</span>(<span style=""color:Blue;"">varchar</span>, <span style=""color:Blue;"">DEGREES</span>((<span style=""color:Blue;"">PI</span>()/2)));
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleExpFunction()
            {
                string sourceText =
@"DECLARE @var float
SET @var = 10
SELECT 'The EXP of the variable is: ' + CONVERT(varchar,EXP(@var))
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">DECLARE</span> @var <span style=""color:Blue;"">float</span>
<span style=""color:Blue;"">SET</span> @var = 10
<span style=""color:Blue;"">SELECT</span> <span style=""color:#A31515;"">'The EXP of the variable is: '</span> + <span style=""color:Blue;"">CONVERT</span>(<span style=""color:Blue;"">varchar</span>,<span style=""color:Blue;"">EXP</span>(@var))
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleFloorFunction()
            {
                string sourceText =
@"SELECT FLOOR(123.45), FLOOR(-123.45), FLOOR($123.45)";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">FLOOR</span>(123.45), <span style=""color:Blue;"">FLOOR</span>(-123.45), <span style=""color:Blue;"">FLOOR</span>($123.45)
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleLogFunction()
            {
                string sourceText =
@"DECLARE @var float
SET @var = 10
SELECT 'The LOG of the variable is: ' + CONVERT(varchar, LOG(@var))
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">DECLARE</span> @var <span style=""color:Blue;"">float</span>
<span style=""color:Blue;"">SET</span> @var = 10
<span style=""color:Blue;"">SELECT</span> <span style=""color:#A31515;"">'The LOG of the variable is: '</span> + <span style=""color:Blue;"">CONVERT</span>(<span style=""color:Blue;"">varchar</span>, <span style=""color:Blue;"">LOG</span>(@var))
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleLog10Function()
            {
                string sourceText =
@"DECLARE @var float
SET @var = 145.175643
SELECT 'The LOG10 of the variable is: ' + CONVERT(varchar,LOG10(@var))
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">DECLARE</span> @var <span style=""color:Blue;"">float</span>
<span style=""color:Blue;"">SET</span> @var = 145.175643
<span style=""color:Blue;"">SELECT</span> <span style=""color:#A31515;"">'The LOG10 of the variable is: '</span> + <span style=""color:Blue;"">CONVERT</span>(<span style=""color:Blue;"">varchar</span>,<span style=""color:Blue;"">LOG10</span>(@var))
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStylePiFunction()
            {
                string sourceText =
@"SELECT PI()
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">PI</span>()
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStylePowerFunction()
            {
                string sourceText =
@"SELECT POWER(2.0, -100.0)
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">POWER</span>(2.0, -100.0)
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleRadiansFunction()
            {
                string sourceText =
@"SELECT RADIANS(1e-307)
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">RADIANS</span>(1e-307)
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleRandFunction()
            {
                string sourceText =
@"DECLARE @counter smallint
SET @counter = 1
WHILE @counter < 5
    BEGIN
        SELECT RAND() Random_Number
        SET @counter = @counter + 1
    END
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">DECLARE</span> @counter <span style=""color:Blue;"">smallint</span>
<span style=""color:Blue;"">SET</span> @counter = 1
<span style=""color:Blue;"">WHILE</span> @counter &lt; 5
    <span style=""color:Blue;"">BEGIN</span>
        <span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">RAND</span>() Random_Number
        <span style=""color:Blue;"">SET</span> @counter = @counter + 1
    <span style=""color:Blue;"">END</span>
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleRoundFunction()
            {
                string sourceText =
@"SELECT ROUND(123.9994, 3), ROUND(123.9995, 3)
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">ROUND</span>(123.9994, 3), <span style=""color:Blue;"">ROUND</span>(123.9995, 3)
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleSignFunction()
            {
                string sourceText =
@"DECLARE @value real
SET @value = -1
WHILE @value < 2
    BEGIN
        SELECT SIGN(@value)
        SET NOCOUNT ON
        SELECT @value = @value + 1
        SET NOCOUNT OFF
    END
SET NOCOUNT OFF
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">DECLARE</span> @value <span style=""color:Blue;"">real</span>
<span style=""color:Blue;"">SET</span> @value = -1
<span style=""color:Blue;"">WHILE</span> @value &lt; 2
    <span style=""color:Blue;"">BEGIN</span>
        <span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">SIGN</span>(@value)
        <span style=""color:Blue;"">SET</span> <span style=""color:Blue;"">NOCOUNT</span> <span style=""color:Blue;"">ON</span>
        <span style=""color:Blue;"">SELECT</span> @value = @value + 1
        <span style=""color:Blue;"">SET</span> <span style=""color:Blue;"">NOCOUNT</span> <span style=""color:Blue;"">OFF</span>
    <span style=""color:Blue;"">END</span>
<span style=""color:Blue;"">SET</span> <span style=""color:Blue;"">NOCOUNT</span> <span style=""color:Blue;"">OFF</span>
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleSinFunction()
            {
                string sourceText =
@"DECLARE @angle float
SET @angle = 45.175643
SELECT 'The SIN of the angle is: ' + CONVERT(varchar,SIN(@angle))
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">DECLARE</span> @angle <span style=""color:Blue;"">float</span>
<span style=""color:Blue;"">SET</span> @angle = 45.175643
<span style=""color:Blue;"">SELECT</span> <span style=""color:#A31515;"">'The SIN of the angle is: '</span> + <span style=""color:Blue;"">CONVERT</span>(<span style=""color:Blue;"">varchar</span>,<span style=""color:Blue;"">SIN</span>(@angle))
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleSqrtFunction()
            {
                string sourceText =
@"DECLARE @myvalue float;
SET @myvalue = 1.00;
WHILE @myvalue < 10.00
    BEGIN
        SELECT SQRT(@myvalue);
        SET @myvalue = @myvalue + 1
    END;
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">DECLARE</span> @myvalue <span style=""color:Blue;"">float</span>;
<span style=""color:Blue;"">SET</span> @myvalue = 1.00;
<span style=""color:Blue;"">WHILE</span> @myvalue &lt; 10.00
    <span style=""color:Blue;"">BEGIN</span>
        <span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">SQRT</span>(@myvalue);
        <span style=""color:Blue;"">SET</span> @myvalue = @myvalue + 1
    <span style=""color:Blue;"">END</span>;
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleSquareFunction()
            {
                string sourceText =
@"SELECT TAN(PI()/2);";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">TAN</span>(<span style=""color:Blue;"">PI</span>()/2);
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }
        }
    }
}
