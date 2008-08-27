using Xunit;

namespace ColorCode.AspxCsAcceptanceTests
{
    public class AspxCsScenarioTests
    {
        static ILanguage GetGrammar()
        {
            return Languages.AspxCs;
        }
        
        public class Transform
        {
            [Fact]
            public void WillStylePageDeclaration()
            {
                string source =
                    @"<%@ Page LanguageDefinition=""C#"" AutoEventWireup=""true"" CodeBehind=""DefaultStyleSheet.aspx.cs"" Inherits=""WebApplication2._Default"" %>";
                string expected =
                    @"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""background-color:#FFFF00;"">&lt;%</span><span style=""color:#0000FF;"">@</span> <span style=""color:#A31515;"">Page</span> <span style=""color:#FF0000;"">LanguageDefinition</span>=<span style=""color:#0000FF;"">&quot;C#&quot;</span> <span style=""color:#FF0000;"">AutoEventWireup</span>=<span style=""color:#0000FF;"">&quot;true&quot;</span> <span style=""color:#FF0000;"">CodeBehind</span>=<span style=""color:#0000FF;"">&quot;DefaultStyleSheet.aspx.cs&quot;</span> <span style=""color:#FF0000;"">Inherits</span>=<span style=""color:#0000FF;"">&quot;WebApplication2._Default&quot;</span> <span style=""background-color:#FFFF00;"">%&gt;</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, GetGrammar(), StyleSheets.VisualStudio);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleEmbeddedCs()
            {
                string source =
                    @"<%
    public string Foo()
    {
        return ""foo"";
    }
%>";
                string expected =
                    @"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""background-color:#FFFF00;"">&lt;%</span>
    <span style=""color:#0000FF;"">public</span> <span style=""color:#0000FF;"">string</span> Foo()
    {
        <span style=""color:#0000FF;"">return</span> <span style=""color:#A31515;"">&quot;foo&quot;</span>;
    }
<span style=""background-color:#FFFF00;"">%&gt;</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, GetGrammar(), StyleSheets.VisualStudio);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleEmbeddedWrite()
            {
                string source =
                    @"<%=String.Format(""Foo{0}"", ""Bar"")%>";
                string expected =
                    @"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""background-color:#FFFF00;"">&lt;%=</span>String.Format(<span style=""color:#A31515;"">&quot;Foo{0}&quot;</span>, <span style=""color:#A31515;"">&quot;Bar&quot;</span>)<span style=""background-color:#FFFF00;"">%&gt;</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, GetGrammar(), StyleSheets.VisualStudio);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleServerSideComment()
            {
                string source =
                    @"<%--
    String.Format(""Foo{0}"", ""Bar"")
--%>";
                string expected =
                    @"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""background-color:#FFFF00;"">&lt;%</span><span style=""color:#008000;"">--
    String.Format(&quot;Foo{0}&quot;, &quot;Bar&quot;)
--</span><span style=""background-color:#FFFF00;"">%&gt;</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, GetGrammar(), StyleSheets.VisualStudio);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleElementsWithNamespace()
            {
                string source =
@"<asp:DropDownList ID=""StateList"" runat=""server"">
    <asp:ListItem>CA</asp:ListItem>
    <asp:ListItem>IN</asp:ListItem>
    <asp:ListItem>KS</asp:ListItem>
    <asp:ListItem>MD</asp:ListItem>
    <asp:ListItem>MI</asp:ListItem>
    <asp:ListItem>OR</asp:ListItem>
    <asp:ListItem>TN</asp:ListItem>
    <asp:ListItem>UT</asp:ListItem>
</asp:DropDownList>";
                string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">DropDownList</span> <span style=""color:#FF0000;"">ID</span>=<span style=""color:#0000FF;"">&quot;StateList&quot;</span> <span style=""color:#FF0000;"">runat</span>=<span style=""color:#0000FF;"">&quot;server&quot;</span><span style=""color:#0000FF;"">&gt;</span>
    <span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:#0000FF;"">&gt;</span>CA<span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:#0000FF;"">&gt;</span>
    <span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:#0000FF;"">&gt;</span>IN<span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:#0000FF;"">&gt;</span>
    <span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:#0000FF;"">&gt;</span>KS<span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:#0000FF;"">&gt;</span>
    <span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:#0000FF;"">&gt;</span>MD<span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:#0000FF;"">&gt;</span>
    <span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:#0000FF;"">&gt;</span>MI<span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:#0000FF;"">&gt;</span>
    <span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:#0000FF;"">&gt;</span>OR<span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:#0000FF;"">&gt;</span>
    <span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:#0000FF;"">&gt;</span>TN<span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:#0000FF;"">&gt;</span>
    <span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:#0000FF;"">&gt;</span>UT<span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:#0000FF;"">&gt;</span>
<span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">DropDownList</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, GetGrammar(), StyleSheets.VisualStudio);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleElementsWithNamespaceAndEmbeddedCode()
            {
                string source =
@"<asp:DataList ID=""MyList"" runat=""server"">
    <ItemTemplate>
        <%# string.Format(""Here is the value: {0}"", theValue) %>
    </ItemTemplate>
</asp:DataList>";
                string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">DataList</span> <span style=""color:#FF0000;"">ID</span>=<span style=""color:#0000FF;"">&quot;MyList&quot;</span> <span style=""color:#FF0000;"">runat</span>=<span style=""color:#0000FF;"">&quot;server&quot;</span><span style=""color:#0000FF;"">&gt;</span>
    <span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">ItemTemplate</span><span style=""color:#0000FF;"">&gt;</span>
        <span style=""background-color:#FFFF00;"">&lt;%</span># <span style=""color:#0000FF;"">string</span>.Format(<span style=""color:#A31515;"">&quot;Here is the value: {0}&quot;</span>, theValue) <span style=""background-color:#FFFF00;"">%&gt;</span>
    <span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">ItemTemplate</span><span style=""color:#0000FF;"">&gt;</span>
<span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">DataList</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, GetGrammar(), StyleSheets.VisualStudio);

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

                string actual = new CodeColorizer().Colorize(source, GetGrammar(), StyleSheets.VisualStudio);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleServerDeclarationWithSpaceAroundAttributeEqualSign()
            {
                string source =
@"<%@ Assembly StyleName = ""assemblyname"" src=""pathname"" %>";
                string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""background-color:#FFFF00;"">&lt;%</span><span style=""color:#0000FF;"">@</span> <span style=""color:#A31515;"">Assembly</span> <span style=""color:#FF0000;"">StyleName</span> = <span style=""color:#0000FF;"">&quot;assemblyname&quot;</span> <span style=""color:#FF0000;"">src</span>=<span style=""color:#0000FF;"">&quot;pathname&quot;</span> <span style=""background-color:#FFFF00;"">%&gt;</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, GetGrammar(), StyleSheets.VisualStudio);

                Assert.Equal(expected, actual);
            }
        }
    }
}