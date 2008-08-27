using System.Text.RegularExpressions;
using ColorCode.Parsing;

namespace ColorCode.Compilation.Languages
{
    public static partial class Grammars
    {
        private static ILanguageDefinition css;

        public static ILanguageDefinition Css
        {
            get
            {
                if (css == null)
                    BuildCss();

                return css;
            }
        }

        private static void BuildCss()
        {
            css = new CompiledGrammar
                  {
                      Id = "css",
                      Name = "Css",
                      FileExtensions = new[]
                                       {
                                           "css"
                                       },
                      Regex = new Regex(@"(?x)
                                    (?:\b(\w+?)\s*?{(?:\s*?(\w+)\s*?:\s*?([^ ]+?);)*\s*?})",
                                        RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.Compiled),
                      Scopes = new[]
                               {
                                   null,
                                   "entity.selector.css",
                                   "entity.style.css",
                                   "string.unquoted.css"
                               }
                  };
        }
    }
}