using Xunit;

namespace ColorCode.LegacyAcceptanceTests
{
    public class AsaxAcceptanceTests
    {
        static ILanguage GetGrammar()
        {
            return Languages.Asax;
        }

        public class Transform
        {
            [Fact]
            public void WillNotStyleKeyword()
            {
                string source = "get bool false";
                string expected = "<div style=\"color:Black;background-color:White;\"><pre>\r\nget bool false\r\n</pre></div>";

                string actual = new CodeColorizer().Colorize(source, GetGrammar());
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void WillStyleHeaderWithKeywords()
        {
            string source = @"<%@ Application Language=""C#"" CodeBehind=""Global.asax.cs"" Inherits=""Microsoft.Foundation.Web.Global"" %><script runat=""server"">bool public false</script>";
            string expected = "<div style=\"color:Black;background-color:White;\"><pre>\r\n<span style=\"background-color:Yellow;\">&lt;%</span><span style=\"color:Blue;\">@</span> <span style=\"color:#A31515;\">Application</span> <span style=\"color:Red;\">Language</span><span style=\"color:Blue;\">=</span><span style=\"color:Blue;\">&quot;C#&quot;</span> <span style=\"color:Red;\">CodeBehind</span><span style=\"color:Blue;\">=</span><span style=\"color:Blue;\">&quot;Global.asax.cs&quot;</span> <span style=\"color:Red;\">Inherits</span><span style=\"color:Blue;\">=</span><span style=\"color:Blue;\">&quot;Microsoft.Foundation.Web.Global&quot;</span> <span style=\"background-color:Yellow;\">%&gt;</span><span style=\"color:Blue;\">&lt;</span><span style=\"color:#A31515;\">script</span> <span style=\"color:Red;\">runat</span><span style=\"color:Blue;\">=</span><span style=\"color:Blue;\">&quot;server&quot;</span><span style=\"color:Blue;\">&gt;</span><span style=\"color:Blue;\">bool</span> <span style=\"color:Blue;\">public</span> <span style=\"color:Blue;\">false</span><span style=\"color:Blue;\">&lt;/</span><span style=\"color:#A31515;\">script</span><span style=\"color:Blue;\">&gt;</span>\r\n</pre></div>";

            string actual = new CodeColorizer().Colorize(source, GetGrammar());
            Assert.Equal(expected, actual);
        }
    }
}
