using System.Collections.Generic;
using System.Text.RegularExpressions;
using ColorCode.Parsing;

namespace ColorCode.Compilation.Languages
{
    public static partial class Grammars
    {
        private static ILanguageDefinition aspxCs;

        public static ILanguageDefinition AspxCs
        {
            get
            {
                if (aspxCs == null) 
                    BuildAspxCs();
                
                return aspxCs;
            }
        }

        private static void BuildAspxCs()
        {
            aspxCs = new CompiledGrammar
                     {
                         Id = "aspx.cs",
                         Name = "ASPX (C#)",
                         FileExtensions = new[]
                                          {
                                              "aspx",
                                              "ascx",
                                              "asmx",
                                              "svc",
                                              "master"
                                          },
                         FirstLineMatch = @"(?xims)<%@\s*?(?:page|control|master|servicehost|webservice).*?(?:language=""c\#""|src="".+?.cs"").*?%>",
                         Regex = new Regex(@"(?xism)
                                           (<%)(--.*?--)(%>)
                                           
                                           |(<!--.*?-->)
                                           
                                           |(<%)(@)(?:\s+([a-zA-Z0-9]+))*(?:\s+([a-z0-9]+)\s*=\s*(""[^\n]*?""))*\s*?(%>)
                                           
                                           |(?:(<%=|<%)(?!=|@|--))(.*?)(%>)

                                           |(?<=<script.+?runat=""server"".*?>)(.+?)(?=</script>)
                                            
                                           |(<!)(DOCTYPE)(?:\s+([a-z0-9]+))*(?:\s+(""[^""]*?""))*(>)

                                           |(?<=<script.+?language="".*?javascript"".*?>)(.+?)(?=</script>)

                                           |(</?)                                                   # punctuation element begin
                                            (?: ([a-z][a-z0-9-]*)(:) )*                             # element namespace name, element punctuation element
                                            ([a-z][a-z0-9-_]*)                                      # element name
                                            (?:
                                               [\s\n]+([a-z0-9-_]+)[\s\n]*=[\s\n]*([^\s\n""']+?) # attribute name, attribute value unquoted
                                              |[\s\n]+([a-z0-9-_]+)[\s\n]*=[\s\n]*(""[^\n]+?"")  # attribute name, attribute value qouted double
                                              |[\s\n]+([a-z0-9-_]+)[\s\n]*=[\s\n]*('[^\n]+?')    # attribute name, attribute value unqouted single
                                              |[\s\n]+([a-z0-9-_]+) )*                           # attribute name
                                            [\s\n]*
                                            (/?>)                                                   # punctuation element end
                                           
                                           |(&[a-z0-9]+?;)",
                                           RegexOptions.Compiled),
                         Scopes = new[]
                                  {
                                      null,
                                      "punctuation.section.embedded.begin.aspx.cs",
                                      "comment.block.html",
                                      "punctuation.section.embedded.end.aspx.cs",
                                      "comment.block.html",
                                      "punctuation.section.embedded.begin.aspx.cs",
                                      "punctuation.section.declaration.aspx.cs",
                                      "entity.name.tag.html",
                                      "entity.other.attribute-name.html",
                                      "string.quoted.double.html",
                                      "punctuation.section.embedded.end.aspx.cs",

                                      "punctuation.section.embedded.begin.aspx.cs",
                                      ".cs",
                                      "punctuation.section.embedded.end.aspx.cs",

                                      ".cs",
                                      
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