// Copyright (c) Microsoft Corporation.  All rights reserved.

using System.IO;

namespace ColorCode
{
    public interface ICodeColorizer
    {
        string Colorize(string sourceCode,
                        ILanguage language);

        void Colorize(string sourceCode,
                      ILanguage language,
                      TextWriter textWriter);

        void Colorize(string sourceCode,
                      ILanguage language,
                      IFormatter formatter,
                      IStyleSheet styleSheet,
                      TextWriter textWriter);
    }
}