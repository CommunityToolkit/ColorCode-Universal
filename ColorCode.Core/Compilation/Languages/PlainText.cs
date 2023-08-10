// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using ColorCode.Common;

namespace ColorCode.Compilation.Languages
{
    public class PlainText : ILanguage
    {
        public string Id
        {
            get { return LanguageId.PlainText; }
        }

        public string Name
        {
            get { return "TEXT"; }
        }

        public string CssClassName
        {
            get { return "text"; }
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
                                   ".*",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.PlainText },
                                       }),
                           };
            }
        }

        public bool HasAlias(string lang)
        {
            return false;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}