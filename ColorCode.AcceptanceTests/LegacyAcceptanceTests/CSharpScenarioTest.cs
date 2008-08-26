using System;
using Xunit;

namespace ColorCode.CSharpAcceptanceTests
{
    public class CSharpScenarioTests
    {
        public class Transform
        {
            [Fact]
            public void WillStyleDocComment()
            {
                string source =
    @"/// <summary>The</summary>";
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Gray;"">///</span> <span style=""color:Gray;"">&lt;summary&gt;</span><span style=""color:Green;"">The</span><span style=""color:Gray;"">&lt;/summary&gt;</span>
</pre></div>";

                string actual = ColorCode.Colorize(source, Languages.CSharp);

                Assert.Equal(expected, actual);
            }

            [Fact(Skip = "")]
            public void WillStyleMultiLineComment()
            {
                string source =
    @"/// <summary>
/// This class implements the MD4 message digest algorithm.";
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Green;""><span style=""color:Gray;"">///</span></span><span style=""color:Green;""> </span><span style=""color:Blue;""><span style=""color:Gray;"">&lt;</span><span style=""color:Gray;"">summary</span></span><span style=""color:Blue;""><span style=""color:Gray;"">&gt;</span></span>
<span style=""color:Green;""><span style=""color:Gray;"">///</span></span><span style=""color:Green;""> This class implements the MD4 message digest algorithm.</span>
</pre></div>";

                string actual = ColorCode.Colorize(source, Languages.CSharp);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleExceptionWithString()
            {
                string source = @"throw new InvalidOperationException(""GetDigest cannot be called twice for a single hash sequence.  Call Reset() ."");";
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">throw</span> <span style=""color:Blue;"">new</span> InvalidOperationException(<span style=""color:#A31515;"">&quot;GetDigest cannot be called twice for a single hash sequence.  Call Reset() .&quot;</span>);
</pre></div>";

                string actual = ColorCode.Colorize(source, Languages.CSharp);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleEmptySource()
            {
                string source = String.Empty;
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>

</pre></div>";

                string actual = ColorCode.Colorize(source, Languages.CSharp);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleASolitaryUsingStatement()
            {
                string source =
    @"using System;";

                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">using</span> System;
</pre></div>";

                string actual = ColorCode.Colorize(source, Languages.CSharp);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleTwoUsingStatements()
            {
                string source =
    @"using System;
using Fnord;";

                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">using</span> System;
<span style=""color:Blue;"">using</span> Fnord;
</pre></div>";

                string actual = ColorCode.Colorize(source, Languages.CSharp);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleAMethodWithoutArguments()
            {
                string source =
    @"using System;

namespace TheNamespace
{
    /* This is a comment */
    public class TheClass
        : TheBaseClass
    {
        public string AMethod()
        {
            return ""Hello World!"";
        }
    }
}";

                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">using</span> System;

<span style=""color:Blue;"">namespace</span> TheNamespace
{
    <span style=""color:Green;"">/* This is a comment */</span>
    <span style=""color:Blue;"">public</span> <span style=""color:Blue;"">class</span> TheClass
        : TheBaseClass
    {
        <span style=""color:Blue;"">public</span> <span style=""color:Blue;"">string</span> AMethod()
        {
            <span style=""color:Blue;"">return</span> <span style=""color:#A31515;"">&quot;Hello World!&quot;</span>;
        }
    }
}
</pre></div>";

                string actual = ColorCode.Colorize(source, Languages.CSharp);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleBaseClassOnSameLineAsClass()
            {
                string source =
    @"public class TheClass : TheBaseClass
{
}";

                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">public</span> <span style=""color:Blue;"">class</span> TheClass : TheBaseClass
{
}
</pre></div>";

                string actual = ColorCode.Colorize(source, Languages.CSharp);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleMultiLineStatement()
            {
                string source =
    @"/*
Line 1
Line 2
Line 3
*/";
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Green;"">/*
Line 1
Line 2
Line 3
*/</span>
</pre></div>";

                string actual = ColorCode.Colorize(source, Languages.CSharp);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleThrowStatement()
            {
                string source =
    @"throw new InvalidOperationException();";

                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">throw</span> <span style=""color:Blue;"">new</span> InvalidOperationException();
</pre></div>";

                string actual = ColorCode.Colorize(source, Languages.CSharp);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleStringWithEmbeddedDoubleQuotes()
            {
                string source =
    @"string aString = @""""""someText"""""";";

                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">string</span> aString = <span style=""color:#A31515;"">@&quot;&quot;&quot;someText&quot;&quot;&quot;</span>;
</pre></div>";

                string actual = ColorCode.Colorize(source, Languages.CSharp);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleVerbatimStringLiteralOnMultipleLines()
            {
                string source =
    @"string aString = @""
""""someText""""
"";";

                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">string</span> aString = <span style=""color:#A31515;"">@&quot;
&quot;&quot;someText&quot;&quot;
&quot;</span>;
</pre></div>";

                string actual = ColorCode.Colorize(source, Languages.CSharp);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void TransformWillStyleAttributeTarget()
            {
                string source =
    @"[assembly: SomeAttribute]";
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
[<span style=""color:Blue;"">assembly</span>: SomeAttribute]
</pre></div>";

                string actual = ColorCode.Colorize(source, Languages.CSharp);

                Assert.Equal(expected, actual);
            }

            [Fact(Skip="Post-poning to v2.")]
            public void TransformWillStyleClassName()
            {
                string source =
    @"public class ClassName 
{";
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">public</span> <span style=""color:Blue;"">class</span> <span style=""color:#2B91AF;"">ClassName</span> 
{
</pre></div>";

                string actual = ColorCode.Colorize(source, Languages.CSharp);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleMultipleDocComments()
            {
                string source =
    @"/// <summary>
/// Contains various static methods that are used to verify that conditions are met during the
/// process of running tests.
/// </summary>
public class Assert";
                string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Gray;"">///</span> <span style=""color:Gray;"">&lt;summary&gt;</span>
<span style=""color:Gray;"">///</span><span style=""color:Green;""> Contains various static methods that are used to verify that conditions are met during the</span>
<span style=""color:Gray;"">///</span><span style=""color:Green;""> process of running tests.</span>
<span style=""color:Gray;"">///</span><span style=""color:Green;""> </span><span style=""color:Gray;"">&lt;/summary&gt;</span>
<span style=""color:Blue;"">public</span> <span style=""color:Blue;"">class</span> Assert
</pre></div>";

                string actual = ColorCode.Colorize(source, Languages.CSharp);

                Assert.Equal(expected, actual);
            }
        }
    }
}
