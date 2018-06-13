// Copyright (c) 2015 Christopher Pardi.

// Copyright (c) Microsoft Corporation.  All rights reserved.

using System.Collections.Generic;
using ColorSyntax.Common;

namespace ColorSyntax.Compilation.Languages
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
                                   @"(?m)^(((---)|(\*\*\*)) +\d+,\d+ +((----)|(\*\*\*\*))|@@ +\-\d+,\d+ \+\d+,\d+ +@@)",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.DiffMeta },
                                       }),
                               new LanguageRule(
                                   @"(?m)^(\*{5}).*(\*{5})$",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.Brackets },
                                       }),
                               new LanguageRule(
                                   @"(?m)^((-{3,})|(\*{3,})|(\+{3,})|(Index:)|(={3,})).*$",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.Brackets },
                                       }),
                                new LanguageRule(
                                   @"(?m)(^(\+|!).*$)",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.DiffAddition },
                                       }),
                                new LanguageRule(
                                   @"(?m)^\-.*$",
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
