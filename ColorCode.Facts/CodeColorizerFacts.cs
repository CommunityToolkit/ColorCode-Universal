using System;
using System.Collections.Generic;
using ColorCode.Parsing;
using ColorCode.Stubs;
using Xunit;

namespace ColorCode
{
    public class CodeColorizerFacts
    {
        public class The_constructor
        {
            [Fact]
            public void Will_throw_if_the_language_parser_is_null()
            {
                // no arrange

                Exception ex = Record.Exception(() => new CodeColorizer(null));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("languageParser", ((ArgumentNullException)ex).ParamName);
            }
        }
        
        public class The_Colorize_method
        {
            [Fact]
            public void Will_write_the_header()
            {
                StubLanguageParser stubLanguageParser = new StubLanguageParser();
                CodeColorizer codeColorizer = new CodeColorizer(stubLanguageParser);
                const string sourceCode = "fnord";
                StubFormatter stubFormatter = new StubFormatter();
                StubStyleSheet stubStyleSheet = new StubStyleSheet();
                StubTextWriter stubTextWriter = new StubTextWriter();

                codeColorizer.Colorize(sourceCode, new StubLanguage(), stubFormatter, stubStyleSheet, stubTextWriter);

                Assert.Equal(stubTextWriter, stubFormatter.WriteHeader__textWriter);
                Assert.Equal(stubStyleSheet, stubFormatter.WriteHeader__styleSheet);
            }

            [Fact]
            public void Will_parse_the_source_code()
            {
                StubLanguageParser stubLanguageParser = new StubLanguageParser();
                CodeColorizer codeColorizer = new CodeColorizer(stubLanguageParser);
                const string sourceCode = "fnord";
                StubLanguage stubLanguage = new StubLanguage();

                codeColorizer.Colorize(sourceCode, stubLanguage, new StubFormatter(), new StubStyleSheet(), new StubTextWriter());

                Assert.Equal(sourceCode, stubLanguageParser.Parse__sourceCode);
                Assert.Equal(stubLanguage, stubLanguageParser.Parse__language);
            }

            [Fact]
            public void Will_write_the_parsed_source_code()
            {
                StubLanguageParser languageParser = new StubLanguageParser();
                languageParser.Parse__do = (sourceCodeToParse, language, parsedSourceCodeHandler) =>
                {
                    parsedSourceCodeHandler("parsedSourceCode1", new List<Scope>()); 
                    parsedSourceCodeHandler("parsedSourceCode2", new List<Scope>());
                };
                CodeColorizer codeColorizer = new CodeColorizer(languageParser);
                const string sourceCode = "fnord";
                StubFormatter formatter = new StubFormatter();

                codeColorizer.Colorize(sourceCode, new StubLanguage(), formatter, new StubStyleSheet(), new StubTextWriter());

                Assert.Equal("parsedSourceCode2", formatter.Write__parsedSourceCode.Pop());
                Assert.Equal("parsedSourceCode1", formatter.Write__parsedSourceCode.Pop());
            }

            [Fact]
            public void Will_write_the_parsed_source_code_using_the_defaults()
            {
                CodeColorizer codeColorizer = new CodeColorizer();
                const string sourceCode = "fnord";
                StubTextWriter textWriter = new StubTextWriter();

                codeColorizer.Colorize(sourceCode, Languages.Html, textWriter);

                Assert.Contains("fnord", textWriter.Write__buffer);
            }

            [Fact]
            public void Will_write_the_parsed_source_code_using_the_defaults_without_the_textwriter()
            {
                CodeColorizer codeColorizer = new CodeColorizer();
                const string sourceCode = "fnord";
                StubTextWriter textWriter = new StubTextWriter();

                string output = codeColorizer.Colorize(sourceCode, Languages.Html);

                Assert.Contains("fnord", output);
            }

            [Fact]
            public void Will_write_the_footer()
            {
                StubLanguageParser languageParser = new StubLanguageParser();
                CodeColorizer codeColorizer = new CodeColorizer(languageParser);
                const string sourceCode = "fnord";
                StubFormatter formatter = new StubFormatter();
                StubStyleSheet styleSheet = new StubStyleSheet();
                StubTextWriter writer = new StubTextWriter();

                codeColorizer.Colorize(sourceCode, new StubLanguage(), formatter, styleSheet, writer);

                Assert.Equal(writer, formatter.WriteFooter__writer);
                Assert.Equal(styleSheet, formatter.WriteFooter__styleSheet);
            }

            [Fact]
            public void Will_throw_if_the_language_is_null()
            {
                CodeColorizer codeColorizer = new CodeColorizer(new StubLanguageParser());

                Exception ex = Record.Exception(() => codeColorizer.Colorize(string.Empty, null, new StubFormatter(), new StubStyleSheet(), new StubTextWriter()));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("language", ((ArgumentNullException)ex).ParamName);
            }

            [Fact]
            public void Will_throw_if_the_language_is_null_using_defaults()
            {
                CodeColorizer codeColorizer = new CodeColorizer();

                Exception ex = Record.Exception(() => codeColorizer.Colorize(string.Empty, null, new StubTextWriter()));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("language", ((ArgumentNullException)ex).ParamName);
            }

            [Fact]
            public void Will_throw_if_the_language_is_null_using_defaults_without_text_writer()
            {
                CodeColorizer codeColorizer = new CodeColorizer();

                Exception ex = Record.Exception(() => codeColorizer.Colorize(string.Empty, null));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("language", ((ArgumentNullException)ex).ParamName);
            }

            [Fact]
            public void Will_throw_if_the_formatter_is_null()
            {
                CodeColorizer codeColorizer = new CodeColorizer(new StubLanguageParser());

                Exception ex = Record.Exception(() => codeColorizer.Colorize(string.Empty, new StubLanguage(), null, new StubStyleSheet(), new StubTextWriter()));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("formatter", ((ArgumentNullException)ex).ParamName);
            }

            [Fact]
            public void Will_throw_if_the_style_sheet_is_null()
            {
                CodeColorizer codeColorizer = new CodeColorizer(new StubLanguageParser());

                Exception ex = Record.Exception(() => codeColorizer.Colorize(string.Empty, new StubLanguage(), new StubFormatter(), null, new StubTextWriter()));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("styleSheet", ((ArgumentNullException)ex).ParamName);
            }

            [Fact]
            public void Will_throw_if_the_text_writer_is_null()
            {
                CodeColorizer codeColorizer = new CodeColorizer(new StubLanguageParser());

                Exception ex = Record.Exception(() => codeColorizer.Colorize(string.Empty, new StubLanguage(), new StubFormatter(), new StubStyleSheet(), null));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("textWriter", ((ArgumentNullException)ex).ParamName);
            }

            [Fact]
            public void Will_throw_if_the_text_writer_is_null_using_defaults()
            {
                CodeColorizer codeColorizer = new CodeColorizer();

                Exception ex = Record.Exception(() => codeColorizer.Colorize(string.Empty, new StubLanguage(), null));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("textWriter", ((ArgumentNullException)ex).ParamName);
            }
        }
    }
}