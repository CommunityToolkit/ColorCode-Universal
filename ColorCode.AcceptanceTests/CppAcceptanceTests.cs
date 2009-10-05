using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Extensions;

namespace ColorCode
{
    public class CppAcceptanceTests
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

                var actual = new CodeColorizer().Colorize(source, Languages.Cpp);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillColorizeAMultieLineStyleCommentOnOneLine()
            {
                const string source = @"/*comment*/";
                var expected = AcceptanceHelper.BuildExpected(@"<span style=""color:Green;"">/*comment*/</span>");

                var actual = new CodeColorizer().Colorize(source, Languages.Cpp);

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void WillColorizeASingleLineStyleComment()
            {
                const string source = @"//comment";
                var expected = AcceptanceHelper.BuildExpected(@"<span style=""color:Green;"">//comment</span>");

                var actual = new CodeColorizer().Colorize(source, Languages.Cpp);

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

                var actual = new CodeColorizer().Colorize(source, Languages.Cpp);

                Assert.Equal(expected, actual);
            }
        }
        
        public class KeywordTests
        {
            [Theory]
            [CppKeywordData]
            public void WillColorizeAKeywordWithNoSurroundingText(string keyword)
            {
                var source = keyword;
                var exepected = AcceptanceHelper.BuildExpected(@"<span style=""color:Blue;"">{0}</span>", keyword);

                var actual = new CodeColorizer().Colorize(source, Languages.Cpp);

                Assert.Equal(exepected, actual);
            }

            [Theory]
            [CppKeywordData]
            public void WillColorizeAKeywordWithPrecedingAndSucceedingText(string keyword)
            {
                var source = string.Format("fnord {0} fnord", keyword);
                var exepected = AcceptanceHelper.BuildExpected(@"fnord <span style=""color:Blue;"">{0}</span> fnord", keyword);

                var actual = new CodeColorizer().Colorize(source, Languages.Cpp);

                Assert.Equal(exepected, actual);
            }

            [Theory]
            [CppKeywordData]
            public void WillNotColorizeAKeywordInsideAWord(string keyword)
            {
                var source = string.Format("fnord{0}fnord", keyword);
                var exepected = AcceptanceHelper.BuildExpected(@"fnord{0}fnord", keyword);

                var actual = new CodeColorizer().Colorize(source, Languages.Cpp);

                Assert.Equal(exepected, actual);
            }
        }
    }

    #region Theory Data
    public class CppKeywordData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo methodUnderTest, Type[] parameterTypes)
        {
            var keywordData = new List<object[]>
                                  {
                                      new object[] {"abstract"},
                                      new object[] {"array"},
                                      new object[] {"auto"},
                                      new object[] {"bool"},
                                      new object[] {"break"},
                                      new object[] {"case"},
                                      new object[] {"catch"},
                                      new object[] {"char"},
                                      new object[] {"class"},
                                      new object[] {"const"},
                                      new object[] {"const_cast"},
                                      new object[] {"continue"},
                                      new object[] {"default"},
                                      new object[] {"delegate"},
                                      new object[] {"delete"},
                                      new object[] {"deprecated"},
                                      new object[] {"dllexport"},
                                      new object[] {"dllimport"},
                                      new object[] {"do"},
                                      new object[] {"double"},
                                      new object[] {"dynamic_cast"},
                                      new object[] {"each"},
                                      new object[] {"else"},
                                      new object[] {"enum"},
                                      new object[] {"event"},
                                      new object[] {"explicit"},
                                      new object[] {"export"},
                                      new object[] {"extern"},
                                      new object[] {"false"},
                                      new object[] {"float"},
                                      new object[] {"for"},
                                      new object[] {"friend"},
                                      new object[] {"friend_as"},
                                      new object[] {"gcnew"},
                                      new object[] {"generic"},
                                      new object[] {"goto"},
                                      new object[] {"if"},
                                      new object[] {"in"},
                                      new object[] {"initonly"},
                                      new object[] {"inline"},
                                      new object[] {"int"},
                                      new object[] {"interface"},
                                      new object[] {"literal"},
                                      new object[] {"long"},
                                      new object[] {"mutable"},
                                      new object[] {"naked"},
                                      new object[] {"namespace"},
                                      new object[] {"new"},
                                      new object[] {"noinline"},
                                      new object[] {"noreturn"},
                                      new object[] {"nothrow"},
                                      new object[] {"novtable"},
                                      new object[] {"nullptr"},
                                      new object[] {"operator"},
                                      new object[] {"private"},
                                      new object[] {"property"},
                                      new object[] {"protected"},
                                      new object[] {"public"},
                                      new object[] {"register"},
                                      new object[] {"reinterpret_cast"},
                                      new object[] {"return"},
                                      new object[] {"safecast"},
                                      new object[] {"sealed"},
                                      new object[] {"selectany"},
                                      new object[] {"short"},
                                      new object[] {"signed"},
                                      new object[] {"sizeof"},
                                      new object[] {"static"},
                                      new object[] {"static_cast"},
                                      new object[] {"struct"},
                                      new object[] {"switch"},
                                      new object[] {"template"},
                                      new object[] {"this"},
                                      new object[] {"thread"},
                                      new object[] {"throw"},
                                      new object[] {"true"},
                                      new object[] {"try"},
                                      new object[] {"typedef"},
                                      new object[] {"typeid"},
                                      new object[] {"typename"},
                                      new object[] {"union"},
                                      new object[] {"unsigned"},
                                      new object[] {"using"},
                                      new object[] {"uuid"},
                                      new object[] {"value"},
                                      new object[] {"virtual"},
                                      new object[] {"void"},
                                      new object[] {"volatile"},
                                      new object[] {"wchar_t"},
                                      new object[] {"while"},
                                  };
            return keywordData;
        }
    }
    #endregion
}
