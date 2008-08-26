using System.Collections.Generic;
using System.IO;
using ColorCode.Common;
using ColorCode.Parsing;

namespace ColorCode
{
    public class CodeColorizer : ICodeColorizer
    {
        private readonly ILanguageParser languageParser;

        public CodeColorizer(ILanguageParser languageParser)
        {
            Guard.ArgNotNull(languageParser, "languageParser");
            
            this.languageParser = languageParser;
        }
        
        public void Colorize(string sourceCode,
                             ILanguage language,
                             IFormatter formatter,
                             IStyleSheet styleSheet,
                             TextWriter textWriter)
        {
            Guard.ArgNotNull(language, "language");
            Guard.ArgNotNull(formatter, "formatter");
            Guard.ArgNotNull(styleSheet, "styleSheet");
            Guard.ArgNotNull(textWriter, "textWriter");

            formatter.WriteHeader(styleSheet, textWriter);

            languageParser.Parse(sourceCode, language, (parsedSourceCode, captures) => formatter.Write(parsedSourceCode, captures, styleSheet, textWriter));

            formatter.WriteFooter(styleSheet, textWriter);
        }
    }
}