using Xunit;

namespace ColorCode.SqlAcceptanceTests
{
    public class SqlConfigurationFunctionsTests
    {
        public class Transform
        {
            [Fact]
            public void WillStyleTextsizeFunction()
            {
                string sourceText =
@"SELECT @@TEXTSIZE AS 'Regex Size'
SET TEXTSIZE 2048
SELECT @@TEXTSIZE AS 'Regex Size'";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">SELECT</span> @@TEXTSIZE <span style=""color:Blue;"">AS</span> <span style=""color:#A31515;"">'Regex Size'</span>
<span style=""color:Blue;"">SET</span> <span style=""color:Blue;"">TEXTSIZE</span> 2048
<span style=""color:Blue;"">SELECT</span> @@TEXTSIZE <span style=""color:Blue;"">AS</span> <span style=""color:#A31515;"">'Regex Size'</span>
</pre></div>";

                string actual = ColorCode.Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }
        }
    }
}