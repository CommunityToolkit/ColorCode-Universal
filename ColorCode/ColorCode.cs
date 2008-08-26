using System.IO;
using System.Text;
using ColorCode.Common;
using ColorCode.Compilation;
using ColorCode.Formatting;
using ColorCode.Parsing;

namespace ColorCode
{
    public static class ColorCode
    {
        public static string Colorize(string sourceCode,
                                      ILanguage language)
        {
            ILanguageParser languageParser = new LanguageParser(new LanguageCompiler(Languages.CompiledLanguages),  new LanguageRepository(Languages.LoadedLanguages));
            ICodeColorizer colorizer = new CodeColorizer(languageParser);
            IFormatter formatter = new HtmlFormatter();
            IStyleSheet styleSheet = StyleSheets.Default;
            
            StringBuilder buffer = new StringBuilder();

            using (TextWriter writer = new StringWriter(buffer))
            {
                colorizer.Colorize(sourceCode, language, formatter, styleSheet, writer);

                writer.Flush();
            }

            string colorizedSourceCode = buffer.ToString();
            
            return colorizedSourceCode;
        }
    }
}