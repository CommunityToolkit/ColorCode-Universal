using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xunit;

namespace ColorCode.Compilation
{
    public class CompiledLanguage_Facts
    {
        public class Constructor_Facts
        {
            [Fact]
            public void It_will_set_the_compiled_language_identifier_and_name_and_regex_and_capture()
            {
                const string id = "theId";
                const string name = "The ScopeName";
                Regex regex = new Regex("theRegex");
                List<string> captures = new List<string>{ "theFirstCapture" };

                CompiledLanguage compiledLanguage = new CompiledLanguage(id, name, regex, captures);

                Assert.Equal("theId", compiledLanguage.Id);
                Assert.Equal("The ScopeName", compiledLanguage.Name);
                Assert.Equal("theRegex", compiledLanguage.Regex.ToString());
                Assert.Equal("theFirstCapture", compiledLanguage.Captures[0]);
            }

            [Fact]
            public void It_will_throw_when_the_identifier_is_null()
            {
                const string name = "fnord";
                Regex regex = new Regex("fnord");
                List<string> captures = new List<string> { "fnord" };

                Exception ex = Record.Exception(() => new CompiledLanguage(null, name, regex, captures));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("id", ((ArgumentNullException)ex).ParamName);
            }

            [Fact]
            public void It_will_throw_when_the_identifier_is_empty()
            {
                const string name = "fnord";
                Regex regex = new Regex("fnord");
                List<string> captures = new List<string> { "fnord" };

                Exception ex = Record.Exception(() => new CompiledLanguage(string.Empty, name, regex, captures));

                Assert.IsType<ArgumentException>(ex);
                Assert.Contains("The id argument value must not be empty.", ex.Message);
                Assert.Equal("id", ((ArgumentException)ex).ParamName);
            }

            [Fact]
            public void It_will_throw_when_the_name_is_null()
            {
                const string id = "fnord";
                Regex regex = new Regex("fnord");
                List<string> captures = new List<string> { "fnord" };

                Exception ex = Record.Exception(() => new CompiledLanguage(id, null, regex, captures));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("name", ((ArgumentNullException)ex).ParamName);
            }

            [Fact]
            public void It_will_throw_when_the_name_is_empty()
            {
                const string id = "fnord";
                Regex regex = new Regex("fnord");
                List<string> captures = new List<string> { "fnord" };

                Exception ex = Record.Exception(() => new CompiledLanguage(id, string.Empty, regex, captures));

                Assert.IsType<ArgumentException>(ex);
                Assert.Contains("The name argument value must not be empty.", ex.Message);
                Assert.Equal("name", ((ArgumentException)ex).ParamName);
            }

            [Fact]
            public void It_will_throw_when_the_regex_is_null()
            {
                const string id = "fnord";
                const string name = "fnord";
                List<string> captures = new List<string> { "fnord" };

                Exception ex = Record.Exception(() => new CompiledLanguage(id, name, null, captures));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("regex", ((ArgumentNullException)ex).ParamName);
            }

            [Fact]
            public void It_will_throw_when_the_captures_list_is_null()
            {
                const string id = "fnord";
                const string name = "fnord";
                Regex regex = new Regex("fnord");

                Exception ex = Record.Exception(() => new CompiledLanguage(id, name, regex, null));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("captures", ((ArgumentNullException)ex).ParamName);
            }

            [Fact]
            public void It_will_throw_when_the_captures_list_is_empty()
            {
                const string id = "fnord";
                const string name = "fnord";
                Regex regex = new Regex("fnord");
                List<string> captures = new List<string>();

                Exception ex = Record.Exception(() => new CompiledLanguage(id, name, regex, captures));

                Assert.IsType<ArgumentException>(ex);
                Assert.Contains("The captures argument value must not be empty.", ex.Message);
                Assert.Equal("captures", ((ArgumentException)ex).ParamName);
            }
        }

        public class ToString_Method_Facts
        {
            [Fact]
            public void It_will_return_the_name()
            {
                const string id = "fnord";
                const string name = "The ScopeName";
                Regex regex = new Regex("fnord");
                List<string> captures = new List<string> { "fnord" };
                CompiledLanguage compiledLanguage = new CompiledLanguage(id, name, regex, captures);

                string toString = compiledLanguage.ToString();

                Assert.Equal("The ScopeName", toString);
            }
        }
    }
}
