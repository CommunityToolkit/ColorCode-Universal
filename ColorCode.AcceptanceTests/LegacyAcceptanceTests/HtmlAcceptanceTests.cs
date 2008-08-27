using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Xunit;

namespace ColorCode
{
    public class HtmlAcceptanceTests
    {
        [Fact]
        public void FileExtensionsWillIncludeHtml()
        {
            ILanguage language = Languages.Html;

            Assert.Contains("html", language.FileExtensions);
        }

        [Fact]
        public void FileExtensionsWillIncludeHtm()
        {
            ILanguage language = Languages.Html;

            Assert.Contains("htm", language.FileExtensions);
        }
        
        [Fact]
        public void TransformWillStyleASimpleElement()
        {
            string source =
@"<html>";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">html</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Html, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStylAnElementWithAttributes()
        {
            string source =
@"<anElement anAttribute=""anAttributeValue"" />";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">anElement</span> <span style=""color:#FF0000;"">anAttribute</span>=<span style=""color:#0000FF;"">&quot;anAttributeValue&quot;</span> <span style=""color:#0000FF;"">/&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Html, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStylHeadAndTitleElements()
        {
            string source =
@"<head>
    <title>The Web Site Title</title>
</head>";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">head</span><span style=""color:#0000FF;"">&gt;</span>
    <span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">title</span><span style=""color:#0000FF;"">&gt;</span>The Web Site Title<span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">title</span><span style=""color:#0000FF;"">&gt;</span>
<span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">head</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Html, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleSpanOnSameLine()
        {
            string source =
@"<span class=""className""></span>";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">span</span> <span style=""color:#FF0000;"">class</span>=<span style=""color:#0000FF;"">&quot;className&quot;</span><span style=""color:#0000FF;"">&gt;</span><span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">span</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Html, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleElementWithIdAttribute()
        {
            string source =
@"<table id=""bannerImageTable"" cellpadding=""0"" cellspacing=""0"">";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">table</span> <span style=""color:#FF0000;"">id</span>=<span style=""color:#0000FF;"">&quot;bannerImageTable&quot;</span> <span style=""color:#FF0000;"">cellpadding</span>=<span style=""color:#0000FF;"">&quot;0&quot;</span> <span style=""color:#FF0000;"">cellspacing</span>=<span style=""color:#0000FF;"">&quot;0&quot;</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Html, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleDivElement()
        {
            string source =
@"<div id=""anId"">";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">div</span> <span style=""color:#FF0000;"">id</span>=<span style=""color:#0000FF;"">&quot;anId&quot;</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Html, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleScriptElement()
        {
            string source =
@"<script type=""text/javascript"">var variableName = 'aString';</script>";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">script</span> <span style=""color:#FF0000;"">type</span>=<span style=""color:#0000FF;"">&quot;text/javascript&quot;</span><span style=""color:#0000FF;"">&gt;</span><span style=""color:#0000FF;"">var</span> variableName = <span style=""color:#A31515;"">'aString'</span>;<span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">script</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Html, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleMultiLineScriptEmbeddedInDiv()
        {
            string source =
@"<div>
    <script type=""text/javascript"">
        var variableName = 'foo';

        function functionName(arg1, arg2) {
            return variableName;
        }
    </script>
</div>";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">div</span><span style=""color:#0000FF;"">&gt;</span>
    <span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">script</span> <span style=""color:#FF0000;"">type</span>=<span style=""color:#0000FF;"">&quot;text/javascript&quot;</span><span style=""color:#0000FF;"">&gt;</span>
        <span style=""color:#0000FF;"">var</span> variableName = <span style=""color:#A31515;"">'foo'</span>;

        <span style=""color:#0000FF;"">function</span> functionName(arg1, arg2) {
            <span style=""color:#0000FF;"">return</span> variableName;
        }
    <span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">script</span><span style=""color:#0000FF;"">&gt;</span>
<span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">div</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Html, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleHtmlElementWithNamespace()
        {
            string source =
@"<TheNameSpace:TheElementName TheAttributeName=""theAttributeValue"" />";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">TheNameSpace</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">TheElementName</span> <span style=""color:#FF0000;"">TheAttributeName</span>=<span style=""color:#0000FF;"">&quot;theAttributeValue&quot;</span> <span style=""color:#0000FF;"">/&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Html, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleDocTypeDeclaration()
        {
            string source =
@"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;!</span><span style=""color:#A31515;"">DOCTYPE</span> <span style=""color:#FF0000;"">html</span> <span style=""color:#FF0000;"">PUBLIC</span> <span style=""color:#0000FF;"">&quot;-//W3C//DTD XHTML 1.0 Transitional//EN&quot;</span> <span style=""color:#0000FF;"">&quot;http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd&quot;</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Html, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleMetaElementWithHyphenatedAttributeName()
        {
            string source =
@"<meta http-equiv=""Content-Type"" content=""text/html; charset=us-ascii"">";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">meta</span> <span style=""color:#FF0000;"">http-equiv</span>=<span style=""color:#0000FF;"">&quot;Content-Type&quot;</span> <span style=""color:#FF0000;"">content</span>=<span style=""color:#0000FF;"">&quot;text/html; charset=us-ascii&quot;</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Html, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleElementWithUnquotedAttributeValue()
        {
            string source =
@"<elementName attributeName=attributeValue />";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">elementName</span> <span style=""color:#FF0000;"">attributeName</span>=<span style=""color:#0000FF;"">attributeValue</span> <span style=""color:#0000FF;"">/&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Html, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleAnAttributeThatHasSpaceBeforeAndAfterTheEqualSign()
        {
            string source =
@"<elementName attributeName = ""attributeValue"">someText</eElementName>";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">elementName</span> <span style=""color:#FF0000;"">attributeName</span> = <span style=""color:#0000FF;"">&quot;attributeValue&quot;</span><span style=""color:#0000FF;"">&gt;</span>someText<span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">eElementName</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Html, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleLargeHtmlIn1SecondOrLess()
        {
            string source = File.ReadAllText(@".\Data\large.html");
            
            Stopwatch sw = new Stopwatch();
            sw.Start();
            
            new CodeColorizer().Colorize(source, Languages.Html, StyleSheets.VisualStudio);

            sw.Stop();
            TimeSpan elapsed = sw.Elapsed;

            Assert.True(elapsed.Seconds <= 1);
        }

        [Fact]
        public void TransformWillStyleEntities()
        {
            string source =
@"<elementName>&gt;</elementName>";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">elementName</span><span style=""color:#0000FF;"">&gt;</span><span style=""color:#FF0000;"">&amp;gt;</span><span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">elementName</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Html, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleAttributeWithUnderscore()
        {
            string source =
@"<elementName anAttribute_Name=""attributeValue"">&gt;</elementName>";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">elementName</span> <span style=""color:#FF0000;"">anAttribute_Name</span>=<span style=""color:#0000FF;"">&quot;attributeValue&quot;</span><span style=""color:#0000FF;"">&gt;</span><span style=""color:#FF0000;"">&amp;gt;</span><span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">elementName</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Html, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleUnquotedAttributeValueFollowedByDoubleQuotedAttributeValueWithSpace()
        {
            string source =
@"<elementName attributeName1=attributeValue attributeName2=""attribute value 2"">";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">elementName</span> <span style=""color:#FF0000;"">attributeName1</span>=<span style=""color:#0000FF;"">attributeValue</span> <span style=""color:#FF0000;"">attributeName2</span>=<span style=""color:#0000FF;"">&quot;attribute value 2&quot;</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Html, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleUnquotedAttributeValueFollowingDoubleQuotedAttributeValue()
        {
            string source =
@"<elementName attributeValue1=""attributeValue1"" attributeValue2=attributeValue2>";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">elementName</span> <span style=""color:#FF0000;"">attributeValue1</span>=<span style=""color:#0000FF;"">&quot;attributeValue1&quot;</span> <span style=""color:#FF0000;"">attributeValue2</span>=<span style=""color:#0000FF;"">attributeValue2</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Html, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WillStyleDoctypeWithLineBreakInDoubleQuotedString()
        {
            string source =
@"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 
    1.1//EN"" ""http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd"">";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;!</span><span style=""color:#A31515;"">DOCTYPE</span> <span style=""color:#FF0000;"">html</span> <span style=""color:#FF0000;"">PUBLIC</span> <span style=""color:#0000FF;"">&quot;-//W3C//DTD XHTML 
    1.1//EN&quot;</span> <span style=""color:#0000FF;"">&quot;http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd&quot;</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Html, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WillStyleNumericLetterCodes()
        {
            string source = 
@"&#8211;&#710;&OElig;";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#FF0000;"">&amp;#8211;</span><span style=""color:#FF0000;"">&amp;#710;</span><span style=""color:#FF0000;"">&amp;OElig;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Html, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WillStyleScriptTags()
        {
            const string source = 
@"<script src=""/script/common.js"" type=""text/javascript""></script>
<script src=""/script/progress.js"" type=""text/javascript""></script>";
            const string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">script</span> <span style=""color:#FF0000;"">src</span>=<span style=""color:#0000FF;"">&quot;/script/common.js&quot;</span> <span style=""color:#FF0000;"">type</span>=<span style=""color:#0000FF;"">&quot;text/javascript&quot;</span><span style=""color:#0000FF;"">&gt;</span><span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">script</span><span style=""color:#0000FF;"">&gt;</span>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">script</span> <span style=""color:#FF0000;"">src</span>=<span style=""color:#0000FF;"">&quot;/script/progress.js&quot;</span> <span style=""color:#FF0000;"">type</span>=<span style=""color:#0000FF;"">&quot;text/javascript&quot;</span><span style=""color:#0000FF;"">&gt;</span><span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">script</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Html, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }
    }
}