using System.Collections.Generic;
using System.IO;
using ColorCode.Parsing;

namespace ColorCode.Stubs
{
    internal class StubFormatter : IFormatter
    {
        public IStyleSheet WriteFooter__styleSheet;
        public ILanguage WriteFooter__langauge;
        public TextWriter WriteFooter__writer;
        public IStyleSheet WriteHeader__styleSheet;
        public ILanguage WriteHeader__language;
        public TextWriter WriteHeader__textWriter;
        public Stack<string> Write__parsedSourceCode = new Stack<string>();

        public void Write(string parsedSourceCode,
                          IList<Scope> scopes,
                          IStyleSheet styleSheet,
                          TextWriter textWriter)
        {
            Write__parsedSourceCode.Push(parsedSourceCode);
        }

        public void WriteFooter(IStyleSheet styleSheet,
                                ILanguage language,
                                TextWriter textWriter)
        {
            WriteFooter__writer = textWriter;
            WriteFooter__langauge = language;
            WriteFooter__styleSheet = styleSheet;
        }

        public void WriteHeader(IStyleSheet styleSheet,
                                ILanguage language,
                                TextWriter textWriter)
        {
            WriteHeader__textWriter = textWriter;
            WriteHeader__language = language;
            WriteHeader__styleSheet = styleSheet;
        }
    }
}