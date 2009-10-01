using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Extensions;

namespace ColorCode
{
    public class JavaAcceptanceTests
    {
        public class CommentTests
        {
            [Fact]
            public void WillColorizeACommentOnMultipleLines()
            {
                const string source = @"/*
comment line
comment line 2
*/";
                var expected = AcceptanceHelper.BuildExpected(@"<span style=""color:Green;"">/*
comment line
comment line 2
*/</span>");

                var actual = new CodeColorizer().Colorize(source, Languages.Java);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillColorizeAMultieLineStyleCommentOnOneLine()
            {
                const string source = @"/*comment*/";
                var expected = AcceptanceHelper.BuildExpected(@"<span style=""color:Green;"">/*comment*/</span>");

                var actual = new CodeColorizer().Colorize(source, Languages.Java);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillColorizeASingleLineStyleComment()
            {
                const string source = @"//comment";
                var expected = AcceptanceHelper.BuildExpected(@"<span style=""color:Green;"">//comment</span>");

                var actual = new CodeColorizer().Colorize(source, Languages.Java);

                Assert.Equal(expected, actual);
            }
        }

        public class StringTests
        {
            [Fact]
            public void WillColorizeStrings()
            {
                const string source = @"string aString = ""aString"";";
                var expected = AcceptanceHelper.BuildExpected(@"string aString = <span style=""color:#A31515;"">&quot;aString&quot;</span>;");

                var actual = new CodeColorizer().Colorize(source, Languages.Java);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillColorizeCharacters()
            {
                const string source = @"char aChar = 'a';";
                var expected = AcceptanceHelper.BuildExpected(@"<span style=""color:Blue;"">char</span> aChar = <span style=""color:#A31515;"">'a'</span>;");

                var actual = new CodeColorizer().Colorize(source, Languages.Java);

                Assert.Equal(expected, actual);
            }
        }

        public class KeywordTests
        {
            [Theory]
            [JavaKeywordData]
            public void WillColorizeAKeywordWithNoSurroundingText(string keyword)
            {
                var source = keyword;
                var exepected = AcceptanceHelper.BuildExpected(@"<span style=""color:Blue;"">{0}</span>", keyword);

                var actual = new CodeColorizer().Colorize(source, Languages.Java);

                Assert.Equal(exepected, actual);
            }

            [Theory]
            [JavaKeywordData]
            public void WillColorizeAKeywordWithPrecedingAndSucceedingText(string keyword)
            {
                var source = string.Format("fnord {0} fnord", keyword);
                var exepected = AcceptanceHelper.BuildExpected(@"fnord <span style=""color:Blue;"">{0}</span> fnord", keyword);

                var actual = new CodeColorizer().Colorize(source, Languages.Java);

                Assert.Equal(exepected, actual);
            }

            [Theory]
            [JavaKeywordData]
            public void WillNotColorizeAKeywordInsideAWord(string keyword)
            {
                var source = string.Format("fnord{0}fnord", keyword);
                var exepected = AcceptanceHelper.BuildExpected(@"fnord{0}fnord", keyword);

                var actual = new CodeColorizer().Colorize(source, Languages.Java);

                Assert.Equal(exepected, actual);
            }
        }
    }

    #region Theory Data
    public class JavaKeywordData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo methodUnderTest, Type[] parameterTypes)
        {
            var keywordData = new List<object[]>
                                  {
                                      new object[] {"abstract"},
                                      new object[] {"assert"},
                                      new object[] {"boolean"},
                                      new object[] {"break"},
                                      new object[] {"byte"},
                                      new object[] {"case"},
                                      new object[] {"catch"},
                                      new object[] {"char"},
                                      new object[] {"class"},
                                      new object[] {"const"},
                                      new object[] {"continue"},
                                      new object[] {"default"},
                                      new object[] {"do"},
                                      new object[] {"double"},
                                      new object[] {"else"},
                                      new object[] {"enum"},
                                      new object[] {"extends"},
                                      new object[] {"false"},
                                      new object[] {"final"},
                                      new object[] {"finally"},
                                      new object[] {"float"},
                                      new object[] {"for"},
                                      new object[] {"goto"},
                                      new object[] {"if"},
                                      new object[] {"implements"},
                                      new object[] {"import"},
                                      new object[] {"instanceof"},
                                      new object[] {"int"},
                                      new object[] {"interface"},
                                      new object[] {"long"},
                                      new object[] {"native"},
                                      new object[] {"new"},
                                      new object[] {"null"},
                                      new object[] {"package"},
                                      new object[] {"private"},
                                      new object[] {"protected"},
                                      new object[] {"public"},
                                      new object[] {"return"},
                                      new object[] {"short"},
                                      new object[] {"static"},
                                      new object[] {"strictfp"},
                                      new object[] {"super"},
                                      new object[] {"switch"},
                                      new object[] {"synchronized"},
                                      new object[] {"this"},
                                      new object[] {"throw"},
                                      new object[] {"throws"},
                                      new object[] {"transient"},
                                      new object[] {"true"},
                                      new object[] {"try"},
                                      new object[] {"void"},
                                      new object[] {"volatile"},
                                      new object[] {"while"}
                                  };
            return keywordData;
        }
    }
    #endregion
}
