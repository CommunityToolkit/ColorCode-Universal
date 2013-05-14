// Copyright (c) Microsoft Corporation.  All rights reserved.

using System.Collections.Generic;
using ColorCode.Common;

namespace ColorCode.Compilation.Languages
{
    public class Markdown : ILanguage
    {
        public string Id
        {
            get { return LanguageId.Markdown; }
        }

        public string Name
        {
            get { return "Markdown"; }
        }

        public string CssClassName
        {
            get { return "markdown"; }
        }

        public string FirstLinePattern
        {
            get
            {
                return null;
            }
        }
        
        public IList<LanguageRule> Rules
        {
            get
            {
                return new List<LanguageRule>
                           {
                               // Heading
                               new LanguageRule(
                                   @"^(\#.*)\r?|^.*\r?\n([-]+|[=]+)\r?$",    
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.MarkdownHeader },
                                       }),


                               // code block
                               new LanguageRule(
                                   @"^([ ]{4}(?![ ])(?:.|\r?\n[ ]{4})*)|^(```+\w*)((?:[ \t\r\n]|.)*?)(^```+)[ \t]*\r?$",    
                                   new Dictionary<int, string>
                                       {
                                           { 1, ScopeName.MarkdownCode },
                                           { 2, ScopeName.XmlDocTag },
                                           { 3, ScopeName.MarkdownCode },
                                           { 4, ScopeName.XmlDocTag },
                                       }),

                               // Line
                               new LanguageRule(
                                   @"^\s*((-\s*){3}|(\*\s*){3}|(=\s*){3})[ \t\-\*=]*\r?$",    
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.MarkdownHeader }, 
                                       }),

                               
                               // List
                               new LanguageRule(
                                   @"^[ \t]*([\*\+\-]|\d+\.)",    
                                   new Dictionary<int, string>
                                       {
                                           { 1, ScopeName.MarkdownListItem }, 
                                       }),

                               // link
                               new LanguageRule(
                                   @"(\[[^\]]*\])(\([^\)]*\))",
                                   new Dictionary<int, string>
                                       {
                                           { 1, ScopeName.MarkdownBold }, 
                                           { 2, ScopeName.XmlDocTag },    // nice gray
                                       }),
                               // bold
                               new LanguageRule(
                                   @"\*[^\*\n]+?\*",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.MarkdownBold }, 
                                       }),

                               // emphasized 
                               new LanguageRule(
                                   @"_[^_\n]+?_",    
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.MarkdownEmph }, 
                                       }),
                               // inline code
                               new LanguageRule(
                                   @"`[^`\n]+?`|""[^""\n]+?""|'[\w\-_]+'",    
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.MarkdownCode }, 
                                       }),

                               // html tag
                               new LanguageRule(
                                   @"</?\w.*?>",    
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.HtmlTagDelimiter },
                                       }),
                               // html entity
                               new LanguageRule(
                                   @"\&\#?\w+?;",    
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.HtmlEntity },
                                       }),
                           };
            }
        }

        public bool HasAlias(string lang)
        {
            switch (lang.ToLower())
            {
                case "md":
                case "markdown":
                    return true;

                default:
                    return false;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}