using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ColorCode.Stubs;
using Xunit;

namespace ColorCode.Compilation
{
    public class LanguageCompiler_Class_Facts
    {
        public class Compile_Method_Facts
        {
            [Fact]
            public void It_will_use_the_language_identifier_for_the_compiled_language_identifier()
            {
                Dictionary<string, CompiledLanguage> stubCompiledLanguagesCache = new Dictionary<string, CompiledLanguage>();
                LanguageCompiler languageCompiler = new LanguageCompiler(stubCompiledLanguagesCache);
                StubLanguage stubLanguage = new StubLanguage();
                stubLanguage.id__getValue = "theLanguageId";
                stubLanguage.name__getValue = "fnord";
                stubLanguage.rules__getValue = new List<LanguageRule> { new LanguageRule("fnord", new Dictionary<int, string> { {0, "fnord"} })};

                CompiledLanguage compiledLanguage = languageCompiler.Compile(stubLanguage);

                Assert.Equal("theLanguageId", compiledLanguage.Id);
            }

            [Fact]
            public void It_will_use_the_language_name_for_the_compiled_language_name()
            {
                Dictionary<string, CompiledLanguage> stubCompiledLanguagesCache = new Dictionary<string, CompiledLanguage>();
                LanguageCompiler languageCompiler = new LanguageCompiler(stubCompiledLanguagesCache);
                StubLanguage stubLanguage = new StubLanguage();
                stubLanguage.id__getValue = "fnord";
                stubLanguage.name__getValue = "The Language ScopeName";
                stubLanguage.rules__getValue = new List<LanguageRule> { new LanguageRule("fnord", new Dictionary<int, string> { {0, "fnord"} })};

                CompiledLanguage compiledLanguage = languageCompiler.Compile(stubLanguage);

                Assert.Equal("The Language ScopeName", compiledLanguage.Name);
            }

            [Fact]
            public void It_will_compile_a_single_language_rule_with_a_whole_capture()
            {
                Dictionary<string, CompiledLanguage> stubCompiledLanguagesCache = new Dictionary<string, CompiledLanguage>();
                LanguageCompiler languageCompiler = new LanguageCompiler(stubCompiledLanguagesCache);
                StubLanguage stubLanguage = new StubLanguage();
                stubLanguage.id__getValue = "fnord";
                stubLanguage.name__getValue = "fnord";
                stubLanguage.rules__getValue = new List<LanguageRule> { new LanguageRule("a language rule", new Dictionary<int, string> { { 0, "style for whole rule" } }) };

                CompiledLanguage compiledLanguage = languageCompiler.Compile(stubLanguage);

                Assert.Equal(@"(?x)
(?-xis)(?m)(a language rule)(?x)", compiledLanguage.Regex.ToString());
                Assert.Null(compiledLanguage.Captures[0]);
                Assert.Equal("style for whole rule", compiledLanguage.Captures[1]);
            }

            [Fact]
            public void It_will_compile_a_single_language_rule_with_partial_captures()
            {
                Dictionary<string, CompiledLanguage> stubCompiledLanguagesCache = new Dictionary<string, CompiledLanguage>();
                LanguageCompiler languageCompiler = new LanguageCompiler(stubCompiledLanguagesCache);
                StubLanguage stubLanguage = new StubLanguage();
                stubLanguage.id__getValue = "fnord";
                stubLanguage.name__getValue = "fnord";
                stubLanguage.rules__getValue = new List<LanguageRule>
                                         {
                                             new LanguageRule("(a) (language) (rule)", new Dictionary<int, string>
                                                                                       {
                                                                                           { 1, "style for the a part" },
                                                                                           { 2, "style for the language part" },
                                                                                           { 3, "style for the rule part" }
                                                                                       })
                                         };

                CompiledLanguage compiledLanguage = languageCompiler.Compile(stubLanguage);

                Assert.Equal(@"(?x)
(?-xis)(?m)((a) (language) (rule))(?x)", compiledLanguage.Regex.ToString());
                Assert.Null(compiledLanguage.Captures[0]);
                Assert.Null(compiledLanguage.Captures[1]);
                Assert.Equal("style for the a part", compiledLanguage.Captures[2]);
                Assert.Equal("style for the language part", compiledLanguage.Captures[3]);
                Assert.Equal("style for the rule part", compiledLanguage.Captures[4]);
            }

            [Fact]
            public void It_will_compile_a_single_language_rule_with_a_whole_capture_and_partial_captures()
            {
                Dictionary<string, CompiledLanguage> stubCompiledLanguagesCache = new Dictionary<string, CompiledLanguage>();
                LanguageCompiler languageCompiler = new LanguageCompiler(stubCompiledLanguagesCache);
                StubLanguage stubLanguage = new StubLanguage();
                stubLanguage.id__getValue = "fnord";
                stubLanguage.name__getValue = "fnord";
                stubLanguage.rules__getValue = new List<LanguageRule>
                                         {
                                             new LanguageRule("(a) (language) (rule)", new Dictionary<int, string>
                                                                                       {
                                                                                           { 0, "style for whole rule" },
                                                                                           { 1, "style for the a part" },
                                                                                           { 2, "style for the language part" },
                                                                                           { 3, "style for the rule part" }
                                                                                       })
                                         };

                CompiledLanguage compiledLanguage = languageCompiler.Compile(stubLanguage);

                Assert.Equal(@"(?x)
(?-xis)(?m)((a) (language) (rule))(?x)", compiledLanguage.Regex.ToString());
                Assert.Null(compiledLanguage.Captures[0]);
                Assert.Equal("style for whole rule", compiledLanguage.Captures[1]);
                Assert.Equal("style for the a part", compiledLanguage.Captures[2]);
                Assert.Equal("style for the language part", compiledLanguage.Captures[3]);
                Assert.Equal("style for the rule part", compiledLanguage.Captures[4]);
            }

            [Fact]
            public void It_will_compile_multiple_language_rules()
            {
                Dictionary<string, CompiledLanguage> stubCompiledLanguagesCache = new Dictionary<string, CompiledLanguage>();
                LanguageCompiler languageCompiler = new LanguageCompiler(stubCompiledLanguagesCache);
                StubLanguage stubLanguage = new StubLanguage();
                stubLanguage.id__getValue = "fnord";
                stubLanguage.name__getValue = "fnord";
                stubLanguage.rules__getValue = new List<LanguageRule>
                                         {
                                             new LanguageRule("(a) (language) (rule)", new Dictionary<int, string>
                                                                                       {
                                                                                           { 0, "style for whole rule" },
                                                                                           { 1, "style for the a part" },
                                                                                           { 2, "style for the language part" },
                                                                                           { 3, "style for the rule part" }
                                                                                       }),
                                             new LanguageRule("a (second) language rule", new Dictionary<int, string>
                                                                                       {
                                                                                           { 1, "style for the second part" }
                                                                                       })
                                         };

                CompiledLanguage compiledLanguage = languageCompiler.Compile(stubLanguage);

                Assert.Equal(@"(?x)
(?-xis)(?m)((a) (language) (rule))(?x)

|

(?-xis)(?m)(a (second) language rule)(?x)", compiledLanguage.Regex.ToString());
                Assert.Null(compiledLanguage.Captures[0]);
                Assert.Equal("style for whole rule", compiledLanguage.Captures[1]);
                Assert.Equal("style for the a part", compiledLanguage.Captures[2]);
                Assert.Equal("style for the language part", compiledLanguage.Captures[3]);
                Assert.Equal("style for the rule part", compiledLanguage.Captures[4]);
                Assert.Null(compiledLanguage.Captures[5]);
                Assert.Equal("style for the second part", compiledLanguage.Captures[6]);
            }

            [Fact]
            public void It_will_retrieve_a_previously_compiled_language_from_the_cache_when_one_is_there()
            {
                Dictionary<string, CompiledLanguage> stubCompiledLanguagesCache = new Dictionary<string, CompiledLanguage>();
                CompiledLanguage stubCompiledLanguage = new CompiledLanguage("theLanguageId", "fnord", new Regex("fnord"), new List<string>{ "fnord" });
                stubCompiledLanguagesCache.Add(stubCompiledLanguage.Id, stubCompiledLanguage);
                LanguageCompiler languageCompiler = new LanguageCompiler(stubCompiledLanguagesCache);
                StubLanguage stubLanguage = new StubLanguage();
                stubLanguage.id__getValue = "theLanguageId";
                stubLanguage.name__getValue = "fnord";
                stubLanguage.rules__getValue = new List<LanguageRule> { new LanguageRule("fnord", new Dictionary<int, string> { {0, "fnord"} })};

                CompiledLanguage compiledLanguage = languageCompiler.Compile(stubLanguage);

                Assert.Equal("theLanguageId", compiledLanguage.Id);
                Assert.False(stubLanguage.Name__getInvoked);
                Assert.False(stubLanguage.Rules__getInvoked);
            }

            [Fact]
            public void It_will_throw_when_the_rules_collection_is_null()
            {
                Dictionary<string, CompiledLanguage> stubCompiledLanguagesCache = new Dictionary<string, CompiledLanguage>();
                LanguageCompiler languageCompiler = new LanguageCompiler(stubCompiledLanguagesCache);
                StubLanguage stubLanguage = new StubLanguage();
                stubLanguage.id__getValue = "fnord";
                stubLanguage.name__getValue = "fnord";
                stubLanguage.rules__getValue = null;

                Exception ex = Record.Exception(() => languageCompiler.Compile(stubLanguage));

                Assert.IsType<ArgumentException>(ex);
                Assert.Contains("The language rules collection must not be empty.", ex.Message);
                Assert.Equal("language", ((ArgumentException)ex).ParamName);
            }

            [Fact]
            public void It_will_throw_when_the_language_is_null()
            {
                Dictionary<string, CompiledLanguage> stubCompiledLanguagesCache = new Dictionary<string, CompiledLanguage>();
                LanguageCompiler languageCompiler = new LanguageCompiler(stubCompiledLanguagesCache);

                Exception ex = Record.Exception(() => languageCompiler.Compile(null));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("language", ((ArgumentNullException)ex).ParamName);
            }

            [Fact]
            public void It_will_throw_when_the_language_identifier_is_null()
            {
                Dictionary<string, CompiledLanguage> stubCompiledLanguagesCache = new Dictionary<string, CompiledLanguage>();
                LanguageCompiler languageCompiler = new LanguageCompiler(stubCompiledLanguagesCache);
                StubLanguage stubLanguage = new StubLanguage();
                stubLanguage.id__getValue = null;
                stubLanguage.name__getValue = "fnord";
                stubLanguage.rules__getValue = new List<LanguageRule> { new LanguageRule("fnord", new Dictionary<int, string> { {0, "fnord"} })};

                Exception ex = Record.Exception(() => languageCompiler.Compile(stubLanguage));

                Assert.IsType<ArgumentException>(ex);
                Assert.Contains("The language identifier must not be null.", ex.Message);
                Assert.Equal("language", ((ArgumentException)ex).ParamName);
            }

            [Fact]
            public void It_will_throw_when_the_language_identifier_is_empty()
            {
                Dictionary<string, CompiledLanguage> stubCompiledLanguagesCache = new Dictionary<string, CompiledLanguage>();
                LanguageCompiler languageCompiler = new LanguageCompiler(stubCompiledLanguagesCache);
                StubLanguage stubLanguage = new StubLanguage();
                stubLanguage.id__getValue = string.Empty;
                stubLanguage.name__getValue = "fnord";
                stubLanguage.rules__getValue = new List<LanguageRule> { new LanguageRule("fnord", new Dictionary<int, string> { {0, "fnord"} })};

                Exception ex = Record.Exception(() => languageCompiler.Compile(stubLanguage));

                Assert.IsType<ArgumentException>(ex);
                Assert.Contains("The language identifier must not be null.", ex.Message);
                Assert.Equal("language", ((ArgumentException)ex).ParamName);
            }

            [Fact]
            public void It_will_throw_when_the_language_is_not_in_cach_and_the_name_is_empty()
            {
                Dictionary<string, CompiledLanguage> stubCompiledLanguagesCache = new Dictionary<string, CompiledLanguage>();
                LanguageCompiler languageCompiler = new LanguageCompiler(stubCompiledLanguagesCache);
                StubLanguage stubLanguage = new StubLanguage();
                stubLanguage.id__getValue = "fnord";
                stubLanguage.name__getValue = string.Empty;
                stubLanguage.rules__getValue = new List<LanguageRule> { new LanguageRule("fnord", new Dictionary<int, string> { {0, "fnord"} })};

                Exception ex = Record.Exception(() => languageCompiler.Compile(stubLanguage));

                Assert.IsType<ArgumentException>(ex);
                Assert.Contains("The language name must not be null or empty.", ex.Message);
                Assert.Equal("language", ((ArgumentException)ex).ParamName);
            }

            [Fact]
            public void It_will_throw_when_the_language_is_not_in_cach_and_the_rules_collection_is_empty()
            {
                Dictionary<string, CompiledLanguage> stubCompiledLanguagesCache = new Dictionary<string, CompiledLanguage>();
                LanguageCompiler languageCompiler = new LanguageCompiler(stubCompiledLanguagesCache);
                StubLanguage stubLanguage = new StubLanguage();
                stubLanguage.id__getValue = "fnord";
                stubLanguage.name__getValue = "fnord";
                stubLanguage.rules__getValue = new List<LanguageRule>();

                Exception ex = Record.Exception(() => languageCompiler.Compile(stubLanguage));

                Assert.IsType<ArgumentException>(ex);
                Assert.Contains("The language rules collection must not be empty.", ex.Message);
                Assert.Equal("language", ((ArgumentException)ex).ParamName);
            }
        }
    }
}
