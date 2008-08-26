using System.Collections.Generic;
using System.IO;
using ColorCode.Parsing;

namespace ColorCode.Stubs
{
    internal class StubFormatter : IFormatter
    {
        public IStyleSheet WriteFooter__styleSheet;
        public TextWriter WriteFooter__writer;
        public IStyleSheet WriteHeader__styleSheet;
        public TextWriter writeHeader__textWriter;
        public Stack<string> Write__parsedSourceCode = new Stack<string>();

        public void Write(string parsedSourceCode,
                          IList<Scope> scopes,
                          IStyleSheet styleSheet,
                          TextWriter textWriter)
        {
            Write__parsedSourceCode.Push(parsedSourceCode);
        }

        public void WriteFooter(IStyleSheet styleSheet,
                                TextWriter textWriter)
        {
            WriteFooter__writer = textWriter;
            WriteFooter__styleSheet = styleSheet;
        }

        public void WriteHeader(IStyleSheet styleSheet,
                                TextWriter textWriter)
        {
            writeHeader__textWriter = textWriter;
            WriteHeader__styleSheet = styleSheet;
        }
    }
}