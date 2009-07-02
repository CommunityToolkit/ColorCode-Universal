// Copyright (c) Microsoft Corporation.  All rights reserved.

using System.IO;
using System.Text;
using ColorCode.Common;
using ColorCode.Compilation;
using ColorCode.Formatting;
using ColorCode.Parsing;

namespace ColorCode
{
    public class CodeColorizer : ICodeColorizer
    {
        private readonly ILanguageParser languageParser;

        public CodeColorizer()
        {
            languageParser = new LanguageParser(new LanguageCompiler(Languages.CompiledLanguages), Languages.LanguageRepository);
        }

        public CodeColorizer(ILanguageParser languageParser)
        {
            Guard.ArgNotNull(languageParser, "languageParser");
            
            this.languageParser = languageParser;
        }

        public string Colorize(string sourceCode, ILanguage language)
        {
            var buffer = new StringBuilder(sourceCode.Length * 2);

            using (TextWriter writer = new StringWriter(buffer))
            {
                Colorize(sourceCode, language, writer);

                writer.Flush();
            }

            return buffer.ToString();
        }

        public void Colorize(string sourceCode, ILanguage language, TextWriter textWriter)
        {
            IFormatter formatter = new HtmlFormatter();
            IStyleSheet styleSheet = StyleSheets.Default;
            Colorize(sourceCode, language, formatter, styleSheet, textWriter);
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