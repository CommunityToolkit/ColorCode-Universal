using System.Collections.Generic;
using ColorSyntax.Common;

namespace ColorSyntax.Compilation.Languages
{
    public class Diff : ILanguage
    {
        public string Id
        {
            get { return LanguageId.Fortran; }
        }

        public string Name
        {
            get { return "Fortran"; }
        }

        public string CssClassName
        {
            get { return "fortran"; }
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
                               // Comments
                                new LanguageRule(
                                   @"(?m)(^\+.*$)|(^!.*$)",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.Addition },
                                       }),
                                new LanguageRule(
                                   @"(?m)^\-.*$",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.Deletion },
                                       }),
                                new LanguageRule(
                                   @"(?m)^@@.*@@$",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.Type },
                                       }),
                                new LanguageRule(
                                   @"(?m)^((---)|(\+\+\+)|(\*\*\*)) +\d+,\d+ +((----)|(\+\+\+\+)|(\*\*\*\*))",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.Type },
                                       }),
                                new LanguageRule(
                                   @"(?m)^((Index:)|(={3,})|(\+{3})|(\*{3})|(\-{3})).*$",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.Brackets },
                                       }),
                                new LanguageRule(
                                   @"(?m)^(\*{5}).*(\*{5})$",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.Brackets },
                                       }),

                           };
            }
        }

        public bool HasAlias(string lang)
        {
            switch (lang.ToLower())
            {
                case "diff":
                    return true;
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
