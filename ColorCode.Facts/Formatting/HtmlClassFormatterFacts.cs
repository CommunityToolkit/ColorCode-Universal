using System;
using System.Collections.Generic;
using System.Drawing;
using ColorCode.Common;
using ColorCode.Parsing;
using ColorCode.Stubs;
using Xunit;

namespace ColorCode.Formatting
{
    public class HtmlClassFormatter_Class_Facts
    {
        public class WriterHeader_Method_Facts
        {
            [Fact]
            public void It_will_write_the_language_name_into_the_header()
            {
                HtmlClassFormatter formatter = new HtmlClassFormatter();

                StubStyleSheet stubStyleSheet = new StubStyleSheet { Name__getValue = "fnord", Styles__getValue = new StyleDictionary { } };
                StubLanguage language = new StubLanguage { CssClassName_getValue = "fnord" };
                StubTextWriter stubTextWriter = new StubTextWriter();

                formatter.WriteHeader(stubStyleSheet, language, stubTextWriter);

                Assert.Equal("<div class=\"fnord\"><pre>", stubTextWriter.Write__buffer);
            }

            [Fact]
            public void It_will_write_the_header_with_no_class_name_if_language_does_not_specify_one()
            {
                HtmlClassFormatter formatter = new HtmlClassFormatter();
                StubStyleSheet stubStyleSheet = new StubStyleSheet { Name__getValue = "fnord", Styles__getValue = new StyleDictionary() };
                StubLanguage stubLanguage = new StubLanguage { CssClassName_getValue = "" };
                StubTextWriter stubTextWriter = new StubTextWriter();

                formatter.WriteHeader(stubStyleSheet, stubLanguage, stubTextWriter);

                Assert.Equal("<div><pre>", stubTextWriter.Write__buffer);
            }

            [Fact]
            public void It_will_throw_when_style_sheet_is_null()
            {
                HtmlClassFormatter formatter = new HtmlClassFormatter();

                Exception ex = Record.Exception(() => formatter.WriteHeader(null, new StubLanguage(), new StubTextWriter()));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("styleSheet", ((ArgumentNullException)ex).ParamName);
            }

            [Fact]
            public void It_will_throw_when_language_is_null()
            {
                HtmlClassFormatter formatter = new HtmlClassFormatter();

                Exception ex = Record.Exception(() => formatter.WriteHeader(new StubStyleSheet(), null, new StubTextWriter()));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("language", ((ArgumentNullException)ex).ParamName);
            }

            [Fact]
            public void It_will_throw_when_text_writer_is_null()
            {
                HtmlClassFormatter formatter = new HtmlClassFormatter();

                Exception ex = Record.Exception(() => formatter.WriteHeader(new StubStyleSheet(), new StubLanguage(), null));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("textWriter", ((ArgumentNullException)ex).ParamName);
            }
        }

        public class Write_Method_Facts
        {
            [Fact]
            public void It_will_write_parsed_source_code_with_no_scopes()
            {
                HtmlClassFormatter formatter = new HtmlClassFormatter();
                StubStyleSheet stubStyleSheet = new StubStyleSheet
                                                {
                                                    Name__getValue = "fnord",
                                                    Styles__getValue = new StyleDictionary { new Style(ScopeName.PlainText) { Background = Color.White, Foreground = Color.Black } }
                                                };
                StubTextWriter stubTextWriter = new StubTextWriter();

                formatter.Write("the source code", new List<Scope>(), stubStyleSheet, stubTextWriter);

                Assert.Equal("the source code", stubTextWriter.Write__buffer);
            }

            [Fact]
            public void It_will_write_parsed_source_code_with_a_single_scope()
            {
                HtmlClassFormatter formatter = new HtmlClassFormatter();
                StubStyleSheet stubStyleSheet = new StubStyleSheet
                                                {
                                                    Name__getValue = "fnord",
                                                    Styles__getValue = new StyleDictionary { new Style(ScopeName.Keyword) { CssClassName = "keyword" } }
                                                };
                StubTextWriter stubTextWriter = new StubTextWriter();
                List<Scope> scopes = new List<Scope> { new Scope(ScopeName.Keyword, 0, 5) };

                formatter.Write("false", scopes, stubStyleSheet, stubTextWriter);

                Assert.Equal("<span class=\"keyword\">false</span>", stubTextWriter.Write__buffer);
            }

            [Fact]
            public void It_will_write_parsed_source_code_with_multiple_scopes()
            {
                HtmlClassFormatter formatter = new HtmlClassFormatter();
                StubStyleSheet stubStyleSheet = new StubStyleSheet
                {
                    Name__getValue = "fnord",
                    Styles__getValue = new StyleDictionary
                                       {
                                           new Style(ScopeName.Keyword) { CssClassName = "keyword" },
                                           new Style(ScopeName.String) { CssClassName = "string" }
                                       }
                };
                StubTextWriter stubTextWriter = new StubTextWriter();
                List<Scope> scopes = new List<Scope>
                                     {
                                         new Scope(ScopeName.Keyword, 0, 4),
                                         new Scope(ScopeName.Keyword, 13, 5)
                                     };

                formatter.Write("bool fnord = false;", scopes, stubStyleSheet, stubTextWriter);

                Assert.Equal("<span class=\"keyword\">bool</span> fnord = <span class=\"keyword\">false</span>;", stubTextWriter.Write__buffer);
            }

            [Fact]
            public void It_will_write_encoded_HTML()
            {
                HtmlClassFormatter formatter = new HtmlClassFormatter();
                StubStyleSheet stubStyleSheet = new StubStyleSheet
                {
                    Name__getValue = "fnord",
                    Styles__getValue = new StyleDictionary { new Style(ScopeName.String) { CssClassName = "string" } }
                };
                StubTextWriter stubTextWriter = new StubTextWriter();
                List<Scope> scopes = new List<Scope> { new Scope(ScopeName.String, 0, 10) };

                formatter.Write("\"a string\"", scopes, stubStyleSheet, stubTextWriter);

                Assert.Equal("<span class=\"string\">&quot;a string&quot;</span>", stubTextWriter.Write__buffer);
            }

            [Fact]
            public void It_will_write_parsed_source_code_with_nested_scopes()
            {
                HtmlClassFormatter formatter = new HtmlClassFormatter();
                StubStyleSheet stubStyleSheet = new StubStyleSheet
                {
                    Name__getValue = "fnord",
                    Styles__getValue = new StyleDictionary
                                       {
                                           new Style(ScopeName.String) { CssClassName = "string" },
                                           new Style(ScopeName.HtmlEntity) { CssClassName = "htmlEntity" }
                                       }
                };
                StubTextWriter stubTextWriter = new StubTextWriter();
                List<Scope> scopes = new List<Scope>
                                     {
                                         new Scope(ScopeName.String, 0, 20)
                                     };
                scopes[0].AddChild(new Scope(ScopeName.HtmlEntity, 0, 6));
                scopes[0].AddChild(new Scope(ScopeName.HtmlEntity, 14, 6));

                formatter.Write("&quot;a string&quot;", scopes, stubStyleSheet, stubTextWriter);

                Assert.Equal("<span class=\"string\"><span class=\"htmlEntity\">&amp;quot;</span>a string<span class=\"htmlEntity\">&amp;quot;</span></span>", stubTextWriter.Write__buffer);
            }
        }

        public class WriterFooter_Method_Facts
        {
            [Fact]
            public void It_will_write_the_footer()
            {
                HtmlClassFormatter formatter = new HtmlClassFormatter();
                StubStyleSheet stubStyleSheet = new StubStyleSheet { Name__getValue = "fnord", Styles__getValue = new StyleDictionary { } };
                StubLanguage stubLanguage = new StubLanguage { CssClassName_getValue = "fnord" };
                StubTextWriter stubTextWriter = new StubTextWriter();

                formatter.WriteFooter(stubStyleSheet, stubLanguage, stubTextWriter);

                Assert.Equal("</pre></div>", stubTextWriter.Write__buffer);
            }

            [Fact]
            public void It_will_throw_when_style_sheet_is_null()
            {
                HtmlClassFormatter formatter = new HtmlClassFormatter();

                Exception ex = Record.Exception(() => formatter.WriteFooter(null, new StubLanguage(), new StubTextWriter()));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("styleSheet", ((ArgumentNullException)ex).ParamName);
            }

            [Fact]
            public void It_will_throw_when_language_is_null()
            {
                HtmlClassFormatter formatter = new HtmlClassFormatter();

                Exception ex = Record.Exception(() => formatter.WriteFooter(new StubStyleSheet(), null, new StubTextWriter()));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("language", ((ArgumentNullException)ex).ParamName);
            }

            [Fact]
            public void It_will_throw_when_text_writer_is_null()
            {
                HtmlClassFormatter formatter = new HtmlClassFormatter();

                Exception ex = Record.Exception(() => formatter.WriteFooter(new StubStyleSheet(), new StubLanguage(), null));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("textWriter", ((ArgumentNullException)ex).ParamName);
            }
        }
    }
}
