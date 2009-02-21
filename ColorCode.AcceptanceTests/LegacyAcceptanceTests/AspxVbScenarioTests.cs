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
                    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""background-color:Yellow;"">&lt;%</span><span style=""color:Blue;"">@</span> <span style=""color:#A31515;"">Page</span> <span style=""color:Red;"">LanguageDefinition</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;VB&quot;</span> <span style=""color:Red;"">AutoEventWireup</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;false&quot;</span> <span style=""color:Red;"">CodeFile</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;DefaultStyleSheet.aspx.vb&quot;</span> <span style=""color:Red;"">Inherits</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;_Default&quot;</span> <span style=""background-color:Yellow;"">%&gt;</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, GetGrammar());

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
                    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""background-color:Yellow;"">&lt;%</span>
    <span style=""color:Blue;"">Public</span> <span style=""color:Blue;"">Sub</span> WriteFoo()
        Response.Write(<span style=""color:#A31515;"">&quot;Foo&quot;</span>)
    <span style=""color:Blue;"">End</span> <span style=""color:Blue;"">Sub</span>
<span style=""background-color:Yellow;"">%&gt;</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, GetGrammar());

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleEmbeddedWrite()
            {
                string source =
                    @"<%=String.Format(""Foo{0}"", ""Bar"")%>";
                string expected =
                    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""background-color:Yellow;"">&lt;%=</span><span style=""color:Blue;"">String</span>.Format(<span style=""color:#A31515;"">&quot;Foo{0}&quot;</span>, <span style=""color:#A31515;"">&quot;Bar&quot;</span>)<span style=""background-color:Yellow;"">%&gt;</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, GetGrammar());

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
                    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">script</span> <span style=""color:Red;"">runat</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;server&quot;</span><span style=""color:Blue;"">&gt;</span>
    <span style=""color:Blue;"">Public</span> <span style=""color:Blue;"">Sub</span> WriteFoo()
        Response.Write(<span style=""color:#A31515;"">&quot;Foo&quot;</span>)
    <span style=""color:Blue;"">End</span> <span style=""color:Blue;"">Sub</span>
<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">script</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, GetGrammar());

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
                    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""background-color:Yellow;"">&lt;%</span><span style=""color:Green;"">--
    String.Format(&quot;Foo{0}&quot;, &quot;Bar&quot;)
--</span><span style=""background-color:Yellow;"">%&gt;</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, GetGrammar());

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleEmbeddedDataBindInSingleQuotes()
            {
                string source =
                    @"<asp:LinkButton id=""LinkButton1"" runat=""Server"" CommandName=""Delete"" CommandArgument='<%# DataBinder.Eval(Container.DataItem,""ID"") %>'>x</asp:LinkButton>";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">LinkButton</span> <span style=""color:Red;"">id</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;LinkButton1&quot;</span> <span style=""color:Red;"">runat</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;Server&quot;</span> <span style=""color:Red;"">CommandName</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;Delete&quot;</span> <span style=""color:Red;"">CommandArgument</span><span style=""color:Blue;"">=</span>'<span style=""background-color:Yellow;"">&lt;%#</span> DataBinder.Eval(Container.DataItem,<span style=""color:#A31515;"">&quot;ID&quot;</span>) <span style=""background-color:Yellow;"">%&gt;</span>'<span style=""color:Blue;"">&gt;</span>x<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">LinkButton</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, GetGrammar());

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleEmbeddedDataBindInDoubleQuotes()
            {
                string source =
                    @"<asp:LinkButton id=""LinkButton1"" runat=""Server"" CommandName=""Delete"" CommandArgument=""<%# DataBinder.Eval(Container.DataItem,""ID"") %>"">x</asp:LinkButton>";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">LinkButton</span> <span style=""color:Red;"">id</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;LinkButton1&quot;</span> <span style=""color:Red;"">runat</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;Server&quot;</span> <span style=""color:Red;"">CommandName</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;Delete&quot;</span> <span style=""color:Red;"">CommandArgument</span><span style=""color:Blue;"">=</span>&quot;<span style=""background-color:Yellow;"">&lt;%#</span> DataBinder.Eval(Container.DataItem,<span style=""color:#A31515;"">&quot;ID&quot;</span>) <span style=""background-color:Yellow;"">%&gt;</span>&quot;<span style=""color:Blue;"">&gt;</span>x<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">LinkButton</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, GetGrammar());

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
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">DropDownList</span> <span style=""color:Red;"">ID</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;StateList&quot;</span> <span style=""color:Red;"">runat</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;server&quot;</span><span style=""color:Blue;"">&gt;</span>
    <span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:Blue;"">&gt;</span>CA<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:Blue;"">&gt;</span>
    <span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:Blue;"">&gt;</span>IN<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:Blue;"">&gt;</span>
    <span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:Blue;"">&gt;</span>KS<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:Blue;"">&gt;</span>
    <span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:Blue;"">&gt;</span>MD<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:Blue;"">&gt;</span>
    <span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:Blue;"">&gt;</span>MI<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:Blue;"">&gt;</span>
    <span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:Blue;"">&gt;</span>OR<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:Blue;"">&gt;</span>
    <span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:Blue;"">&gt;</span>TN<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:Blue;"">&gt;</span>
    <span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:Blue;"">&gt;</span>UT<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">ListItem</span><span style=""color:Blue;"">&gt;</span>
<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">DropDownList</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, GetGrammar());

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
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">DataList</span> <span style=""color:Red;"">ID</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;MyList&quot;</span> <span style=""color:Red;"">runat</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;server&quot;</span><span style=""color:Blue;"">&gt;</span>
    <span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">ItemTemplate</span><span style=""color:Blue;"">&gt;</span>
        <span style=""background-color:Yellow;"">&lt;%</span># <span style=""color:Blue;"">String</span>.Format(<span style=""color:#A31515;"">&quot;Here is the value: {0}&quot;</span>, theValue) <span style=""background-color:Yellow;"">%&gt;</span>
    <span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">ItemTemplate</span><span style=""color:Blue;"">&gt;</span>
<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">DataList</span><span style=""color:Blue;"">&gt;</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, GetGrammar());

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

                string actual = new CodeColorizer().Colorize(source, GetGrammar());

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleServerDeclarationWithSpaceAroundAttributeEqualSign()
            {
                string source =
@"<%@ Assembly StyleName = ""assemblyname"" src=""pathname"" %>";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""background-color:Yellow;"">&lt;%</span><span style=""color:Blue;"">@</span> <span style=""color:#A31515;"">Assembly</span> <span style=""color:Red;"">StyleName</span> <span style=""color:Blue;"">=</span> <span style=""color:Blue;"">&quot;assemblyname&quot;</span> <span style=""color:Red;"">src</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;pathname&quot;</span> <span style=""background-color:Yellow;"">%&gt;</span>
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, GetGrammar());

                Assert.Equal(expected, actual);
            }
        }
    }
}