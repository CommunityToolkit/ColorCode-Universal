using System.Collections.Generic;
using System.Text.RegularExpressions;
using ColorCode.Parsing;

namespace ColorCode.Compilation.Languages
{
    public static partial class Grammars
    {
        private static ILanguageDefinition aspxVb;

        public static ILanguageDefinition AspxVb
        {
            get
            {
                if (aspxVb == null) 
                    BuildAspxVb();
                
                return aspxVb;
            }
        }

        private static void BuildAspxVb()
        {
            aspxVb = new CompiledGrammar
                     {
                         Id = "aspx.vb",
                         Name = "ASPX (VB.NET)",
                         FileExtensions = new[]
                                          {
                                              "aspx",
                                              "ascx",
                                              "asmx",
                                              "svc",
                                              "master"
                                          },
                         FirstLineMatch = @"(?xims)<%@\s*?(?:page|control|master|webhandler|servicehost|webservice).*?language=""vb"".*?%>",
                         Regex = new Regex(@"(?xism)
                                           (<%)(--.*?--)(%>)
                                           
                                           |(<!--.*?-->)
                                           
                                           |(<%)(@)(?:\s+([a-zA-Z0-9]+))*(?:\s+([a-zA-Z0-9]+)\s*(=)\s*(""[^\n]*?""))*\s*?(%>)
                                           
                                           |(?:(<%=|<%)(?!=|@|--))(.*?)(%>)

                                           |(?<=<script.+?runat=""server"".*?>)(.+?)(?=</script>)
                                           
                                           |(<!)(DOCTYPE)(?:\s+([a-zA-Z0-9]+))*(?:\s+(""[^""]*?""))*(>)

                                           |(?<=<script.+?language="".*?javascript"".*?>)(.+?)(?=</script>)

                                           |(</?)                                                   # punctuation element begin
                                            (?: ([a-z][a-z0-9-]*)(:) )*                             # element namespace name, element punctuation element
                                            ([a-z][a-z0-9-_]*)                                      # element name
                                            (?:
                                               [\s\n]+([a-zA-Z0-9-_]+)[\s\n]*=[\s\n]*(?:'(<%\#)(.+?)(%>)')  # attribute name, attribute value qouted double, embedded punctuation begin, embedded code, embedded punctuation end                 
                                              |[\s\n]+([a-zA-Z0-9-_]+)[\s\n]*=[\s\n]*(?:""(<%\#)(.+?)(%>)"")  # attribute name, attribute value qouted single, embedded punctuation begin, embedded code, embedded punctuation end                 
                                              |[\s\n]+([a-zA-Z0-9-_]+)[\s\n]*=[\s\n]*([^\s\n""']+?) # attribute name, attribute value unquoted
                                              |[\s\n]+([a-zA-Z0-9-_]+)[\s\n]*=[\s\n]*(""[^\n]+?"")  # attribute name, attribute value qouted double
                                              |[\s\n]+([a-zA-Z0-9-_]+)[\s\n]*=[\s\n]*('[^\n]+?')    # attribute name, attribute value unqouted single
                                              |[\s\n]+([a-zA-Z0-9-_]+) )*                           # attribute name
                                            [\s\n]*
                                            (/?>)                                                   # punctuation element end
                                           
                                           |(&[A-Za-z0-9]+?;)",
                                           RegexOptions.Compiled),
                         Scopes = new[]
                                  {
                                      null,
                                      "punctuation.section.embedded.begin.aspx.vb",
                                      "comment.block.html",
                                      "punctuation.section.embedded.end.aspx.vb",
                                      "comment.block.html",
                                      "punctuation.section.embedded.begin.aspx.vb",
                                      "punctuation.section.declaration.aspx.vb",
                                      "entity.name.tag.html",
                                      "entity.other.attribute-name.html",
                                      "punctuation.section.declaration.aspx.vb",
                                      "string.quoted.double.html",
                                      "punctuation.section.embedded.end.aspx.vb",

                                      "punctuation.section.embedded.begin.aspx.vb",
                                      ".vb",
                                      "punctuation.section.embedded.end.aspx.vb",

                                      ".vb",
                                      
                                      "punctuation.definition.tag.html",
                                      "entity.name.tag.doctype.html",
                                      "entity.other.attribute-name.html",
                                      "string.quoted.double.html",
                                      "punctuation.definition.tag.html",

                                      ".js",

                                      "punctuation.definition.tag.html",
                                      "entity.name.tag.namespace.html",
                                      "punctuation.definition.tag.namespace.html",
                                      "entity.name.tag.html",
                                      "entity.other.attribute-name.html",
                                      "punctuation.section.embedded.begin.aspx.vb",
                                      ".vb",
                                      "punctuation.section.embedded.end.aspx.vb",
                                      "entity.other.attribute-name.html",
                                      "punctuation.section.embedded.begin.aspx.vb",
                                      ".vb",
                                      "punctuation.section.embedded.end.aspx.vb",
                                      "entity.other.attribute-name.html",
                                      "string.unquoted.html",
                                      "entity.other.attribute-name.html",
                                      "string.quoted.double.html",
                                      "entity.other.attribute-name.html",
                                      "string.quoted.single.html",
                                      "entity.other.attribute-name.html",
                                      "punctuation.definition.tag.html",

                                      "constant.character.entity.html"
                                  }
                     };
        }
    }
}