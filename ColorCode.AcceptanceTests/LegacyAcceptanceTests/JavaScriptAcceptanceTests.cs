using Xunit;

namespace ColorCode
{
    public class JavaScriptAcceptanceTests
    {
        [Fact]
        public void TransformWillStyleVarStatement()
        {
            string source =
@"var variableName = new VariableType();";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">var</span> variableName = <span style=""color:Blue;"">new</span> VariableType();
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.JavaScript);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleFunctionStatement()
        {
            string source =
@"function FunctionName(argOne, argTwo) {
    return argOne + argTwo;
}";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">function</span> FunctionName(argOne, argTwo) {
    <span style=""color:Blue;"">return</span> argOne + argTwo;
}
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.JavaScript);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleDoubleQuotedString()
        {
            string source =
@"var variableName = ""aString"";";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">var</span> variableName = <span style=""color:#A31515;"">&quot;aString&quot;</span>;
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.JavaScript);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleSingleQuotedString()
        {
            string source =
@"var variableName = 'aString';";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">var</span> variableName = <span style=""color:#A31515;"">'aString'</span>;
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.JavaScript);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleCommentBlocks()
        {
            string source =
@"/*
comment one
comment two
comment three
*/";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Green;"">/*
comment one
comment two
comment three
*/</span>
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.JavaScript);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleLineCommentsAtStartOfLine()
        {
            string source = "// a comment.\r\n";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Green;"">// a comment.</span>

</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.JavaScript);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleLineComments()
        {
            string source =
@"var variableName = new VariableType(); // a comment";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">var</span> variableName = <span style=""color:Blue;"">new</span> VariableType(); <span style=""color:Green;"">// a comment</span>
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.JavaScript);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStylePrototypeOverride()
        {
            string source =
@"if (typeof(NameSpace)!='undefined' && typeof(NameSpace.NestedNameSpace)!='undefined')
    NameSpace.NestedNameSpace.ClassName.prototype.someMethod = function () {
        return this._someValue;
    }";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">if</span> (<span style=""color:Blue;"">typeof</span>(NameSpace)!=<span style=""color:#A31515;"">'undefined'</span> &amp;&amp; <span style=""color:Blue;"">typeof</span>(NameSpace.NestedNameSpace)!=<span style=""color:#A31515;"">'undefined'</span>)
    NameSpace.NestedNameSpace.ClassName.prototype.someMethod = <span style=""color:Blue;"">function</span> () {
        <span style=""color:Blue;"">return</span> <span style=""color:Blue;"">this</span>._someValue;
    }
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.JavaScript);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillNotAddColorToDollarSignMethod()
        {
            string source =
@"var variableName = $(""aString"");";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">var</span> variableName = $(<span style=""color:#A31515;"">&quot;aString&quot;</span>);
</pre></div>";

            string actual = ColorCode.Colorize(source, Languages.JavaScript);

            Assert.Equal(expected, actual);
        }
    }
}