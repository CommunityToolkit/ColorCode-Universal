using System;
using System.Diagnostics;
using System.IO;
using Xunit;

namespace ColorCode
{
    public class HtmlAcceptanceTests
    {        
        [Fact]
        public void TransformWillStyleASimpleElement()
        {
            string source =
@"<html>";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">html</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.Html);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStylAnElementWithAttributes()
        {
            string source =
@"<anElement anAttribute=""anAttributeValue"" />";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">anElement</span> <span style=""color:Red;"">anAttribute</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;anAttributeValue&quot;</span> <span style=""color:Blue;"">/&gt;</span>
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.Html);

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
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">head</span><span style=""color:Blue;"">&gt;</span>
    <span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">title</span><span style=""color:Blue;"">&gt;</span>The Web Site Title<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">title</span><span style=""color:Blue;"">&gt;</span>
<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">head</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.Html);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleSpanOnSameLine()
        {
            string source =
@"<span class=""className""></span>";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">span</span> <span style=""color:Red;"">class</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;className&quot;</span><span style=""color:Blue;"">&gt;</span><span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">span</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.Html);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleElementWithIdAttribute()
        {
            string source =
@"<table id=""bannerImageTable"" cellpadding=""0"" cellspacing=""0"">";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">table</span> <span style=""color:Red;"">id</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;bannerImageTable&quot;</span> <span style=""color:Red;"">cellpadding</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;0&quot;</span> <span style=""color:Red;"">cellspacing</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;0&quot;</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.Html);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleDivElement()
        {
            string source =
@"<div id=""anId"">";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">div</span> <span style=""color:Red;"">id</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;anId&quot;</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.Html);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleScriptElement()
        {
            string source =
@"<script type=""text/javascript"">var variableName = 'aString';</script>";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">script</span> <span style=""color:Red;"">type</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;text/javascript&quot;</span><span style=""color:Blue;"">&gt;</span><span style=""color:Blue;"">var</span> variableName = <span style=""color:#A31515;"">'aString'</span>;<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">script</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.Html);

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
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">div</span><span style=""color:Blue;"">&gt;</span>
    <span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">script</span> <span style=""color:Red;"">type</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;text/javascript&quot;</span><span style=""color:Blue;"">&gt;</span>
        <span style=""color:Blue;"">var</span> variableName = <span style=""color:#A31515;"">'foo'</span>;

        <span style=""color:Blue;"">function</span> functionName(arg1, arg2) {
            <span style=""color:Blue;"">return</span> variableName;
        }
    <span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">script</span><span style=""color:Blue;"">&gt;</span>
<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">div</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.Html);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleHtmlElementWithNamespace()
        {
            string source =
@"<TheNameSpace:TheElementName TheAttributeName=""theAttributeValue"" />";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">TheNameSpace</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">TheElementName</span> <span style=""color:Red;"">TheAttributeName</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;theAttributeValue&quot;</span> <span style=""color:Blue;"">/&gt;</span>
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.Html);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleDocTypeDeclaration()
        {
            string source =
@"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;!</span><span style=""color:#A31515;"">DOCTYPE</span> <span style=""color:Red;"">html</span> <span style=""color:Red;"">PUBLIC</span> <span style=""color:Blue;"">&quot;-//W3C//DTD XHTML 1.0 Transitional//EN&quot;</span> <span style=""color:Blue;"">&quot;http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd&quot;</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.Html);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleMetaElementWithHyphenatedAttributeName()
        {
            string source =
@"<meta http-equiv=""Content-Type"" content=""text/html; charset=us-ascii"">";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">meta</span> <span style=""color:Red;"">http-equiv</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;Content-Type&quot;</span> <span style=""color:Red;"">content</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;text/html; charset=us-ascii&quot;</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.Html);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleElementWithUnquotedAttributeValue()
        {
            string source =
@"<elementName attributeName=attributeValue />";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">elementName</span> <span style=""color:Red;"">attributeName</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">attributeValue</span> <span style=""color:Blue;"">/&gt;</span>
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.Html);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleAnAttributeThatHasSpaceBeforeAndAfterTheEqualSign()
        {
            string source =
@"<elementName attributeName = ""attributeValue"">someText</eElementName>";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">elementName</span> <span style=""color:Red;"">attributeName</span> <span style=""color:Blue;"">=</span> <span style=""color:Blue;"">&quot;attributeValue&quot;</span><span style=""color:Blue;"">&gt;</span>someText<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">eElementName</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.Html);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleLargeHtmlIn1SecondOrLess()
        {
            string source = File.ReadAllText(@"..\..\LegacyAcceptanceTests\large.html");
            
            Stopwatch sw = new Stopwatch();
            sw.Start();
            
            ColorCode.Colorize(source, Languages.Html);

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
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">elementName</span><span style=""color:Blue;"">&gt;</span><span style=""color:Red;"">&amp;gt;</span><span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">elementName</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.Html);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleAttributeWithUnderscore()
        {
            string source =
@"<elementName anAttribute_Name=""attributeValue"">&gt;</elementName>";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">elementName</span> <span style=""color:Red;"">anAttribute_Name</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;attributeValue&quot;</span><span style=""color:Blue;"">&gt;</span><span style=""color:Red;"">&amp;gt;</span><span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">elementName</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.Html);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleUnquotedAttributeValueFollowedByDoubleQuotedAttributeValueWithSpace()
        {
            string source =
@"<elementName attributeName1=attributeValue attributeName2=""attribute value 2"">";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">elementName</span> <span style=""color:Red;"">attributeName1</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">attributeValue</span> <span style=""color:Red;"">attributeName2</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;attribute value 2&quot;</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.Html);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleUnquotedAttributeValueFollowingDoubleQuotedAttributeValue()
        {
            string source =
@"<elementName attributeValue1=""attributeValue1"" attributeValue2=attributeValue2>";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">elementName</span> <span style=""color:Red;"">attributeValue1</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;attributeValue1&quot;</span> <span style=""color:Red;"">attributeValue2</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">attributeValue2</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.Html);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WillStyleDoctypeWithLineBreakInDoubleQuotedString()
        {
            string source =
@"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 
    1.1//EN"" ""http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd"">";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;!</span><span style=""color:#A31515;"">DOCTYPE</span> <span style=""color:Red;"">html</span> <span style=""color:Red;"">PUBLIC</span> <span style=""color:Blue;"">&quot;-//W3C//DTD XHTML 
    1.1//EN&quot;</span> <span style=""color:Blue;"">&quot;http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd&quot;</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.Html);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WillStyleNumericLetterCodes()
        {
            string source = 
@"&#8211;&#710;&OElig;";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Red;"">&amp;#8211;</span><span style=""color:Red;"">&amp;#710;</span><span style=""color:Red;"">&amp;OElig;</span>
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.Html);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WillStyleScriptTags()
        {
            const string source = 
@"<script src=""/script/common.js"" type=""text/javascript""></script>
<script src=""/script/progress.js"" type=""text/javascript""></script>";
            const string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">script</span> <span style=""color:Red;"">src</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;/script/common.js&quot;</span> <span style=""color:Red;"">type</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;text/javascript&quot;</span><span style=""color:Blue;"">&gt;</span><span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">script</span><span style=""color:Blue;"">&gt;</span>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">script</span> <span style=""color:Red;"">src</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;/script/progress.js&quot;</span> <span style=""color:Red;"">type</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;text/javascript&quot;</span><span style=""color:Blue;"">&gt;</span><span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">script</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.Html);

            Assert.Equal(expected, actual);
        }
    }
}