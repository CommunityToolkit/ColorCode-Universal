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

        [Fact]
        public void WillStyleClass()
        {
            string source =
                @"<%@ Application Language=""C#"" CodeBehind=""Global.asax.cs"" Inherits=""Microsoft.Foundation.Web.Global"" %>
<script runat=""server"">
using System.IO;
using System.Text;
using System.Web;
using CodePlex.Common;
using CodePlex.Presentation.Compression;
using CodePlex.Presentation.Css.Presenter;
using CodePlex.Presentation.Navigation;

namespace CodePlex.WebSite.Css
{
    /// <summary>
    /// StyleSheet.ashx parses and delivers css files submitted through the QueryString
    /// It replaces constants described by the css file in the form 
    /// 
    ///     /*{css:ConstantName}*/
    /// 
    /// with the correspondingly named AppSetting Key from the containing directory's .config file
    /// </summary>
    public class StyleSheet : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = ""text/css"";
            if (context.Request.QueryString[""i""] == null)
                return;

            string[] cssFiles;
            cssFiles = css.ToString().Split(',');
            for (int i = 0; i < cssFiles.Length; i++)
            {
                cssFiles[i] = Path.GetFileName(cssFiles[i].Trim());
                if (!Path.HasExtension(cssFiles[i]))
                    cssFiles[i] = Path.ChangeExtension(cssFiles[i], "".css"");
            }

            //Cache settings handled in AddHeaderItemsToRequestModule
            //bool alreadyCached;
            //CompressionUtility.SetCaching(context, cssFiles, out alreadyCached);
            //if (alreadyCached)
            //    return;
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}
</script>";
            string expected =
                "<div style=\"color:Black;background-color:White;\"><pre>\r\n<span style=\"background-color:Yellow;\">&lt;%</span><span style=\"color:Blue;\">@</span> <span style=\"color:#A31515;\">Application</span> <span style=\"color:Red;\">Language</span><span style=\"color:Blue;\">=</span><span style=\"color:Blue;\">&quot;C#&quot;</span> <span style=\"color:Red;\">CodeBehind</span><span style=\"color:Blue;\">=</span><span style=\"color:Blue;\">&quot;Global.asax.cs&quot;</span> <span style=\"color:Red;\">Inherits</span><span style=\"color:Blue;\">=</span><span style=\"color:Blue;\">&quot;Microsoft.Foundation.Web.Global&quot;</span> <span style=\"background-color:Yellow;\">%&gt;</span>\r\n<span style=\"color:Blue;\">&lt;</span><span style=\"color:#A31515;\">script</span> <span style=\"color:Red;\">runat</span><span style=\"color:Blue;\">=</span><span style=\"color:Blue;\">&quot;server&quot;</span><span style=\"color:Blue;\">&gt;</span>\r\n<span style=\"color:Blue;\">using</span> System.IO;\r\n<span style=\"color:Blue;\">using</span> System.Text;\r\n<span style=\"color:Blue;\">using</span> System.Web;\r\n<span style=\"color:Blue;\">using</span> CodePlex.Common;\r\n<span style=\"color:Blue;\">using</span> CodePlex.Presentation.Compression;\r\n<span style=\"color:Blue;\">using</span> CodePlex.Presentation.Css.Presenter;\r\n<span style=\"color:Blue;\">using</span> CodePlex.Presentation.Navigation;\r\n\r\n<span style=\"color:Blue;\">namespace</span> CodePlex.WebSite.Css\r\n{\r\n    <span style=\"color:Gray;\">///</span> <span style=\"color:Gray;\">&lt;summary&gt;</span><span style=\"color:Green;\">\r</span>\n    <span style=\"color:Gray;\">///</span><span style=\"color:Green;\"> StyleSheet.ashx parses and delivers css files submitted through the QueryString\r</span>\n    <span style=\"color:Gray;\">///</span><span style=\"color:Green;\"> It replaces constants described by the css file in the form \r</span>\n    <span style=\"color:Gray;\">///</span><span style=\"color:Green;\"> \r</span>\n    <span style=\"color:Gray;\">///</span><span style=\"color:Green;\">     /*{css:ConstantName}*/\r</span>\n    <span style=\"color:Gray;\">///</span><span style=\"color:Green;\"> \r</span>\n    <span style=\"color:Gray;\">///</span><span style=\"color:Green;\"> with the correspondingly named AppSetting Key from the containing directory's .config file\r</span>\n    <span style=\"color:Gray;\">///</span> <span style=\"color:Gray;\">&lt;/summary&gt;</span><span style=\"color:Green;\">\r</span>\n    <span style=\"color:Blue;\">public</span> <span style=\"color:Blue;\">class</span> StyleSheet : IHttpHandler\r\n    {\r\n        <span style=\"color:Blue;\">public</span> <span style=\"color:Blue;\">void</span> ProcessRequest(HttpContext context)\r\n        {\r\n            context.Response.ContentType = <span style=\"color:#A31515;\">&quot;text/css&quot;</span>;\r\n            <span style=\"color:Blue;\">if</span> (context.Request.QueryString[<span style=\"color:#A31515;\">&quot;i&quot;</span>] == <span style=\"color:Blue;\">null</span>)\r\n                <span style=\"color:Blue;\">return</span>;\r\n\r\n            <span style=\"color:Blue;\">string</span>[] cssFiles;\r\n            cssFiles = css.ToString().Split(<span style=\"color:#A31515;\">','</span>);\r\n            <span style=\"color:Blue;\">for</span> (<span style=\"color:Blue;\">int</span> i = 0; i &lt; cssFiles.Length; i++)\r\n            {\r\n                cssFiles[i] = Path.GetFileName(cssFiles[i].Trim());\r\n                <span style=\"color:Blue;\">if</span> (!Path.HasExtension(cssFiles[i]))\r\n                    cssFiles[i] = Path.ChangeExtension(cssFiles[i], <span style=\"color:#A31515;\">&quot;.css&quot;</span>);\r\n            }\r\n\r\n            <span style=\"color:Green;\">//Cache settings handled in AddHeaderItemsToRequestModule</span>\r\n            <span style=\"color:Green;\">//bool alreadyCached;</span>\r\n            <span style=\"color:Green;\">//CompressionUtility.SetCaching(context, cssFiles, out alreadyCached);</span>\r\n            <span style=\"color:Green;\">//if (alreadyCached)</span>\r\n            <span style=\"color:Green;\">//    return;</span>\r\n        }\r\n\r\n        <span style=\"color:Blue;\">public</span> <span style=\"color:Blue;\">bool</span> IsReusable\r\n        {\r\n            <span style=\"color:Blue;\">get</span> { <span style=\"color:Blue;\">return</span> <span style=\"color:Blue;\">false</span>; }\r\n        }\r\n    }\r\n}\r\n<span style=\"color:Blue;\">&lt;/</span><span style=\"color:#A31515;\">script</span><span style=\"color:Blue;\">&gt;</span>\r\n</pre></div>";
            string actual = new CodeColorizer().Colorize(source, GetGrammar());
            Assert.Equal(expected, actual);
        }

    }
}
