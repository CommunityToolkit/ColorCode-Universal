using ColorCode.Common;
using ColorCode.Compilation;
using ColorCode.Parsing;
using System.Collections.Generic;

namespace ColorCode
{
    public abstract class CodeColorizerBase
    {
        protected readonly ILanguageParser languageParser;

        public CodeColorizerBase()
        {
            languageParser = new LanguageParser(new LanguageCompiler(Languages.CompiledLanguages), Languages.LanguageRepository);
        }

        public CodeColorizerBase(ILanguageParser languageParser)
        {
            Guard.ArgNotNull(languageParser, "languageParser");
            this.languageParser = languageParser;
        }

        /// <summary>
        /// Writes the parsed source code to the ouput using the specified style sheet.
        /// </summary>
        /// <param name="parsedSourceCode">The parsed source code to format and write to the output.</param>
        /// <param name="scopes">The captured scopes for the parsed source code.</param>
        protected abstract void Write(string parsedSourceCode, IList<Scope> scopes);
    }
}