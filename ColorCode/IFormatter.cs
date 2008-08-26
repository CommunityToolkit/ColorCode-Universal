using System.Collections.Generic;
using System.IO;
using ColorCode.Parsing;

namespace ColorCode
{
    public interface IFormatter
    {
        void Write(string parsedSourceCode,
                   IList<Scope> scopes,
                   IStyleSheet styleSheet,
                   TextWriter textWriter);

        void WriteFooter(IStyleSheet styleSheet,
                         TextWriter textWriter);

        void WriteHeader(IStyleSheet styleSheet,
                         TextWriter textWriter);
    }
}