// Copyright (c) Microsoft Corporation.  All rights reserved.   

using System.Collections.Generic;
using ColorCode.Common;

namespace ColorCode.Compilation.Languages
{
    public class Css : ILanguage
    {
        public string Id
        {
            get { return LanguageId.Css; }
        }

        public string Name
        {
            get { return "CSS"; }
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
                                   @"(?msi)(([a-z0-9#. -]+)\s*(?:,\s*|{))+(?:(\s*/\*.*?\*/)|(?:\s*([a-z0-9 -]+):\s*([a-z0-9#% -]+);))*\s*}",
                                   new Dictionary<int, string>
                                       {
                                           { 2, ScopeName.CssSelector },
                                           { 4, ScopeName.CssPropertyName },
                                           { 5, ScopeName.CssPropertyValue },
                                           { 3, ScopeName.Comment },
                                       }),
                           };
            }
        }
    }
}
