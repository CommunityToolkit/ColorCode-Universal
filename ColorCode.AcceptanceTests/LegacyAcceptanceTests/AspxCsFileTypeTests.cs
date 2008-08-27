using Xunit;

namespace ColorCode.AspxCsAcceptanceTests
{
    public class AspxCsFileTypeTests
    {
        static ILanguage GetGrammar()
        {
            return Languages.AspxCs;
        }

        public class FileTypes
        {
            [Fact]
            public void WillIncludeAspx()
            {
                ILanguage language = GetGrammar();

                Assert.Contains("aspx", language.FileExtensions);
            }

            [Fact]
            public void WillIncludeAscx()
            {
                ILanguage language = GetGrammar();

                Assert.Contains("ascx", language.FileExtensions);
            }
        }

        public class FindByFileType
        {
            [Fact]
            public void WillReturnGrammarForAspx()
            {
                string fileType = "aspx";
                string firstLine = @"<%@ Page LanguageDefinition=""c#"" %>";

                ILanguage actual = Languages.FindGrammarForFileType(fileType, firstLine);

                Assert.Equal(GetGrammar(), actual);
            }

            [Fact]
            public void WillReturnGrammarForAspxWithCSharpCaptialized()
            {
                string fileType = "aspx";
                string firstLine = @"<%@ Page LanguageDefinition=""C#"" %>";

                ILanguage actual = Languages.FindGrammarForFileType(fileType, firstLine);

                Assert.Equal(GetGrammar(), actual);
            }

            [Fact]
            public void WillReturnGrammarForAspxWithMultilinePageDeclaration()
            {
                string fileType = "aspx";
                string firstLine = @"<%@ Page
   LanguageDefinition=""C#""
   MasterPageFile=""~/DefaultMaster.master""
   AutoEventWireup=""true""
   Inherits=""CommonPage""
   Title=""PasswordStrength Sample"" 
   StyleSheet=""SampleSiteTheme"" %>";

                ILanguage actual = Languages.FindGrammarForFileType(fileType, firstLine);

                Assert.Equal(GetGrammar(), actual);
            }

            [Fact]
            public void WillReturnGrammarForAscx()
            {
                string fileType = "ascx";
                string firstLine = @"<%@ Control LanguageDefinition=""c#"" %>";

                ILanguage actual = Languages.FindGrammarForFileType(fileType, firstLine);

                Assert.Equal(GetGrammar(), actual);
            }

            [Fact]
            public void WillReturnGrammarForAscxWithCSharpCaptialized()
            {
                string fileType = "ascx";
                string firstLine = @"<%@ Control LanguageDefinition=""C#"" %>";

                ILanguage actual = Languages.FindGrammarForFileType(fileType, firstLine);

                Assert.Equal(GetGrammar(), actual);
            }

            [Fact]
            public void WillReturnGrammarForControlDeclarationWithSrcElement()
            {
                string fileType = "ascx";
                string firstLine = @"<%@ control inherits=""SimpleControl"" src=""SimpleControl.cs"" %>";

                ILanguage actual = Languages.FindGrammarForFileType(fileType, firstLine);

                Assert.Equal(GetGrammar(), actual);
            }

            [Fact]
            public void WillReturnGrammarForPageDeclarationWithSrcElement()
            {
                string fileType = "aspx";
                string firstLine = @"<%@ Page Inherits=""SomePage"" src=""SomePage.cs"" %>";

                ILanguage actual = Languages.FindGrammarForFileType(fileType, firstLine);

                Assert.Equal(GetGrammar(), actual);
            }
        }
    }
}
