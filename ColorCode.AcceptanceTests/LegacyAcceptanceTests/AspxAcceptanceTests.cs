using Xunit;

namespace ColorCode.AspxAcceptanceTests
{
    public class AspxScenarioTests
    {
        static ILanguage GetGrammar()
        {
            return Languages.Aspx;
        }

        public class Transform
        {
            [Fact]
            public void WillStylePageDeclaration()
            {
                string source =
                    @"<%--
DefaultStyleSheet skin template. The following skins are provided as examples only.

1. Named control skin. The SkinId should be uniquely defined because
duplicate SkinId's per control type are not allowed in the same theme.

<asp:GridView runat=""server"" SkinId=""gridviewSkin"" BackColor=""White"" >
<AlternatingRowStyle BackColor=""Blue"" />
</asp:GridView>

2. DefaultStyleSheet skin. The SkinId is not defined. Only one default 
control skin per control type is allowed in the same theme.

<asp:Image runat=""server"" ImageUrl=""~/images/image1.jpg"" />
--%>
<asp:GridView runat=""server"" SkinId=""gridviewSkin"" BackColor=""White"" >
<AlternatingRowStyle BackColor=""Blue"" />
</asp:GridView>
<asp:Image runat=""server"" ImageUrl=""~/images/image1.jpg"" />
";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""background-color:Yellow;"">&lt;%</span><span style=""color:Green;"">--
DefaultStyleSheet skin template. The following skins are provided as examples only.

1. Named control skin. The SkinId should be uniquely defined because
duplicate SkinId's per control type are not allowed in the same theme.

&lt;asp:GridView runat=&quot;server&quot; SkinId=&quot;gridviewSkin&quot; BackColor=&quot;White&quot; &gt;
&lt;AlternatingRowStyle BackColor=&quot;Blue&quot; /&gt;
&lt;/asp:GridView&gt;

2. DefaultStyleSheet skin. The SkinId is not defined. Only one default 
control skin per control type is allowed in the same theme.

&lt;asp:Image runat=&quot;server&quot; ImageUrl=&quot;~/images/image1.jpg&quot; /&gt;
--</span><span style=""background-color:Yellow;"">%&gt;</span>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">GridView</span> <span style=""color:Red;"">runat</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;server&quot;</span> <span style=""color:Red;"">SkinId</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;gridviewSkin&quot;</span> <span style=""color:Red;"">BackColor</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;White&quot;</span> <span style=""color:Blue;"">&gt;</span>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">AlternatingRowStyle</span> <span style=""color:Red;"">BackColor</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;Blue&quot;</span> <span style=""color:Blue;"">/&gt;</span>
<span style=""color:Blue;"">&lt;/</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">GridView</span><span style=""color:Blue;"">&gt;</span>
<span style=""color:Blue;"">&lt;</span><span style=""color:#A31515;"">asp</span><span style=""color:Blue;"">:</span><span style=""color:#A31515;"">Image</span> <span style=""color:Red;"">runat</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;server&quot;</span> <span style=""color:Red;"">ImageUrl</span><span style=""color:Blue;"">=</span><span style=""color:Blue;"">&quot;~/images/image1.jpg&quot;</span> <span style=""color:Blue;"">/&gt;</span>

</pre></div>";

                string actual = ColorCode.Colorize(source, GetGrammar());

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

                string actual = ColorCode.Colorize(source, GetGrammar());

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

                string actual = ColorCode.Colorize(source, GetGrammar());

                Assert.Equal(expected, actual);
            }
        }
    }
}