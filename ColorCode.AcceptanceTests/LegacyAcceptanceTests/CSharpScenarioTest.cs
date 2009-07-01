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
                    "<div style=\"color:Black;background-color:White;\"><pre>\r\n<span style=\"color:Gray;\">///</span> <span style=\"color:Gray;\">&lt;summary&gt;</span><span style=\"color:Green;\">The&lt;/summary&gt;</span>\r\n</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.CSharp);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleDocCommentMultilineWithSpaces()
            {
                string source =
    @"/// <exception cref=""CompositionException"">
/// An error occurred during composition. <see cref=""CompositionException.Issues""/> will 
/// contain a list of errors that occurred.
/// </exception>
/// test
";
                string expected =
                    "<div style=\"color:Black;background-color:White;\"><pre>\r\n<span style=\"color:Gray;\">///</span> <span style=\"color:Gray;\">&lt;exception cref=&quot;CompositionException&quot;&gt;</span>\r\n<span style=\"color:Gray;\">///</span><span style=\"color:Green;\"> An error occurred during composition. &lt;see cref=&quot;CompositionException.Issues&quot;/&gt; will </span>\r\n<span style=\"color:Gray;\">///</span><span style=\"color:Green;\"> contain a list of errors that occurred.</span>\r\n<span style=\"color:Gray;\">///</span> <span style=\"color:Gray;\">&lt;/exception&gt;</span>\r\n<span style=\"color:Gray;\">///</span><span style=\"color:Green;\"> test</span>\r\n\r\n</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.CSharp);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleDocCommentMultilineWithcref()
            {
                string source =
    @"using System;

/// <exception cref=""Class1"">
/// An error occurred during composition. <see cref=""Class1.test""/> will 
/// contain a list of errors that occurred.
/// </exception>
/// test
public class Class1
{
    public void test()
	{
	}
}";
                string expected = "<div style=\"color:Black;background-color:White;\"><pre>\r\n<span style=\"color:Blue;\">using</span> System;\r\n\r\n<span style=\"color:Gray;\">///</span> <span style=\"color:Gray;\">&lt;exception cref=&quot;Class1&quot;&gt;</span>\r\n<span style=\"color:Gray;\">///</span><span style=\"color:Green;\"> An error occurred during composition. &lt;see cref=&quot;Class1.test&quot;/&gt; will </span>\r\n<span style=\"color:Gray;\">///</span><span style=\"color:Green;\"> contain a list of errors that occurred.</span>\r\n<span style=\"color:Gray;\">///</span> <span style=\"color:Gray;\">&lt;/exception&gt;</span>\r\n<span style=\"color:Gray;\">///</span><span style=\"color:Green;\"> test</span>\r\n<span style=\"color:Blue;\">public</span> <span style=\"color:Blue;\">class</span><span style=\"color:MediumTurquoise;\"> Class1\r\n</span>{\r\n    <span style=\"color:Blue;\">public</span> <span style=\"color:Blue;\">void</span> test()\r\n\t{\r\n\t}\r\n}\r\n</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.CSharp);

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

                string actual = new CodeColorizer().Colorize(source, Languages.CSharp);

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

                string actual = new CodeColorizer().Colorize(source, Languages.CSharp);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillStyleEmptySource()
            {
                string source = String.Empty;
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>

</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.CSharp);

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

                string actual = new CodeColorizer().Colorize(source, Languages.CSharp);

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

                string actual = new CodeColorizer().Colorize(source, Languages.CSharp);

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
        : TheBaseClass, Implements
    {
        public string AMethod()
        {
            return ""Hello World!"";
        }
    }
}";

                string expected =
                    "<div style=\"color:Black;background-color:White;\"><pre>\r\n<span style=\"color:Blue;\">using</span> System;\r\n\r\n<span style=\"color:Blue;\">namespace</span> TheNamespace\r\n{\r\n    <span style=\"color:Green;\">/* This is a comment */</span>\r\n    <span style=\"color:Blue;\">public</span> <span style=\"color:Blue;\">class</span><span style=\"color:MediumTurquoise;\"> TheClass\r\n        : TheBaseClass, Implements\r\n    </span>{\r\n        <span style=\"color:Blue;\">public</span> <span style=\"color:Blue;\">string</span> AMethod()\r\n        {\r\n            <span style=\"color:Blue;\">return</span> <span style=\"color:#A31515;\">&quot;Hello World!&quot;</span>;\r\n        }\r\n    }\r\n}\r\n</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.CSharp);

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
<span style=""color:Blue;"">public</span> <span style=""color:Blue;"">class</span><span style=""color:MediumTurquoise;""> TheClass : TheBaseClass
</span>{
}
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.CSharp);

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

                string actual = new CodeColorizer().Colorize(source, Languages.CSharp);

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

                string actual = new CodeColorizer().Colorize(source, Languages.CSharp);

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

                string actual = new CodeColorizer().Colorize(source, Languages.CSharp);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void TransformWillStyleClassName()
            {
                string source =
    @"public class ClassName 
{";
                string expected =
    @"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">public</span> <span style=""color:Blue;"">class</span><span style=""color:MediumTurquoise;""> ClassName 
</span>{
</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.CSharp);

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
public class Assert {";
                string expected =
                    "<div style=\"color:Black;background-color:White;\"><pre>\r\n<span style=\"color:Gray;\">///</span> <span style=\"color:Gray;\">&lt;summary&gt;</span>\r\n<span style=\"color:Gray;\">///</span><span style=\"color:Green;\"> Contains various static methods that are used to verify that conditions are met during the</span>\r\n<span style=\"color:Gray;\">///</span><span style=\"color:Green;\"> process of running tests.</span>\r\n<span style=\"color:Gray;\">///</span> <span style=\"color:Gray;\">&lt;/summary&gt;</span>\r\n<span style=\"color:Blue;\">public</span> <span style=\"color:Blue;\">class</span><span style=\"color:MediumTurquoise;\"> Assert </span>{\r\n</pre></div>";

                string actual = new CodeColorizer().Colorize(source, Languages.CSharp);

                Assert.Equal(expected, actual);
            }
        }
    }
}
