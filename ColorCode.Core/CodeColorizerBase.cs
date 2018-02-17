using ColorCode.Compilation;
using ColorCode.Parsing;
using ColorCode.Styling;

namespace ColorCode
{
    /// <summary>
    /// Creates a <see cref="CodeColorizerBase"/>, for creating Syntax Highlighted code.
    /// </summary>
    /// <param name="Style">The Custom styles to Apply to the formatted Code.</param>
    /// <param name="languageParser">The language parser that the <see cref="CodeColorizerBase"/> instance will use for its lifetime.</param>
    public abstract class CodeColorizerBase
    {
        public CodeColorizerBase(StyleDictionary Styles, ILanguageParser languageParser)
        {
            this.languageParser = languageParser
                ?? new LanguageParser(new LanguageCompiler(Languages.CompiledLanguages), Languages.LanguageRepository);

            this.Styles = Styles ?? StyleDictionary.DefaultLight;
        }

        /// <summary>
        /// The language parser that the <see cref="CodeColorizerBase"/> instance will use for its lifetime.
        /// </summary>
        protected readonly ILanguageParser languageParser;

        /// <summary>
        /// The styles to Apply to the formatted Code.
        /// </summary>
        public readonly StyleDictionary Styles;
    }
}