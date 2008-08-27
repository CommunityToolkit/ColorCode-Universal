using Xunit;

namespace ColorCode.AspxVbAcceptanceTests
{
    public class AspxVbFileTypeTests
    {
        static ILanguage GetGrammar()
        {
            return Languages.AspxVb;
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
                string firstLine = @"<%@ Page LanguageDefinition=""vb"" %>";

                ILanguage actual = Languages.FindGrammarForFileType(fileType, firstLine);

                Assert.Equal(GetGrammar(), actual);
            }

            [Fact]
            public void WillReturnGrammarForAspxWithVbCaptialized()
            {
                string fileType = "aspx";
                string firstLine = @"<%@ Page LanguageDefinition=""VB"" %>";

                ILanguage actual = Languages.FindGrammarForFileType(fileType, firstLine);

                Assert.Equal(Languages.AspxVb, actual);
            }

            [Fact]
            public void WillReturnGrammarForAspxWithMultilinePageDeclaration()
            {
                string fileType = "aspx";
                string firstLine = @"<%@ Page
   LanguageDefinition=""VB""
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
                string firstLine = @"<%@ Control LanguageDefinition=""vb"" %>";

                ILanguage actual = Languages.FindGrammarForFileType(fileType, firstLine);

                Assert.Equal(GetGrammar(), actual);
            }

            [Fact]
            public void WillReturnGrammarForAscxWithVbCaptialized()
            {
                string fileType = "ascx";
                string firstLine = @"<%@ Control LanguageDefinition=""VB"" %>";

                ILanguage actual = Languages.FindGrammarForFileType(fileType, firstLine);

                Assert.Equal(GetGrammar(), actual);
            }
        }
    }
}
