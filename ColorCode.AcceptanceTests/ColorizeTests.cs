using System.IO;
using Xunit;
using Xunit.Extensions;

namespace ColorCode
{
    public class ColorizeTests
    {
        [Theory]
        [ColorizeData]
        public void ColorCode_will_colorize_source_code(string languageId, string sourceFileName, string expectedFileName)
        {
            ILanguage language = Languages.FindById(languageId);
            string sourceCode = File.ReadAllText(sourceFileName);
            string expectedHtml = File.ReadAllText(expectedFileName);

            string actualHtml = new CodeColorizer().Colorize(sourceCode, language);
            File.WriteAllText(expectedFileName.Replace(".expected.", ".actual."), actualHtml);
            
            Assert.Equal(expectedHtml, actualHtml);
        }
    }
}
