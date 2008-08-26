using System;
using System.Collections.Generic;
using ColorCode.Parsing;

namespace ColorCode.Stubs
{
    public class StubLanguageParser : ILanguageParser
    {
        public string Parse__sourceCode;
        public ILanguage Parse__language;
        public Action<string, IList<Scope>> Parse__parseHandler;
        public Action<string, ILanguage, Action<string, IList<Scope>>> Parse__do;
        
        public void Parse(string sourceCode, ILanguage language, Action<string, IList<Scope>> parseHandler)
        {
            Parse__sourceCode = sourceCode;
            Parse__language = language;
            Parse__parseHandler = parseHandler;

            if (Parse__do != null)
                Parse__do(sourceCode, language, parseHandler);
        }
    }
}