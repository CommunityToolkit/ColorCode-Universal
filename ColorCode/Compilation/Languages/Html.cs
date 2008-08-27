using System.Collections.Generic;
using System.Text.RegularExpressions;
using ColorCode.Parsing;

namespace ColorCode.Compilation.Languages
{
    public static partial class Grammars
    {
        private static ILanguageDefinition html;

        public static ILanguageDefinition Html
        {
            get
            {
                if (html == null)
                    BuildHtml();

                return html;
            }
        }

        private static void BuildHtml()
        {
            html = new CompiledGrammar
                   {
                       Id = "html",
                       Name = "HTML",
                       FileExtensions = new[]
                                        {
                                            "html",
                                            "htm",
                                        },
                       Regex = new Regex(@"(?xism)
                                          (<!--.*?-->)
                                          
                                          |(<!)(DOCTYPE)(?:\s+([a-zA-Z0-9]+))*(?:\s+(""[^""]*?""))*(>)

                                          |(<)                                                      # punctuation element begin
                                            (script)                                                # element name
                                            (?:
                                               [\s\n]+([a-zA-Z0-9-_]+)[\s\n]*=[\s\n]*([^\s\n""']+?) # attribute name, attribute value unquoted
                                              |[\s\n]+([a-zA-Z0-9-_]+)[\s\n]*=[\s\n]*(""[^\n]+?"")  # attribute name, attribute value qouted double
                                              |[\s\n]+([a-zA-Z0-9-_]+)[\s\n]*=[\s\n]*('[^\n]+?')    # attribute name, attribute value unqouted single
                                              |[\s\n]+([a-zA-Z0-9-_]+) )*                           # attribute name
                                            [\s\n]*
                                            (>)                                                     # punctuation element end
                                            (.*?)                                                   # embedded JavaScript
                                            (</)(script)(>)                                         # punctuation element begin, element name, punctuation element end

                                          |(</?)                                                    # punctuation element begin
                                            (?: ([a-z][a-z0-9-]*)(:) )*                             # element namespace name, element punctuation element
                                            ([a-z][a-z0-9-_]*)                                      # element name
                                            (?:
                                               [\s\n]+([a-zA-Z0-9-_]+)[\s\n]*=[\s\n]*([^\s\n""']+?) # attribute name, attribute value unquoted
                                              |[\s\n]+([a-zA-Z0-9-_]+)[\s\n]*=[\s\n]*(""[^\n]+?"")  # attribute name, attribute value qouted double
                                              |[\s\n]+([a-zA-Z0-9-_]+)[\s\n]*=[\s\n]*('[^\n]+?')    # attribute name, attribute value unqouted single
                                              |[\s\n]+([a-zA-Z0-9-_]+) )*                           # attribute name
                                            [\s\n]*
                                            (/?>)                                                   # punctuation element end
                                          
                                          |(&\#?[A-Za-z0-9]+?;)",
                                         RegexOptions.Compiled),
                       Scopes = new[]
                                {
                                    null,
                                    "comment.block.html",
                                    
                                    "punctuation.definition.tag.html",
                                    "entity.name.tag.doctype.html",
                                    "entity.other.attribute-name.html",
                                    "string.quoted.double.html",
                                    "punctuation.definition.tag.html",

                                    "punctuation.definition.tag.html",
                                    "entity.name.tag.html",
                                    "entity.other.attribute-name.html",
                                    "string.unquoted.html",
                                    "entity.other.attribute-name.html",
                                    "string.quoted.double.html",
                                    "entity.other.attribute-name.html",
                                    "string.quoted.single.html",
                                    "entity.other.attribute-name.html",
                                    "punctuation.definition.tag.html",
                                    ".js",
                                    "punctuation.definition.tag.html",
                                    "entity.name.tag.html",
                                    "punctuation.definition.tag.html",

                                    "punctuation.definition.tag.html",
                                    "entity.name.tag.namespace.html",
                                    "punctuation.definition.tag.namespace.html",
                                    "entity.name.tag.html",
                                    "entity.other.attribute-name.html",
                                    "string.unquoted.html",
                                    "entity.other.attribute-name.html",
                                    "string.quoted.double.html",
                                    "entity.other.attribute-name.html",
                                    "string.quoted.single.html",
                                    "entity.other.attribute-name.html",
                                    "punctuation.definition.tag.html",
                                    
                                    "constant.character.entity.html",
                                }
                   };
        }
    }
}