using Xunit;

namespace ColorCode
{
    public class CssAcceptanceTests
    {
        class Transform
        {
            [Fact]
            public void WillStyleASimpleScope()
            {
                string source =
    @"html { height: 100%; }";
                string expected =
    @"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#A31515;"">html</span> { <span style=""color:#FF0000;"">height</span>: <span style=""color:#0000FF;"">100%</span>; }
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.Css, StyleSheets.VisualStudio);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleAScopeWithMultipleSelectors()
            {
                string source =
    @"selector1, selector2 { style: value; }";
                string expected =
    @"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#A31515;"">selector1</span>, <span style=""color:#A31515;"">selector2</span> { <span style=""color:#FF0000;"">style</span>: <span style=""color:#0000FF;"">value</span>; }
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.Css, StyleSheets.VisualStudio);

                Assert.Equal(expected, actual);
            }

            /*
             * TESTS TO WRITE
             * will style selectors with no spaces
             * will style styles with no spaces
             * will style styles with space before and after colon
             * will style multiple styles
            */

            
        }
    }
}