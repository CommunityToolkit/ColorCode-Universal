using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ColorCode.Compilation;
using ColorCode.Stubs;
using Xunit;

namespace ColorCode.Parsing
{
    public class LanguageParser_Facts
    {
        public class Parse_Method_Facts
        {
            [Fact]
            public void It_will_not_parse_empty_source_code()
            {
                StubLanguageCompiler stubLanguageCompiler = new StubLanguageCompiler();
                stubLanguageCompiler.Compile__return = new CompiledLanguage("fnord", "fnord", new Regex("fnord"), new List<string> { "fnord" });
                LanguageParser languageParser = new LanguageParser(stubLanguageCompiler, new StubLanguageRepository());
                StubLanguage stubLanguage = new StubLanguage();
                string sourceCode = string.Empty;
                int parseHandlerInvocations = 0;

                languageParser.Parse(sourceCode, stubLanguage, (parsedSourceCode, scopes) =>
                {
                    parseHandlerInvocations++;
                });

                Assert.Equal(0, parseHandlerInvocations);
            }

            [Fact]
            public void It_will_yield_source_code_with_no_matches()
            {
                StubLanguageCompiler stubLanguageCompiler = new StubLanguageCompiler();
                stubLanguageCompiler.Compile__return = new CompiledLanguage("fnord", "fnord", new Regex("this won't match the source code"), new List<string> { "fnord" });
                LanguageParser languageParser = new LanguageParser(stubLanguageCompiler, new StubLanguageRepository());
                StubLanguage stubLanguage = new StubLanguage();
                const string sourceCode = "source code that won't be matched";
                int parseHandlerInvocations = 0;
                Stack<string> parsedSourceCodeStack = new Stack<string>();
                Stack<IList<Scope>> scopesStack = new Stack<IList<Scope>>();

                languageParser.Parse(sourceCode, stubLanguage, (parsedSourceCode, scopes) =>
                {
                    parseHandlerInvocations++;
                    parsedSourceCodeStack.Push(parsedSourceCode);
                    scopesStack.Push(scopes);
                });

                Assert.Equal(1, parseHandlerInvocations);
                string firstParsedSourceCode = parsedSourceCodeStack.Pop();
                IList<Scope> firstScopes = scopesStack.Pop();
                Assert.Equal("source code that won't be matched", firstParsedSourceCode);
                Assert.Empty(firstScopes);
            }

            [Fact]
            public void It_will_yield_wholly_matched_parsed_source_code()
            {
                StubLanguageCompiler stubLanguageCompiler = new StubLanguageCompiler();
                stubLanguageCompiler.Compile__return = new CompiledLanguage("fnord", "fnord", new Regex(".*"), new List<string> { "A Scope Name" });
                LanguageParser languageParser = new LanguageParser(stubLanguageCompiler, new StubLanguageRepository());
                StubLanguage stubLanguage = new StubLanguage();
                const string sourceCode = "source code that will be matched";
                int parseHandlerInvocations = 0;
                Stack<string> parsedSourceCodeStack = new Stack<string>();
                Stack<IList<Scope>> scopesStack = new Stack<IList<Scope>>();

                languageParser.Parse(sourceCode, stubLanguage, (parsedSourceCode, scopes) =>
                {
                    parseHandlerInvocations++;
                    parsedSourceCodeStack.Push(parsedSourceCode);
                    scopesStack.Push(scopes);
                });

                Assert.Equal(1, parseHandlerInvocations);
                string firstParsedSourceCode = parsedSourceCodeStack.Pop();
                IList<Scope> firstScopes = scopesStack.Pop();
                Assert.Equal("source code that will be matched", firstParsedSourceCode);
                Assert.Equal("A Scope Name", firstScopes[0].Name);
            }

            [Fact]
            public void It_will_yield_partially_matched_source_code_and_the_unmatched_source_code_after_it()
            {
                StubLanguageCompiler stubLanguageCompiler = new StubLanguageCompiler();
                stubLanguageCompiler.Compile__return = new CompiledLanguage("fnord", "fnord", new Regex("source code"), new List<string> { "A Scope Name" });
                LanguageParser languageParser = new LanguageParser(stubLanguageCompiler, new StubLanguageRepository());
                StubLanguage stubLanguage = new StubLanguage();
                const string sourceCode = "source code that will be partially matched";
                int parseHandlerInvocations = 0;
                Stack<string> parsedSourceCodeStack = new Stack<string>();
                Stack<IList<Scope>> scopesStack = new Stack<IList<Scope>>();

                languageParser.Parse(sourceCode, stubLanguage, (parsedSourceCode, scopes) =>
                {
                    parseHandlerInvocations++; 
                    parsedSourceCodeStack.Push(parsedSourceCode); 
                    scopesStack.Push(scopes);
                });

                Assert.Equal(2, parseHandlerInvocations);
                string secondParsedSourceCode = parsedSourceCodeStack.Pop();
                string firstParsedSourceCode = parsedSourceCodeStack.Pop();
                IList<Scope> secondScopes = scopesStack.Pop();
                IList<Scope> firstScopes = scopesStack.Pop();
                Assert.Equal("source code", firstParsedSourceCode);
                Assert.Equal("A Scope Name", firstScopes[0].Name);
                Assert.Equal(" that will be partially matched", secondParsedSourceCode);
                Assert.Empty(secondScopes);
            }

            [Fact]
            public void It_will_yield_partially_matched_parsed_source_code_and_the_unmatched_source_code_before_it()
            {
                StubLanguageCompiler stubLanguageCompiler = new StubLanguageCompiler();
                stubLanguageCompiler.Compile__return = new CompiledLanguage("fnord", "fnord", new Regex("partially matched"), new List<string> { "A Scope Name" });
                LanguageParser languageParser = new LanguageParser(stubLanguageCompiler, new StubLanguageRepository());
                StubLanguage stubLanguage = new StubLanguage();
                const string sourceCode = "source code that will be partially matched";
                int parseHandlerInvocations = 0;
                Stack<string> parsedSourceCodeStack = new Stack<string>();
                Stack<IList<Scope>> scopesStack = new Stack<IList<Scope>>();

                languageParser.Parse(sourceCode, stubLanguage, (parsedSourceCode, scopes) =>
                {
                    parseHandlerInvocations++;
                    parsedSourceCodeStack.Push(parsedSourceCode);
                    scopesStack.Push(scopes);
                });

                Assert.Equal(2, parseHandlerInvocations);
                string secondParsedSourceCode = parsedSourceCodeStack.Pop();
                string firstParsedSourceCode = parsedSourceCodeStack.Pop();
                IList<Scope> secondScopes = scopesStack.Pop();
                IList<Scope> firstScopes = scopesStack.Pop();
                Assert.Equal("source code that will be ", firstParsedSourceCode);
                Assert.Empty(firstScopes);
                Assert.Equal("partially matched", secondParsedSourceCode);
                Assert.Equal("A Scope Name", secondScopes[0].Name);
            }

            [Fact]
            public void It_will_yield_multiple_partial_source_code_matches_in_order()
            {
                StubLanguageCompiler stubLanguageCompiler = new StubLanguageCompiler();
                stubLanguageCompiler.Compile__return = new CompiledLanguage("fnord", "fnord", new Regex("source code that will be |partially matched"), new List<string> { "A Scope Name" });
                LanguageParser languageParser = new LanguageParser(stubLanguageCompiler, new StubLanguageRepository());
                StubLanguage stubLanguage = new StubLanguage();
                const string sourceCode = "source code that will be partially matched";
                int parseHandlerInvocations = 0;
                Stack<string> parsedSourceCodeStack = new Stack<string>();
                Stack<IList<Scope>> scopesStack = new Stack<IList<Scope>>();

                languageParser.Parse(sourceCode, stubLanguage, (parsedSourceCode, scopes) =>
                {
                    parseHandlerInvocations++;
                    parsedSourceCodeStack.Push(parsedSourceCode);
                    scopesStack.Push(scopes);
                });

                Assert.Equal(2, parseHandlerInvocations);
                string secondParsedSourceCode = parsedSourceCodeStack.Pop();
                string firstParsedSourceCode = parsedSourceCodeStack.Pop();
                IList<Scope> secondScopes = scopesStack.Pop();
                IList<Scope> firstScopes = scopesStack.Pop();
                Assert.Equal("source code that will be ", firstParsedSourceCode);
                Assert.Equal(1, firstScopes.Count);
                Assert.Equal("A Scope Name", firstScopes[0].Name);
                Assert.Equal("partially matched", secondParsedSourceCode);
                Assert.Equal(1, secondScopes.Count);
                Assert.Equal("A Scope Name", secondScopes[0].Name);
            }

            [Fact]
            public void It_will_yield_a_whole_scope_and_multiple_partial_scopes()
            {
                StubLanguageCompiler stubLanguageCompiler = new StubLanguageCompiler();
                stubLanguageCompiler.Compile__return = new CompiledLanguage("fnord", "fnord", new Regex("(partially) (matched)"), new List<string> { "scope name for the whole match", "scope name for the partially part", "scope name for the matched part" });
                LanguageParser languageParser = new LanguageParser(stubLanguageCompiler, new StubLanguageRepository());
                StubLanguage stubLanguage = new StubLanguage();
                const string sourceCode = "source code that will be partially matched";
                int parseHandlerInvocations = 0;
                Stack<string> parsedSourceCodeStack = new Stack<string>();
                Stack<IList<Scope>> scopesStack = new Stack<IList<Scope>>();

                languageParser.Parse(sourceCode, stubLanguage, (parsedSourceCode, scopes) =>
                {
                    parseHandlerInvocations++;
                    parsedSourceCodeStack.Push(parsedSourceCode);
                    scopesStack.Push(scopes);
                });

                Assert.Equal(2, parseHandlerInvocations);
                string secondParsedSourceCode = parsedSourceCodeStack.Pop();
                string firstParsedSourceCode = parsedSourceCodeStack.Pop();
                IList<Scope> secondScopes = scopesStack.Pop();
                IList<Scope> firstScopes = scopesStack.Pop();
                Assert.Equal("source code that will be ", firstParsedSourceCode);
                Assert.Empty(firstScopes);
                Assert.Equal("partially matched", secondParsedSourceCode);
                Assert.Equal("scope name for the whole match", secondScopes[0].Name);
                Assert.Equal("scope name for the partially part", secondScopes[0].Children[0].Name);
                Assert.Equal("scope name for the matched part", secondScopes[0].Children[1].Name);
            }

            [Fact]
            public void It_will_yield_multiple_scopes_without_a_whole_scope()
            {
                StubLanguageCompiler stubLanguageCompiler = new StubLanguageCompiler();
                stubLanguageCompiler.Compile__return = new CompiledLanguage("fnord", "fnord", new Regex("(partially) (matched)"), new List<string> { null, "scope name for the partially part", "scope name for the matched part" });
                LanguageParser languageParser = new LanguageParser(stubLanguageCompiler, new StubLanguageRepository());
                StubLanguage stubLanguage = new StubLanguage();
                const string sourceCode = "source code that will be partially matched";
                int parseHandlerInvocations = 0;
                Stack<string> parsedSourceCodeStack = new Stack<string>();
                Stack<IList<Scope>> scopesStack = new Stack<IList<Scope>>();

                languageParser.Parse(sourceCode, stubLanguage, (parsedSourceCode, scopes) =>
                {
                    parseHandlerInvocations++;
                    parsedSourceCodeStack.Push(parsedSourceCode);
                    scopesStack.Push(scopes);
                });

                Assert.Equal(2, parseHandlerInvocations);
                string secondParsedSourceCode = parsedSourceCodeStack.Pop();
                string firstParsedSourceCode = parsedSourceCodeStack.Pop();
                IList<Scope> secondScopes = scopesStack.Pop();
                IList<Scope> firstScopes = scopesStack.Pop();
                Assert.Equal("source code that will be ", firstParsedSourceCode);
                Assert.Empty(firstScopes);
                Assert.Equal("partially matched", secondParsedSourceCode);
                Assert.Equal("scope name for the partially part", secondScopes[0].Name);
                Assert.Equal("scope name for the matched part", secondScopes[1].Name);
            }

            [Fact]
            public void It_will_yield_nested_scopes()
            {
                StubLanguageCompiler stubLanguageCompiler = new StubLanguageCompiler();
                stubLanguageCompiler.Compile__return = new CompiledLanguage("fnord", "fnord", new Regex("((part)ially) (matched)"), new List<string> { "scope name for the whole match", "scope name for the partially part", "scope name for the part part", "scope name for the matched part" });
                LanguageParser languageParser = new LanguageParser(stubLanguageCompiler, new StubLanguageRepository());
                StubLanguage stubLanguage = new StubLanguage();
                const string sourceCode = "source code that will be partially matched";
                int parseHandlerInvocations = 0;
                Stack<string> parsedSourceCodeStack = new Stack<string>();
                Stack<IList<Scope>> scopesStack = new Stack<IList<Scope>>();

                languageParser.Parse(sourceCode, stubLanguage, (parsedSourceCode, scopes) =>
                {
                    parseHandlerInvocations++;
                    parsedSourceCodeStack.Push(parsedSourceCode);
                    scopesStack.Push(scopes);
                });

                Assert.Equal(2, parseHandlerInvocations);
                string secondParsedSourceCode = parsedSourceCodeStack.Pop();
                string firstParsedSourceCode = parsedSourceCodeStack.Pop();
                IList<Scope> secondScopes = scopesStack.Pop();
                IList<Scope> firstScopes = scopesStack.Pop();
                Assert.Equal("source code that will be ", firstParsedSourceCode);
                Assert.Empty(firstScopes);
                Assert.Equal("partially matched", secondParsedSourceCode);
                Assert.Equal("scope name for the whole match", secondScopes[0].Name);
                Assert.Equal("scope name for the partially part", secondScopes[0].Children[0].Name);
                Assert.Equal("scope name for the part part", secondScopes[0].Children[0].Children[0].Name);
                Assert.Equal("scope name for the matched part", secondScopes[0].Children[1].Name);
            }

            [Fact]
            public void It_will_parse_nested_languages()
            {
                StubLanguageCompiler stubLanguageCompiler = new StubLanguageCompiler();
                Queue<CompiledLanguage> stubCompiledLanguages = new Queue<CompiledLanguage>();
                stubCompiledLanguages.Enqueue(new CompiledLanguage("fnord", "fnord", new Regex("(source code with ){(.*?)}( in the curly braces)"), new List<string> { null, "style for part before nested language", "&nestedLanguageId", "style for part after nested language" }));
                stubCompiledLanguages.Enqueue(new CompiledLanguage("nestedLanguageId", "fnord", new Regex(".*"), new List<string> { "style for a nested language" }));
                stubLanguageCompiler.Compile__do = (language) => stubCompiledLanguages.Dequeue();
                StubLanguageRepository stubLanguageRepository = new StubLanguageRepository();
                stubLanguageRepository.FindById__do = (languageId) => new StubLanguage{ id__getValue = "nestedLanguageId", name__getValue = "fnord", rules__getValue = new List<LanguageRule>{ new LanguageRule("fnord", new Dictionary<int, string>{ {0, "fnord"}})}}; 
                LanguageParser languageParser = new LanguageParser(stubLanguageCompiler, stubLanguageRepository);
                StubLanguage stubLanguage = new StubLanguage();
                const string sourceCode = "source code with {a nested language} in the curly braces";
                int parseHandlerInvocations = 0;
                Stack<string> parsedSourceCodeStack = new Stack<string>();
                Stack<IList<Scope>> scopesStack = new Stack<IList<Scope>>();

                languageParser.Parse(sourceCode, stubLanguage, (parsedSourceCode, scopes) =>
                {
                    parseHandlerInvocations++;
                    parsedSourceCodeStack.Push(parsedSourceCode);
                    scopesStack.Push(scopes);
                });

                Assert.Equal(1, parseHandlerInvocations);
                string firstParsedSourceCode = parsedSourceCodeStack.Pop();
                IList<Scope> firstScopes = scopesStack.Pop();
                Assert.Equal("source code with {a nested language} in the curly braces", firstParsedSourceCode);
                Assert.Equal("style for part before nested language", firstScopes[0].Name);
                Assert.Equal("style for a nested language", firstScopes[1].Name);
                Assert.Equal("style for part after nested language", firstScopes[2].Name);
            }

            [Fact]
            public void It_will_parse_nested_languages_with_nested_scopes()
            {
                StubLanguageCompiler stubLanguageCompiler = new StubLanguageCompiler();
                Queue<CompiledLanguage> stubCompiledLanguages = new Queue<CompiledLanguage>();
                stubCompiledLanguages.Enqueue(new CompiledLanguage("fnord", "fnord", new Regex("(source code with ){(.*?)}( in the curly braces)"), new List<string> { null, "style for part before nested language", "&nestedLanguageId", "style for part after nested language" }));
                stubCompiledLanguages.Enqueue(new CompiledLanguage("nestedLanguageId", "fnord", new Regex("a (nested (lang)uage)"), new List<string> { "style for a nested language", "style for nested language part", "style for lang part" }));
                stubLanguageCompiler.Compile__do = (language) => stubCompiledLanguages.Dequeue();
                StubLanguageRepository stubLanguageRepository = new StubLanguageRepository();
                stubLanguageRepository.FindById__do = (languageId) => new StubLanguage { id__getValue = "nestedLanguageId", name__getValue = "fnord", rules__getValue = new List<LanguageRule> { new LanguageRule("fnord", new Dictionary<int, string> { { 0, "fnord" } }) } };
                LanguageParser languageParser = new LanguageParser(stubLanguageCompiler, stubLanguageRepository);
                StubLanguage stubLanguage = new StubLanguage();
                const string sourceCode = "source code with {a nested language} in the curly braces";
                int parseHandlerInvocations = 0;
                Stack<string> parsedSourceCodeStack = new Stack<string>();
                Stack<IList<Scope>> scopesStack = new Stack<IList<Scope>>();

                languageParser.Parse(sourceCode, stubLanguage, (parsedSourceCode, scopes) =>
                {
                    parseHandlerInvocations++;
                    parsedSourceCodeStack.Push(parsedSourceCode);
                    scopesStack.Push(scopes);
                });

                Assert.Equal(1, parseHandlerInvocations);
                string firstParsedSourceCode = parsedSourceCodeStack.Pop();
                IList<Scope> firstScopes = scopesStack.Pop();
                Assert.Equal("source code with {a nested language} in the curly braces", firstParsedSourceCode);
                Assert.Equal("style for part before nested language", firstScopes[0].Name);
                Assert.Equal("style for a nested language", firstScopes[1].Name);
                Assert.Equal("style for nested language part", firstScopes[1].Children[0].Name);
                Assert.Equal("style for lang part", firstScopes[1].Children[0].Children[0].Name);
                Assert.Equal("style for part after nested language", firstScopes[2].Name);
            }

            [Fact]
            public void It_will_parse_nested_languages_even_when_nested_language_has_no_matches()
            {
                StubLanguageCompiler stubLanguageCompiler = new StubLanguageCompiler();
                Queue<CompiledLanguage> stubCompiledLanguages = new Queue<CompiledLanguage>();
                stubCompiledLanguages.Enqueue(new CompiledLanguage("fnord", "fnord", new Regex("(source code with ){(.*?)}( in the curly braces)"), new List<string> { null, "style for part before nested language", "&nestedLanguageId", "style for part after nested language" }));
                stubCompiledLanguages.Enqueue(new CompiledLanguage("nestedLanguageId", "fnord", new Regex("this will match nothing"), new List<string> { "style for a nested language" }));
                stubLanguageCompiler.Compile__do = (language) => stubCompiledLanguages.Dequeue();
                StubLanguageRepository stubLanguageRepository = new StubLanguageRepository();
                stubLanguageRepository.FindById__do = (languageId) => new StubLanguage { id__getValue = "nestedLanguageId", name__getValue = "fnord", rules__getValue = new List<LanguageRule> { new LanguageRule("fnord", new Dictionary<int, string> { { 0, "fnord" } }) } };
                LanguageParser languageParser = new LanguageParser(stubLanguageCompiler, stubLanguageRepository);
                StubLanguage stubLanguage = new StubLanguage();
                const string sourceCode = "source code with {a nested language} in the curly braces";
                int parseHandlerInvocations = 0;
                Stack<string> parsedSourceCodeStack = new Stack<string>();
                Stack<IList<Scope>> scopesStack = new Stack<IList<Scope>>();

                languageParser.Parse(sourceCode, stubLanguage, (parsedSourceCode, scopes) =>
                {
                    parseHandlerInvocations++;
                    parsedSourceCodeStack.Push(parsedSourceCode);
                    scopesStack.Push(scopes);
                });

                Assert.Equal(1, parseHandlerInvocations);
                string firstParsedSourceCode = parsedSourceCodeStack.Pop();
                IList<Scope> firstScopes = scopesStack.Pop();
                Assert.Equal("source code with {a nested language} in the curly braces", firstParsedSourceCode);
                Assert.Equal("style for part before nested language", firstScopes[0].Name);
                Assert.Equal("style for part after nested language", firstScopes[1].Name);
            }

            [Fact]
            public void It_will_throw_if_the_nested_language_is_not_found()
            {
                StubLanguageCompiler stubLanguageCompiler = new StubLanguageCompiler();
                stubLanguageCompiler.Compile__do = (language) => new CompiledLanguage("fnord", "fnord", new Regex("(source code with ){(.*?)}( in the curly braces)"), new List<string> { null, "style for part before nested language", "&nestedLanguageId", "style for part after nested language" });
                LanguageParser languageParser = new LanguageParser(stubLanguageCompiler, new StubLanguageRepository());
                StubLanguage stubLanguage = new StubLanguage();
                const string sourceCode = "source code with {a nested language} in the curly braces";

                Exception ex = Record.Exception(() => languageParser.Parse(sourceCode, stubLanguage, (parsedSourceCode, scopes) => { }));

                Assert.IsType<InvalidOperationException>(ex);
                Assert.Contains("The nested language was not found in the language repository.", ex.Message);
            }

            [Fact]
            public void It_will_compile_the_language()
            {
                StubLanguageCompiler stubLanguageCompiler = new StubLanguageCompiler();
                stubLanguageCompiler.Compile__return = new CompiledLanguage("fnord", "fnord", new Regex("fnord"), new List<string> { "fnord" });
                LanguageParser languageParser = new LanguageParser(stubLanguageCompiler, new StubLanguageRepository());
                StubLanguage stubLanguage = new StubLanguage();
                const string sourceCode = "fnord";

                languageParser.Parse(sourceCode, stubLanguage, (parsedSourceCode, scopes) => { });

                Assert.Equal(stubLanguage, stubLanguageCompiler.Compile__language);
            }
        }
    }
}
