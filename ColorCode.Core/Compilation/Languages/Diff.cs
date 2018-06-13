// Copyright (c) 2015 Christopher Pardi.

// Copyright (c) Microsoft Corporation.  All rights reserved.

using System.Collections.Generic;
using ColorCode.Common;

namespace ColorCode.Compilation.Languages
{
    public class Diff : ILanguage
    {
        public string Id
        {
            get { return LanguageId.Diff; }
        }

        public string Name
        {
            get { return "Diff"; }
        }

        public string CssClassName
        {
            get { return "diff"; }
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
                                   @"^(((---)|(\*\*\*)) +\d+,\d+ +((----)|(\*\*\*\*))|@@ +\-\d+,\d+ \+\d+,\d+ +@@)(\r?\n?)",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.DiffMeta },
                                       }),
                               new LanguageRule(
                                   @"^(\*{5}).*(\*{5})(\r?\n?)",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.DiffComment },
                                       }),
                               new LanguageRule(
                                   @"^((-{3,})|(\*{3,})|(\+{3,})|(Index:)|(={3,})).*(\r?\n?)",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.DiffComment },
                                       }),
                                new LanguageRule(
                                   @"(^(\+|!).*(\r?\n?))",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.DiffAddition },
                                       }),
                                new LanguageRule(
                                   @"^\-.*(\r?\n?)",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.DiffDeletion },
                                       }),
                           };
            }
        }

        public bool HasAlias(string lang)
        {
            switch (lang.ToLower())
            {
                case "diff":
                case "patch":
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
