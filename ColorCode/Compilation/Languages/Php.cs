// Copyright (c) Microsoft Corporation.  All rights reserved.

using System.Collections.Generic;
using ColorCode.Common;

namespace ColorCode.Compilation.Languages
{
    public class Php : ILanguage
    {
        public string Id
        {
            get { return LanguageId.Php; }
        }

        public string Name
        {
            get { return "PHP"; }
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
                               new LanguageRule(
                                   @"/\*([^*]|[\r\n]|(\*+([^*/]|[\r\n])))*\*+/",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.Comment },
                                       }),
                               new LanguageRule(
                                   @"(//.*?)\r?$",
                                   new Dictionary<int, string>
                                       {
                                           { 1, ScopeName.Comment },
                                       }),
                               new LanguageRule(
                                   @"(#.*?)\r?$",
                                   new Dictionary<int, string>
                                       {
                                           { 1, ScopeName.Comment },
                                       }),
                               new LanguageRule(
                                   @"'[^\n]*?'",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.String },
                                       }),
                               new LanguageRule(
                                   @"""[^\n]*?""",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.String },
                                       }),
                               new LanguageRule(
                                   @"\b(abstract|and|array|as|break|case|catch|class|clone|const|continue|declare|default|die|do|echo|else|elseif|empty|enddeclare|endfor|endforeach|endif|endswitch|endwhile|exit|extends|eval|final|for|foreach|function|global|goto|if|implements|include|include_once|interface|instanceof|isset|list|namespace|new|or|print|private|protected|public|require|require_once|return|static|throw|try|unset|use|var|while|xor)\b",
                                   new Dictionary<int, string>
                                       {
                                           { 1, ScopeName.Keyword },
                                       }),
                           };
            }
        }
    }
}
