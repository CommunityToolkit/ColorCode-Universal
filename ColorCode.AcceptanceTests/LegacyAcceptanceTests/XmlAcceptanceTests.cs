using Xunit;

namespace ColorCode
{
    public class XmlAcceptanceTests
    {
        [Fact]
        public void TransformWillStyleASimpleElement()
        {
            string source =
@"<fnord>";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">fnord</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleElementAttributes()
        {
            string source =
@"<elementName attributeName=""attributeValue"">";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">elementName</span> <span style=""color:Red;"">attributeName</span><span style=""color:Blue;"">=</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">attributeValue</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleXmlPreProcessor()
        {
            string source =
@"<?xml version=""1.0"" encoding=""UTF-8""?>";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;?</span><span style=""color:#A31515;"">xml</span> <span style=""color:Red;"">version</span><span style=""color:Blue;"">=</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">1.0</span><span style=""color:Black;"">&quot;</span> <span style=""color:Red;"">encoding</span><span style=""color:Blue;"">=</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">UTF-8</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">?&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleEntities()
        {
            string source =
@"<string>&gt;</string>";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">string</span><span style=""color:Blue;"">&gt;</span><span style=""color:Red;"">&amp;gt;</span><span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">string</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleAnElementNameThatContainsAPeriod()
        {
            string source =
@"<anElement.StyleName>someText</anElement.StyleName>";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">anElement.StyleName</span><span style=""color:Blue;"">&gt;</span>someText<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">anElement.StyleName</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleAnAttributeThatHasSpaceBeforeAndAfterTheEqualSign()
        {
            string source =
@"<elementName attributeName = ""attributeValue"">someText</eElementName>";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">elementName</span> <span style=""color:Red;"">attributeName</span> <span style=""color:Blue;"">=</span> <span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">attributeValue</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">&gt;</span>someText<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">eElementName</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleAnElementWithANamespacePrefix()
        {
            string source =
@"<namespaceName:elementName attributeName = ""attributeValue"" />";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">namespaceName</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">elementName</span> <span style=""color:Red;"">attributeName</span> <span style=""color:Blue;"">=</span> <span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">attributeValue</span><span style=""color:Black;"">&quot;</span> <span style=""color:Blue;"">/&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleAnElementWithANamespaceAndAttributeWithNameSpace()
        {
            string source =
@"<xs:schema xmlns:xs=""http://www.w3.org/2001/XMLSchema"" targetNamespace=""http://tempuri.org/po.xsd"" 
xmlns=""http://tempuri.org/po.xsd"" elementFormDefault=""qualified"">";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">xs</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">schema</span> <span style=""color:Red;"">xmlns:xs</span><span style=""color:Blue;"">=</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">http://www.w3.org/2001/XMLSchema</span><span style=""color:Black;"">&quot;</span> <span style=""color:Red;"">targetNamespace</span><span style=""color:Blue;"">=</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">http://tempuri.org/po.xsd</span><span style=""color:Black;"">&quot;</span> 
<span style=""color:Red;"">xmlns</span><span style=""color:Blue;"">=</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">http://tempuri.org/po.xsd</span><span style=""color:Black;"">&quot;</span> <span style=""color:Red;"">elementFormDefault</span><span style=""color:Blue;"">=</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">qualified</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleXmlStylesheetPreProcessorDirective()
        {
            string source =
@"<?xml-stylesheet type=""text/xsl"" href=""show_book.xsl"" title=""default stylesheet""?>";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;?</span><span style=""color:#A31515;"">xml-stylesheet</span> <span style=""color:Red;"">type</span><span style=""color:Blue;"">=</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">text/xsl</span><span style=""color:Black;"">&quot;</span> <span style=""color:Red;"">href</span><span style=""color:Blue;"">=</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">show_book.xsl</span><span style=""color:Black;"">&quot;</span> <span style=""color:Red;"">title</span><span style=""color:Blue;"">=</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">default stylesheet</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">?&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleXmlElementsContainingAHyphen()
        {
            string source =
@"<xsl:for-each select=""x | y/x"">";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">xsl</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">for-each</span> <span style=""color:Red;"">select</span><span style=""color:Blue;"">=</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">x | y/x</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleXmlCDATA()
        {
            string source =
@"<?xml version=""1.0"" encoding=""iso-8859-1"" standalone=""yes""?>
<catalog>
    <![CDATA[An in-depth look at creating applications with XML, using <, >,]]>
</catalog>;";

            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;?</span><span style=""color:#A31515;"">xml</span> <span style=""color:Red;"">version</span><span style=""color:Blue;"">=</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">1.0</span><span style=""color:Black;"">&quot;</span> <span style=""color:Red;"">encoding</span><span style=""color:Blue;"">=</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">iso-8859-1</span><span style=""color:Black;"">&quot;</span> <span style=""color:Red;"">standalone</span><span style=""color:Blue;"">=</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">yes</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">?&gt;</span>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">catalog</span><span style=""color:Blue;"">&gt;</span>
    <span style=""color:Blue;"">&lt;![CDATA[</span><span style=""color:Gray;"">An in-depth look at creating applications with XML, using &lt;, &gt;,</span><span style=""color:Blue;"">]]&gt;</span>
<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">catalog</span><span style=""color:Blue;"">&gt;</span>;
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleXmlMultilineCDATA()
        {
            string source =
@"<?xml version=""1.0"" encoding=""iso-8859-1"" standalone=""yes""?>
<catalog>
    <![CDATA[An in-depth look at creating 
        applications with XML, using <, >,]]>
</catalog>";

            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;?</span><span style=""color:#A31515;"">xml</span> <span style=""color:Red;"">version</span><span style=""color:Blue;"">=</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">1.0</span><span style=""color:Black;"">&quot;</span> <span style=""color:Red;"">encoding</span><span style=""color:Blue;"">=</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">iso-8859-1</span><span style=""color:Black;"">&quot;</span> <span style=""color:Red;"">standalone</span><span style=""color:Blue;"">=</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">yes</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">?&gt;</span>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">catalog</span><span style=""color:Blue;"">&gt;</span>
    <span style=""color:Blue;"">&lt;![CDATA[</span><span style=""color:Gray;"">An in-depth look at creating 
        applications with XML, using &lt;, &gt;,</span><span style=""color:Blue;"">]]&gt;</span>
<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">catalog</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleXmlDoctype()
        {
            string source =
@"<?xml version=""1.0"" encoding=""iso-8859-1"" standalone=""yes""?>
<!DOCTYPE catalog SYSTEM ""Test.dtd"">
<catalog />";

            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;?</span><span style=""color:#A31515;"">xml</span> <span style=""color:Red;"">version</span><span style=""color:Blue;"">=</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">1.0</span><span style=""color:Black;"">&quot;</span> <span style=""color:Red;"">encoding</span><span style=""color:Blue;"">=</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">iso-8859-1</span><span style=""color:Black;"">&quot;</span> <span style=""color:Red;"">standalone</span><span style=""color:Blue;"">=</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">yes</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">?&gt;</span>
<span style=""color:Blue;"">&lt;!</span><span style=""color:#A31515;"">DOCTYPE</span> <span style=""color:Red;"">catalog</span> <span style=""color:Red;"">SYSTEM</span> <span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">Test.dtd</span><span style=""color:Black;"">&quot;</span><span style=""color:Blue;"">&gt;</span>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">catalog</span> <span style=""color:Blue;"">/&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleAnElementNameThatContainsUnderscore()
        {
            string source =
                @"<e_s>someText</e_s>";
            string expected =
                @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">e_s</span><span style=""color:Blue;"">&gt;</span>someText<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">e_s</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleAnElementNameThatContainsDash()
        {
            string source =
@"<e-s>someText</e-s>";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">e-s</span><span style=""color:Blue;"">&gt;</span>someText<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">e-s</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillCommentMultipleCommentsCorrectly()
        {
            string source = "<!-- test --><root><elment><!-- comment inside of element --></element></root>";
            string expected = 
                "<div style=\"color:Black;background-color:White;\"><pre>\r\n<span style=\"color:Green;\">&lt;!-- test --&gt;</span><span style=\"color:Blue;\">&lt;</span><span style=\"color:#A31515;\">root</span><span style=\"color:Blue;\">&gt;</span><span style=\"color:Blue;\">&lt;</span><span style=\"color:#A31515;\">elment</span><span style=\"color:Blue;\">&gt;</span><span style=\"color:Green;\">&lt;!-- comment inside of element --&gt;</span><span style=\"color:Blue;\">&lt;/</span><span style=\"color:#A31515;\">element</span><span style=\"color:Blue;\">&gt;</span><span style=\"color:Blue;\">&lt;/</span><span style=\"color:#A31515;\">root</span><span style=\"color:Blue;\">&gt;</span>\r\n</pre></div>";
            
            string actual = new CodeColorizer().Colorize(source, Languages.Xml);

            Assert.Equal(expected, actual);
        }
    }
}
