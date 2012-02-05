using System;
using System.Collections.Generic;
using System.Drawing;
using ColorCode.Common;
using ColorCode.Parsing;
using ColorCode.Stubs;
using ColorCode.Styling;
using ColorCode.Styling.StyleSheets;
using Xunit;

namespace ColorCode.Formatting
{
    public class HtmlFormatter_Class_Facts
    {
        public class WriterHeader_Method_Facts
        {
            [Fact]
            public void It_will_write_the_header_using_the_plain_text_colors()
            {
                HtmlFormatter formatter = new HtmlFormatter();
                StubStyleSheet stubStyleSheet = new StubStyleSheet { Name__getValue = "fnord", Styles__getValue = new StyleDictionary { new Style(ScopeName.PlainText) { Background = Color.White, Foreground = Color.Black } } };
                StubTextWriter stubTextWriter = new StubTextWriter();

                formatter.WriteHeader(stubStyleSheet, new StubLanguage(), stubTextWriter);

                Assert.Equal("<div style=\"color:Black;background-color:White;\"><pre>", stubTextWriter.Write__buffer);
            }

            [Fact]
            public void It_will_write_the_header_without_the_plain_text_colors_if_they_are_not_in_the_style_sheet()
            {
                HtmlFormatter formatter = new HtmlFormatter();
                StubStyleSheet stubStyleSheet = new StubStyleSheet { Name__getValue = "fnord", Styles__getValue = new StyleDictionary() };
                StubTextWriter stubTextWriter = new StubTextWriter();

                formatter.WriteHeader(stubStyleSheet, new StubLanguage(), stubTextWriter);

                Assert.Equal("<div><pre>", stubTextWriter.Write__buffer);
            }

            [Fact]
            public void It_will_write_the_header_with_just_the_foreground_color_if_that_is_all_that_is_in_the_style_sheet()
            {
                HtmlFormatter formatter = new HtmlFormatter();
                StubStyleSheet stubStyleSheet = new StubStyleSheet { Name__getValue = "fnord", Styles__getValue = new StyleDictionary { new Style(ScopeName.PlainText) { Foreground = Color.Black } } };
                StubTextWriter stubTextWriter = new StubTextWriter();

                formatter.WriteHeader(stubStyleSheet, new StubLanguage(), stubTextWriter);

                Assert.Equal("<div style=\"color:Black;\"><pre>", stubTextWriter.Write__buffer);
            }

            [Fact]
            public void It_will_write_the_header_with_just_the_background_color_if_that_is_all_that_is_in_the_style_sheet()
            {
                HtmlFormatter formatter = new HtmlFormatter();
                StubStyleSheet stubStyleSheet = new StubStyleSheet { Name__getValue = "fnord", Styles__getValue = new StyleDictionary { new Style(ScopeName.PlainText) { Background = Color.White } } };
                StubTextWriter stubTextWriter = new StubTextWriter();

                formatter.WriteHeader(stubStyleSheet, new StubLanguage(), stubTextWriter);

                Assert.Equal("<div style=\"background-color:White;\"><pre>", stubTextWriter.Write__buffer);
            }

            [Fact]
            public void It_will_throw_when_style_sheet_is_null()
            {
                HtmlFormatter formatter = new HtmlFormatter();

                Exception ex = Record.Exception(() => formatter.WriteHeader(null, new StubLanguage(), new StubTextWriter()));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("styleSheet", ((ArgumentNullException)ex).ParamName);
            }

            [Fact]
            public void It_will_throw_when_text_writer_is_null()
            {
                HtmlFormatter formatter = new HtmlFormatter();

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
                HtmlFormatter formatter = new HtmlFormatter();
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
                HtmlFormatter formatter = new HtmlFormatter();
                StubStyleSheet stubStyleSheet = new StubStyleSheet
                                                {
                                                    Name__getValue = "fnord", 
                                                    Styles__getValue = new StyleDictionary { new Style(ScopeName.Keyword) { Foreground = Color.Blue } }
                                                };
                StubTextWriter stubTextWriter = new StubTextWriter();
                List<Scope> scopes = new List<Scope> { new Scope(ScopeName.Keyword, 0, 5) };
                
                formatter.Write("false", scopes, stubStyleSheet, stubTextWriter);

                Assert.Equal("<span style=\"color:Blue;\">false</span>", stubTextWriter.Write__buffer);
            }

            [Fact]
            public void It_will_write_parsed_source_code_with_multiple_scopes()
            {
                HtmlFormatter formatter = new HtmlFormatter();
                StubStyleSheet stubStyleSheet = new StubStyleSheet
                {
                    Name__getValue = "fnord",
                    Styles__getValue = new StyleDictionary
                                       {
                                           new Style(ScopeName.Keyword) { Foreground = Color.Blue },
                                           new Style(ScopeName.String) { Foreground = DefaultStyleSheet.DullRed }
                                       }
                };
                StubTextWriter stubTextWriter = new StubTextWriter();
                List<Scope> scopes = new List<Scope>
                                     {
                                         new Scope(ScopeName.Keyword, 0, 4),
                                         new Scope(ScopeName.Keyword, 13, 5)
                                     };

                formatter.Write("bool fnord = false;", scopes, stubStyleSheet, stubTextWriter);

                Assert.Equal("<span style=\"color:Blue;\">bool</span> fnord = <span style=\"color:Blue;\">false</span>;", stubTextWriter.Write__buffer);
            }

            [Fact]
            public void It_will_write_encoded_HTML()
            {
                HtmlFormatter formatter = new HtmlFormatter();
                StubStyleSheet stubStyleSheet = new StubStyleSheet
                {
                    Name__getValue = "fnord",
                    Styles__getValue = new StyleDictionary { new Style(ScopeName.String) { Foreground = DefaultStyleSheet.DullRed } }
                };
                StubTextWriter stubTextWriter = new StubTextWriter();
                List<Scope> scopes = new List<Scope> { new Scope(ScopeName.String, 0, 10) };

                formatter.Write("\"a string\"", scopes, stubStyleSheet, stubTextWriter);

                Assert.Equal("<span style=\"color:#A31515;\">&quot;a string&quot;</span>", stubTextWriter.Write__buffer);
            }

            [Fact]
            public void It_will_write_parsed_source_code_with_nested_scopes()
            {
                HtmlFormatter formatter = new HtmlFormatter();
                StubStyleSheet stubStyleSheet = new StubStyleSheet
                {
                    Name__getValue = "fnord",
                    Styles__getValue = new StyleDictionary
                                       {
                                           new Style(ScopeName.String) { Foreground = DefaultStyleSheet.DullRed },
                                           new Style(ScopeName.HtmlEntity) { Foreground = Color.Red }
                                       }
                };
                StubTextWriter stubTextWriter = new StubTextWriter();
                List<Scope> scopes = new List<Scope>
                                     {
                                         new Scope(ScopeName.String, 0, 20)
                                     };
                scopes[0].AddChild(new Scope(ScopeName.HtmlEntity, 0,6));
                scopes[0].AddChild(new Scope(ScopeName.HtmlEntity, 14, 6));

                formatter.Write("&quot;a string&quot;", scopes, stubStyleSheet, stubTextWriter);

                Assert.Equal("<span style=\"color:#A31515;\"><span style=\"color:Red;\">&amp;quot;</span>a string<span style=\"color:Red;\">&amp;quot;</span></span>", stubTextWriter.Write__buffer);
            }

            [Fact]
            public void It_will_write_a_background_color_when_a_style_specifies_one()
            {
                HtmlFormatter formatter = new HtmlFormatter();
                StubStyleSheet stubStyleSheet = new StubStyleSheet
                {
                    Name__getValue = "fnord",
                    Styles__getValue = new StyleDictionary
                                       {
                                           new Style(ScopeName.Comment) { Foreground = Color.Green },
                                           new Style(ScopeName.HtmlServerSideScript) { Background = Color.Yellow }
                                       }
                };
                StubTextWriter stubTextWriter = new StubTextWriter();
                List<Scope> scopes = new List<Scope>
                                     {
                                         new Scope(ScopeName.HtmlServerSideScript, 0, 2),
                                         new Scope(ScopeName.Comment, 2, 15),
                                         new Scope(ScopeName.HtmlServerSideScript, 17, 2)
                                     };

                formatter.Write("<%-- a comment --%>", scopes, stubStyleSheet, stubTextWriter);

                Assert.Equal("<span style=\"background-color:Yellow;\">&lt;%</span><span style=\"color:Green;\">-- a comment --</span><span style=\"background-color:Yellow;\">%&gt;</span>", stubTextWriter.Write__buffer);
            }
        }

        public class WriterFooter_Method_Facts
        {
            [Fact]
            public void It_will_write_the_footer_using_the_plain_text_colors()
            {
                HtmlFormatter formatter = new HtmlFormatter();
                StubStyleSheet stubStyleSheet = new StubStyleSheet { Name__getValue = "fnord", Styles__getValue = new StyleDictionary { new Style(ScopeName.PlainText) { Background = Color.White, Foreground = Color.Black } } };
                StubTextWriter stubTextWriter = new StubTextWriter();

                formatter.WriteFooter(stubStyleSheet, new StubLanguage(), stubTextWriter);

                Assert.Equal("</pre></div>", stubTextWriter.Write__buffer);
            }

            [Fact]
            public void It_will_throw_when_style_sheet_is_null()
            {
                HtmlFormatter formatter = new HtmlFormatter();

                Exception ex = Record.Exception(() => formatter.WriteFooter(null, new StubLanguage(), new StubTextWriter()));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("styleSheet", ((ArgumentNullException)ex).ParamName);
            }

            [Fact]
            public void It_will_throw_when_text_writer_is_null()
            {
                HtmlFormatter formatter = new HtmlFormatter();

                Exception ex = Record.Exception(() => formatter.WriteFooter(new StubStyleSheet(), new StubLanguage(), null));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("textWriter", ((ArgumentNullException)ex).ParamName);
            }
        }
    }
}
