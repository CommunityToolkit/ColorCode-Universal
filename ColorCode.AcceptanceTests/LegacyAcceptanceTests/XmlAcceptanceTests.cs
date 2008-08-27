using Xunit;

namespace ColorCode
{
    public class XmlAcceptanceTests
    {
        [Fact]
        public void FileExtensionsWillIncludeXml()
        {
            ILanguage language = Languages.Xml;

            Assert.Contains("xml", language.FileExtensions);
        }

        [Fact]
        public void FileExtensionsWillIncludeResx()
        {
            ILanguage language = Languages.Xml;

            Assert.Contains("resx", language.FileExtensions);
        }

        [Fact]
        public void FileExtensionsWillIncludeConfig()
        {
            ILanguage language = Languages.Xml;

            Assert.Contains("config", language.FileExtensions);
        }

        [Fact]
        public void FileExtensionsWillIncludeWebinfo()
        {
            ILanguage language = Languages.Xml;

            Assert.Contains("webinfo", language.FileExtensions);
        }

        [Fact]
        public void FileExtensionsWillIncludeVsdisco()
        {
            ILanguage language = Languages.Xml;

            Assert.Contains("vsdisco", language.FileExtensions);
        }
        
        [Fact]
        public void FileExtensionsWillIncludeVsproj()
        {
            ILanguage language = Languages.Xml;

            Assert.Contains("vbproj", language.FileExtensions);
        }

        [Fact]
        public void FileExtensionsWillIncludeCsproj()
        {
            ILanguage language = Languages.Xml;

            Assert.Contains("csproj", language.FileExtensions);
        }

        [Fact]
        public void FileExtensionsWillIncludeSln()
        {
            ILanguage language = Languages.Xml;

            Assert.Contains("sln", language.FileExtensions);
        }

        [Fact]
        public void FileExtensionsWillIncludeDbml()
        {
            ILanguage language = Languages.Xml;

            Assert.Contains("dbml", language.FileExtensions);
        }

        [Fact]
        public void FileExtensionsWillIncludeBrowser()
        {
            ILanguage language = Languages.Xml;

            Assert.Contains("browser", language.FileExtensions);
        }
        
        [Fact]
        public void TransformWillStyleASimpleElement()
        {
            string source =
@"<fnord>";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">fnord</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleElementAttributes()
        {
            string source =
@"<elementName attributeName=""attributeValue"">";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">elementName</span> <span style=""color:#FF0000;"">attributeName</span>=<span style=""color:#0000FF;"">&quot;attributeValue&quot;</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleXmlPreProcessor()
        {
            string source =
@"<?xml version=""1.0"" encoding=""UTF-8""?>";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;?</span><span style=""color:#A31515;"">xml</span> <span style=""color:#FF0000;"">version</span>=<span style=""color:#0000FF;"">&quot;1.0&quot;</span> <span style=""color:#FF0000;"">encoding</span>=<span style=""color:#0000FF;"">&quot;UTF-8&quot;</span><span style=""color:#0000FF;"">?&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleEntities()
        {
            string source =
@"<string>&gt;</string>";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">string</span><span style=""color:#0000FF;"">&gt;</span><span style=""color:#FF0000;"">&amp;gt;</span><span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">string</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleAnElementNameThatContainsAPeriod()
        {
            string source =
@"<anElement.StyleName>someText</anElement.StyleName>";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">anElement.StyleName</span><span style=""color:#0000FF;"">&gt;</span>someText<span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">anElement.StyleName</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml, StyleSheets.VisualStudio);

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

            string actual = new CodeColorizer().Colorize(source, Languages.Xml, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleAnElementWithANamespacePrefix()
        {
            string source =
@"<namespaceName:elementName attributeName = ""attributeValue"" />";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">namespaceName</span>:<span style=""color:#A31515;"">elementName</span> <span style=""color:#FF0000;"">attributeName</span> = <span style=""color:#0000FF;"">&quot;attributeValue&quot;</span> <span style=""color:#0000FF;"">/&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleAnElementWithANamespaceAndAttributeWithNameSpace()
        {
            string source =
@"<xs:schema xmlns:xs=""http://www.w3.org/2001/XMLSchema"" targetNamespace=""http://tempuri.org/po.xsd"" 
xmlns=""http://tempuri.org/po.xsd"" elementFormDefault=""qualified"">";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">xs</span>:<span style=""color:#A31515;"">schema</span> <span style=""color:#FF0000;"">xmlns:xs</span>=<span style=""color:#0000FF;"">&quot;http://www.w3.org/2001/XMLSchema&quot;</span> <span style=""color:#FF0000;"">targetNamespace</span>=<span style=""color:#0000FF;"">&quot;http://tempuri.org/po.xsd&quot;</span> 
<span style=""color:#FF0000;"">xmlns</span>=<span style=""color:#0000FF;"">&quot;http://tempuri.org/po.xsd&quot;</span> <span style=""color:#FF0000;"">elementFormDefault</span>=<span style=""color:#0000FF;"">&quot;qualified&quot;</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleXmlStylesheetPreProcessorDirective()
        {
            string source =
@"<?xml-stylesheet type=""text/xsl"" href=""show_book.xsl"" title=""default stylesheet""?>";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;?</span><span style=""color:#A31515;"">xml-stylesheet</span> <span style=""color:#FF0000;"">type</span>=<span style=""color:#0000FF;"">&quot;text/xsl&quot;</span> <span style=""color:#FF0000;"">href</span>=<span style=""color:#0000FF;"">&quot;show_book.xsl&quot;</span> <span style=""color:#FF0000;"">title</span>=<span style=""color:#0000FF;"">&quot;default stylesheet&quot;</span><span style=""color:#0000FF;"">?&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleXmlElementsContainingAHyphen()
        {
            string source =
@"<xsl:for-each select=""x | y/x"">";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">xsl</span>:<span style=""color:#A31515;"">for-each</span> <span style=""color:#FF0000;"">select</span>=<span style=""color:#0000FF;"">&quot;x | y/x&quot;</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml, StyleSheets.VisualStudio);

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
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;?</span><span style=""color:#A31515;"">xml</span> <span style=""color:#FF0000;"">version</span>=<span style=""color:#0000FF;"">&quot;1.0&quot;</span> <span style=""color:#FF0000;"">encoding</span>=<span style=""color:#0000FF;"">&quot;iso-8859-1&quot;</span> <span style=""color:#FF0000;"">standalone</span>=<span style=""color:#0000FF;"">&quot;yes&quot;</span><span style=""color:#0000FF;"">?&gt;</span>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">catalog</span><span style=""color:#0000FF;"">&gt;</span>
    <span style=""color:#0000FF;"">&lt;![CDATA[</span><span style=""color:#808080;"">An in-depth look at creating applications with XML, using &lt;, &gt;,</span><span style=""color:#0000FF;"">]]&gt;</span>
<span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">catalog</span><span style=""color:#0000FF;"">&gt;</span>;
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml, StyleSheets.VisualStudio);

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
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;?</span><span style=""color:#A31515;"">xml</span> <span style=""color:#FF0000;"">version</span>=<span style=""color:#0000FF;"">&quot;1.0&quot;</span> <span style=""color:#FF0000;"">encoding</span>=<span style=""color:#0000FF;"">&quot;iso-8859-1&quot;</span> <span style=""color:#FF0000;"">standalone</span>=<span style=""color:#0000FF;"">&quot;yes&quot;</span><span style=""color:#0000FF;"">?&gt;</span>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">catalog</span><span style=""color:#0000FF;"">&gt;</span>
    <span style=""color:#0000FF;"">&lt;![CDATA[</span><span style=""color:#808080;"">An in-depth look at creating 
        applications with XML, using &lt;, &gt;,</span><span style=""color:#0000FF;"">]]&gt;</span>
<span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">catalog</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml, StyleSheets.VisualStudio);

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
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;?</span><span style=""color:#A31515;"">xml</span> <span style=""color:#FF0000;"">version</span>=<span style=""color:#0000FF;"">&quot;1.0&quot;</span> <span style=""color:#FF0000;"">encoding</span>=<span style=""color:#0000FF;"">&quot;iso-8859-1&quot;</span> <span style=""color:#FF0000;"">standalone</span>=<span style=""color:#0000FF;"">&quot;yes&quot;</span><span style=""color:#0000FF;"">?&gt;</span>
<span style=""color:#0000FF;"">&lt;!</span><span style=""color:#A31515;"">DOCTYPE</span> <span style=""color:#FF0000;"">catalog</span> <span style=""color:#FF0000;"">SYSTEM</span> <span style=""color:#0000FF;"">&quot;Test.dtd&quot;</span><span style=""color:#0000FF;"">&gt;</span>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">catalog</span> <span style=""color:#0000FF;"">/&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.Xml, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }
    }
}
