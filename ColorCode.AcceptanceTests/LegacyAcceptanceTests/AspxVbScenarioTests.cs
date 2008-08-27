using Xunit;

namespace ColorCode.AspxVbAcceptanceTests
{
    public class AspxVbScenarioTests
    {
        static ILanguage GetGrammar()
        {
            return Languages.AspxVb;
        }
        
        public class Transform
        {
            [Fact]
            public void WillStylePageDeclaration()
            {
                string source =
                    @"<%@ Page LanguageDefinition=""VB"" AutoEventWireup=""false"" CodeFile=""DefaultStyleSheet.aspx.vb"" Inherits=""_Default"" %>";
                string expected =
                    @"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""background-color:#FFFF00;"">&lt;%</span><span style=""color:#0000FF;"">@</span> <span style=""color:#A31515;"">Page</span> <span style=""color:#FF0000;"">LanguageDefinition</span><span style=""color:#0000FF;"">=</span><span style=""color:#0000FF;"">&quot;VB&quot;</span> <span style=""color:#FF0000;"">AutoEventWireup</span><span style=""color:#0000FF;"">=</span><span style=""color:#0000FF;"">&quot;false&quot;</span> <span style=""color:#FF0000;"">CodeFile</span><span style=""color:#0000FF;"">=</span><span style=""color:#0000FF;"">&quot;DefaultStyleSheet.aspx.vb&quot;</span> <span style=""color:#FF0000;"">Inherits</span><span style=""color:#0000FF;"">=</span><span style=""color:#0000FF;"">&quot;_Default&quot;</span> <span style=""background-color:#FFFF00;"">%&gt;</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, GetGrammar(), StyleSheets.VisualStudio);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleEmbeddedVb()
            {
                string source =
                    @"<%
    Public Sub WriteFoo()
        Response.Write(""Foo"")
    End Sub
%>";
                string expected =
                    @"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""background-color:#FFFF00;"">&lt;%</span>
    <span style=""color:#0000FF;"">Public</span> <span style=""color:#0000FF;"">Sub</span> WriteFoo()
        Response.Write(<span style=""color:#A31515;"">&quot;Foo&quot;</span>)
    <span style=""color:#0000FF;"">End</span> <span style=""color:#0000FF;"">Sub</span>
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
<span style=""background-color:#FFFF00;"">&lt;%=</span><span style=""color:#0000FF;"">String</span>.Format(<span style=""color:#A31515;"">&quot;Foo{0}&quot;</span>, <span style=""color:#A31515;"">&quot;Bar&quot;</span>)<span style=""background-color:#FFFF00;"">%&gt;</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, GetGrammar(), StyleSheets.VisualStudio);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleVbEmbeddedInScriptRunatServer()
            {
                string source =
                    @"<script runat=""server"">
    Public Sub WriteFoo()
        Response.Write(""Foo"")
    End Sub
</script>";
                string expected =
                    @"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">script</span> <span style=""color:#FF0000;"">runat</span>=<span style=""color:#0000FF;"">&quot;server&quot;</span><span style=""color:#0000FF;"">&gt;</span>
    <span style=""color:#0000FF;"">Public</span> <span style=""color:#0000FF;"">Sub</span> WriteFoo()
        Response.Write(<span style=""color:#A31515;"">&quot;Foo&quot;</span>)
    <span style=""color:#0000FF;"">End</span> <span style=""color:#0000FF;"">Sub</span>
<span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">script</span><span style=""color:#0000FF;"">&gt;</span>
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
            public void WillStyleEmbeddedDataBindInSingleQuotes()
            {
                string source =
                    @"<asp:LinkButton id=""LinkButton1"" runat=""Server"" CommandName=""Delete"" CommandArgument='<%# DataBinder.Eval(Container.DataItem,""ID"") %>'>x</asp:LinkButton>";
                string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">LinkButton</span> <span style=""color:#FF0000;"">id</span>=<span style=""color:#0000FF;"">&quot;LinkButton1&quot;</span> <span style=""color:#FF0000;"">runat</span>=<span style=""color:#0000FF;"">&quot;Server&quot;</span> <span style=""color:#FF0000;"">CommandName</span>=<span style=""color:#0000FF;"">&quot;Delete&quot;</span> <span style=""color:#FF0000;"">CommandArgument</span>='<span style=""background-color:#FFFF00;"">&lt;%#</span> DataBinder.Eval(Container.DataItem,<span style=""color:#A31515;"">&quot;ID&quot;</span>) <span style=""background-color:#FFFF00;"">%&gt;</span>'<span style=""color:#0000FF;"">&gt;</span>x<span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">LinkButton</span><span style=""color:#0000FF;"">&gt;</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, GetGrammar(), StyleSheets.VisualStudio);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleEmbeddedDataBindInDoubleQuotes()
            {
                string source =
                    @"<asp:LinkButton id=""LinkButton1"" runat=""Server"" CommandName=""Delete"" CommandArgument=""<%# DataBinder.Eval(Container.DataItem,""ID"") %>"">x</asp:LinkButton>";
                string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">LinkButton</span> <span style=""color:#FF0000;"">id</span>=<span style=""color:#0000FF;"">&quot;LinkButton1&quot;</span> <span style=""color:#FF0000;"">runat</span>=<span style=""color:#0000FF;"">&quot;Server&quot;</span> <span style=""color:#FF0000;"">CommandName</span>=<span style=""color:#0000FF;"">&quot;Delete&quot;</span> <span style=""color:#FF0000;"">CommandArgument</span>=&quot;<span style=""background-color:#FFFF00;"">&lt;%#</span> DataBinder.Eval(Container.DataItem,<span style=""color:#A31515;"">&quot;ID&quot;</span>) <span style=""background-color:#FFFF00;"">%&gt;</span>&quot;<span style=""color:#0000FF;"">&gt;</span>x<span style=""color:#0000FF;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">LinkButton</span><span style=""color:#0000FF;"">&gt;</span>
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
        <%# String.Format(""Here is the value: {0}"", theValue) %>
    </ItemTemplate>
</asp:DataList>";
                string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:#0000FF;"">:</span><span style=""color:#A31515;"">DataList</span> <span style=""color:#FF0000;"">ID</span>=<span style=""color:#0000FF;"">&quot;MyList&quot;</span> <span style=""color:#FF0000;"">runat</span>=<span style=""color:#0000FF;"">&quot;server&quot;</span><span style=""color:#0000FF;"">&gt;</span>
    <span style=""color:#0000FF;"">&lt;</span><span style=""color:#A31515;"">ItemTemplate</span><span style=""color:#0000FF;"">&gt;</span>
        <span style=""background-color:#FFFF00;"">&lt;%</span># <span style=""color:#0000FF;"">String</span>.Format(<span style=""color:#A31515;"">&quot;Here is the value: {0}&quot;</span>, theValue) <span style=""background-color:#FFFF00;"">%&gt;</span>
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
<span style=""background-color:#FFFF00;"">&lt;%</span><span style=""color:#0000FF;"">@</span> <span style=""color:#A31515;"">Assembly</span> <span style=""color:#FF0000;"">StyleName</span> <span style=""color:#0000FF;"">=</span> <span style=""color:#0000FF;"">&quot;assemblyname&quot;</span> <span style=""color:#FF0000;"">src</span><span style=""color:#0000FF;"">=</span><span style=""color:#0000FF;"">&quot;pathname&quot;</span> <span style=""background-color:#FFFF00;"">%&gt;</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, GetGrammar(), StyleSheets.VisualStudio);

                Assert.Equal(expected, actual);
            }
        }
    }
}