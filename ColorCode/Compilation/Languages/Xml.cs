using System.Text.RegularExpressions;
using ColorCode.Parsing;

namespace ColorCode.Compilation.Languages
{
    public static partial class Grammars
    {
        private static ILanguageDefinition xml;

        public static ILanguageDefinition Xml
        {
            get
            {
                if (xml == null) 
                    BuildXml();
                
                return xml;
            }
        }

        private static void BuildXml()
        {
            xml = new CompiledGrammar
                  {
                      Id = "xml",
                      Name = "XML",
                      FileExtensions = new[]
                                       {
                                           "browser",
                                           "dbml",
                                           "xml", 
                                           "resx", 
                                           "vsdisco", 
                                           "webinfo", 
                                           "config",
                                           "vbproj",
                                           "csproj",
                                           "sln",
                                           "dtd",
                                           "xsl",
                                           "xslt",
                                           "xsd",
                                           "xaml",
                                           "settings",
                                           "sitemap"
                                       },
                      Regex = new Regex(@"(?xi)
                                            (<!--.*?-->)
                                            |(<!)(doctype)(?:\s+([a-z0-9]+))*(?:\s+(""[^\n]*?""))*(>)
                                            |(<\?)([a-z][a-z0-9-]*)(?:\s+([a-z0-9]+)=(""[^\n]*?""))*(?:\s+([a-z0-9]+)=(\'[^\n]*?\'))*\s*?(\?>)
                                            |(</?)(?:([a-z][a-z0-9\.-]*)(:))*([a-z][a-z0-9\.-]*?)(?:(?:\s+([a-z][a-z0-9\.-]*))*|(?:\s+([a-z][a-z0-9\.-:]*)\s*?=\s*?(""[^\n]*?""))*|(?:\s+([a-z][a-z0-9\.-:]*)\s*?=\s*?(\'[^\n]*?\'))*)\s*?(/?>)
                                            |(&[A-Za-z0-9]+?;)
                                            |(<!\[CDATA\[)(.*?)(\]\]>)",
                                        RegexOptions.Singleline | RegexOptions.Compiled),
                      Scopes = new[]
                               {
                                   null,
                                   "comment.block.xml",

                                   "punctuation.definition.tag.xml",
                                   "entity.name.tag.doctype.xml",
                                   "entity.other.attribute-name.xml",
                                   "string.quoted.double.xml",
                                   "punctuation.definition.tag.xml",
                                     
                                   "punctuation.definition.tag.xml",
                                   "entity.name.tag.xml",
                                   "entity.other.attribute-name.xml",
                                   "string.quoted.double.xml",
                                   "entity.other.attribute-name.xml",
                                   "string.quoted.single.xml",
                                   "punctuation.definition.tag.xml",

                                   "punctuation.definition.tag.xml",
                                   "entity.name.tag.namespace.xml",
                                   "punctuation.definition.tag.namespace.xml",
                                   "entity.name.tag.xml",
                                   "entity.other.attribute-name.xml",
                                   "entity.other.attribute-name.xml",
                                   "string.quoted.double.xml",
                                   "entity.other.attribute-name.xml",
                                   "string.quoted.single.xml",
                                   "punctuation.definition.tag.xml",

                                   "constant.character.entity.xml",

                                   "punctuation.definition.tag.xml",
                                   "string.unquoted.xml",
                                   "punctuation.definition.tag.xml"
                               },
                  };
        }
    }
}