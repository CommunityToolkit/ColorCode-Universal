using System.Collections.Generic;
using ColorCode.Common;

namespace ColorCode.Compilation
{
    public class LanguageRule
    {
        public LanguageRule(string regex,
                            IDictionary<int, string> captures)
        {
            Guard.ArgNotNullAndNotEmpty(regex, "regex");
            Guard.EnsureParameterIsNotNullAndNotEmpty(captures, "captures");

            Regex = regex;
            Captures = captures;
        }

        public string Regex { get; private set; }
        public IDictionary<int, string> Captures { get; private set; }
    }
}