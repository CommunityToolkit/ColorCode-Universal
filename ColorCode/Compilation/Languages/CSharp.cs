// Copyright (c) Microsoft Corporation.  All rights reserved.

using System.Collections.Generic;
using ColorCode.Common;

namespace ColorCode.Compilation.Languages
{
    public class CSharp : ILanguage
    {
        public string Id
        {
            get { return LanguageId.CSharp; }
        }

        public string Name
        {
            get { return "C#"; }
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
                                   @"/\*([^*]|[\r\n]|(\*+([^*/]|[\r\n])))*\*+/",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.Comment },
                                       }),
                               new LanguageRule(
                                   @"(///)(?:\s*?(<[/a-zA-Z0-9\s""=]+>))*(.*?)$",
                                   new Dictionary<int, string>
                                       {
                                           { 1, ScopeName.XmlDocTag },
                                           { 2, ScopeName.XmlDocTag },
                                           { 3, ScopeName.XmlDocComment },
                                       }),
                               new LanguageRule(
                                   @"(//.*?)\r?$",
                                   new Dictionary<int, string>
                                       {
                                           { 1, ScopeName.Comment }
                                       }),
                               new LanguageRule(
                                   @"'[^\n]*?'",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.String }
                                       }),
                               new LanguageRule(
                                   @"(?s)@""(?:""""|.)*?""(?!"")",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.StringCSharpVerbatim }
                                       }),
                               new LanguageRule(
                                   @"(?s)(""[^\n]*?"")",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.String }
                                       }),
                               new LanguageRule(
                                   @"\[(assembly|module|type|return|param|method|field|property|event):.*?\]",
                                   new Dictionary<int, string>
                                       {
                                           { 1, ScopeName.Keyword }
                                       }),
                               new LanguageRule(
                                   @"^\s*(\#define|\#elif|\#else|\#endif|\#endregion|\#error|\#if|\#line|\#pragma|\#region|\#undef|\#warning).*?$",
                                   new Dictionary<int, string>
                                       {
                                           { 1, ScopeName.PreprocessorKeyword }
                                       }),
                               new LanguageRule(
                                   @"\b(abstract|as|base|bool|break|byte|case|catch|char|checked|class|const|continue|decimal|default|delegate|do|double|else|enum|event|explicit|extern|false|finally|fixed|float|for|foreach|get|goto|if|implicit|in|int|interface|internal|is|lock|long|namespace|new|null|object|operator|out|override|params|partial|private|protected|public|readonly|ref|return|sbyte|sealed|set|short|sizeof|stackalloc|static|string|struct|switch|this|throw|true|try|typeof|uint|ulong|unchecked|unsafe|ushort|using|virtual|void|volatile|while)\b",
                                   new Dictionary<int, string>
                                       {
                                           { 1, ScopeName.Keyword }
                                       }),
                           };
            }
        }
    }
}