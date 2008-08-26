using System;
using System.Collections.Generic;
using Xunit;

namespace ColorCode.Compilation
{
    public class LanguageRule_Facts
    {
        public class Constructor_Facts
        {
            [Fact]
            public void It_will_set_the_regex_and_captures()
            {
                const string regex = "theRegex";
                Dictionary<int, string> captures = new Dictionary<int, string> { {0, "theFirstCapture"} };

                LanguageRule languageRule = new LanguageRule(regex, captures);

                Assert.Equal("theRegex", languageRule.Regex);
                Assert.Equal("theFirstCapture", languageRule.Captures[0]);
            }

            [Fact]
            public void It_will_throw_when_the_regex_is_null()
            {
                Dictionary<int, string> captures = new Dictionary<int, string> { { 0, "fnord" } };

                Exception ex = Record.Exception(() => new LanguageRule(null, captures));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("regex", ((ArgumentNullException)ex).ParamName);
            }

            [Fact]
            public void It_will_throw_when_the_regex_is_empty()
            {
                Dictionary<int, string> captures = new Dictionary<int, string> { { 0, "fnord" } };

                Exception ex = Record.Exception(() => new LanguageRule(string.Empty, captures));

                Assert.IsType<ArgumentException>(ex);
                Assert.Contains("The regex argument value must not be empty.", ex.Message);
                Assert.Equal("regex", ((ArgumentException)ex).ParamName);
            }

            [Fact]
            public void It_will_throw_when_the_captures_is_null()
            {
                const string regex = "fnord";

                Exception ex = Record.Exception(() => new LanguageRule(regex, null));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("captures", ((ArgumentNullException)ex).ParamName);
            }

            [Fact]
            public void It_will_throw_when_the_captures_is_empty()
            {
                const string regex = "fnord";
                Dictionary<int, string> captures = new Dictionary<int, string>();

                Exception ex = Record.Exception(() => new LanguageRule(regex, captures));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("captures", ((ArgumentNullException)ex).ParamName);
            }
        }
    }
}
