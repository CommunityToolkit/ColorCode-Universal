// Copyright (c) Microsoft Corporation.  All rights reserved.

using System.IO;

namespace ColorCode
{
    public interface ICodeColorizer
    {
        void Colorize(string sourceCode,
                      ILanguage language,
                      IFormatter formatter,
                      IStyleSheet styleSheet,
                      TextWriter textWriter);
    }
}