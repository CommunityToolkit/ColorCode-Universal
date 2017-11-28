// Copyright (c) Microsoft Corporation.  All rights reserved.

namespace ColorCode.Compilation
{
    public interface ILanguageCompiler
    {
        CompiledLanguage Compile(ILanguage language);
    }
}