// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using ColorCode.Common;

namespace ColorCode.Compilation.Languages
{
    /// <summary>
    /// Leverage the regex from https://gist.github.com/goodmami/02f344e8c9a22fc9ac879230a9b9e071#version-2
    /// for parsing the key, string value, number, and constant for a JSON code block.
    /// </summary>
    public class Json : ILanguage
    {
        private const string Regex_String = @"""[^""\\]*(?:\\[^\r\n]|[^""\\]*)*""";
        private const string Regex_Number = @"-?(?:0|[1-9][0-9]*)(?:\.[0-9]*)?(?:[eE][-+]?[0-9]+)?";

        public string Id
        {
            get { return LanguageId.Json; }
        }

        public string Name
        {
            get { return "JSON"; }
        }

        public string CssClassName
        {
            get { return "json"; }
        }

        public string FirstLinePattern
        {
            get { return null; }
        }

        public IList<LanguageRule> Rules
        {
            get
            {
                return new List<LanguageRule>
                           {
                               new LanguageRule(
                                   $@"[,\{{]\s*({Regex_String})\s*:",
                                   new Dictionary<int, string>
                                       {
                                           {1, ScopeName.JsonKey}
                                       }),
                               new LanguageRule(
                                   Regex_String,
                                   new Dictionary<int, string>
                                       {
                                           {0, ScopeName.JsonString}
                                       }),
                               new LanguageRule(
                                   Regex_Number,
                                   new Dictionary<int, string>
                                       {
                                           {0, ScopeName.JsonNumber}
                                       }),
                               new LanguageRule(
                                   @"\b(true|false|null)\b",
                                   new Dictionary<int, string>
                                       {
                                           {1, ScopeName.JsonConst}
                                       }),
                           };
            }
        }

        public bool HasAlias(string lang)
        {
            return false;
        }
    }
}
