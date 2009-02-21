using Xunit;

namespace ColorCode.SqlAcceptanceTests
{
    public class SqlTextAndImageFunctionsTests
    {
        public class Transform
        {
            [Fact]
            public void WillStylePatIndexFunction()
            {
                string sourceText =
@"USE AdventureWorks;
GO
SELECT PATINDEX('%ensure%',DocumentSummary)
FROM Production.Document
WHERE DocumentID = 3;
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> AdventureWorks;
GO
<span style=""color:Blue;"">SELECT</span> <span style=""color:Blue;"">PATINDEX</span>(<span style=""color:#A31515;"">'%ensure%'</span>,DocumentSummary)
<span style=""color:Blue;"">FROM</span> Production.Document
<span style=""color:Blue;"">WHERE</span> DocumentID = 3;
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleTextValidFunction()
            {
                string sourceText =
@"USE pubs;
GO
SELECT pub_id, 'Valid (if 1) Regex data' 
 = TEXTVALID ('pub_info.logo', TEXTPTR(logo)) 
FROM pub_info
ORDER BY pub_id;
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> pubs;
GO
<span style=""color:Blue;"">SELECT</span> pub_id, <span style=""color:#A31515;"">'Valid (if 1) Regex data'</span> 
 = <span style=""color:Blue;"">TEXTVALID</span> (<span style=""color:#A31515;"">'pub_info.logo'</span>, <span style=""color:Blue;"">TEXTPTR</span>(logo)) 
<span style=""color:Blue;"">FROM</span> pub_info
<span style=""color:Blue;"">ORDER</span> <span style=""color:Blue;"">BY</span> pub_id;
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleTextPtrFunction()
            {
                string sourceText =
@"USE pubs
GO
DECLARE @ptrval varbinary(16)
SELECT @ptrval = TEXTPTR(logo) 
FROM pub_info pr, publishers p
WHERE p.pub_id = pr.pub_id
    AND p.pub_name = 'New Moon Books'
GO";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">USE</span> pubs
GO
<span style=""color:Blue;"">DECLARE</span> @ptrval <span style=""color:Blue;"">varbinary</span>(16)
<span style=""color:Blue;"">SELECT</span> @ptrval = <span style=""color:Blue;"">TEXTPTR</span>(logo) 
<span style=""color:Blue;"">FROM</span> pub_info pr, publishers p
<span style=""color:Blue;"">WHERE</span> p.pub_id = pr.pub_id
    <span style=""color:Blue;"">AND</span> p.pub_name = <span style=""color:#A31515;"">'New Moon Books'</span>
GO
</pre></div>";

                string actual = new CodeColorizer().Colorize(sourceText, Languages.Sql);

                Assert.Equal(expected, actual);
            }
        }
    }
}
