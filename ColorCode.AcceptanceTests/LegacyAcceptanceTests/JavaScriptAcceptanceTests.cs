using Xunit;

namespace ColorCode
{
    public class JavaScriptAcceptanceTests
    {
        [Fact]
        public void FileExtensionsWillIncludeJs()
        {
            ILanguage language = Languages.JavaScript;

            Assert.Contains("js", language.FileExtensions);
        }
        
        [Fact]
        public void TransformWillStyleVarStatement()
        {
            string source =
@"var variableName = new VariableType();";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">var</span> variableName = <span style=""color:#0000FF;"">new</span> VariableType();
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.JavaScript, StyleSheets.VisualStudio);

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
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">function</span> FunctionName(argOne, argTwo) {
    <span style=""color:#0000FF;"">return</span> argOne + argTwo;
}
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.JavaScript, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleDoubleQuotedString()
        {
            string source =
@"var variableName = ""aString"";";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">var</span> variableName = <span style=""color:#A31515;"">&quot;aString&quot;</span>;
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.JavaScript, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleSingleQuotedString()
        {
            string source =
@"var variableName = 'aString';";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">var</span> variableName = <span style=""color:#A31515;"">'aString'</span>;
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.JavaScript, StyleSheets.VisualStudio);

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
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#008000;"">/*
comment one
comment two
comment three
*/</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.JavaScript, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleLineCommentsAtStartOfLine()
        {
            string source = "// a comment.\r\n";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#008000;"">// a comment.</span>

</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.JavaScript, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleLineComments()
        {
            string source =
@"var variableName = new VariableType(); // a comment";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">var</span> variableName = <span style=""color:#0000FF;"">new</span> VariableType(); <span style=""color:#008000;"">// a comment</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.JavaScript, StyleSheets.VisualStudio);

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
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">if</span> (<span style=""color:#0000FF;"">typeof</span>(NameSpace)!=<span style=""color:#A31515;"">'undefined'</span> &amp;&amp; <span style=""color:#0000FF;"">typeof</span>(NameSpace.NestedNameSpace)!=<span style=""color:#A31515;"">'undefined'</span>)
    NameSpace.NestedNameSpace.ClassName.prototype.someMethod = <span style=""color:#0000FF;"">function</span> () {
        <span style=""color:#0000FF;"">return</span> <span style=""color:#0000FF;"">this</span>._someValue;
    }
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.JavaScript, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillNotAddColorToDollarSignMethod()
        {
            string source =
@"var variableName = $(""aString"");";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">var</span> variableName = $(<span style=""color:#A31515;"">&quot;aString&quot;</span>);
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.JavaScript, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }
    }
}