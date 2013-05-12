// Copyright (c) Microsoft Corporation.  All rights reserved.

using System.Collections.Generic;
using ColorCode.Common;

namespace ColorCode.Compilation.Languages
{
    public class Haskell : ILanguage
    {
        public string Id
        {
            get { return LanguageId.Haskell; }
        }

        public string Name
        {
            get { return "Haskell"; }
        }

        public string CssClassName
        {
            get { return "haskell"; }
        }

        public string FirstLinePattern
        {
            get
            {
                return null;
            }
        }

        private const string incomment = @"([^-{}]|{+[^-]|-+[^}]|(?<!-)})*";
        private const string keywords = @"case|class|data|default|deriving|do|else|foreign|if|import|in|infix|infixl|infixr|instance|let|module|newtype|of|then|type|where";
        private const string opKeywords = @"\.\.|:|::|=|\\|\||<-|->|@|~|=>";
        private const string symbol = @"\!|\#|$|%|\&|\⋆|\+|\.|/|<|=|>|\?|@|\\|^|\||-|~|:";
        
        private const string intype = @"(\bforall\b|=>)|(?:[A-Z]\w*\.)*[A-Z]\w*|(?!where|data|type|newtype|instance|class)([a-z]\w*)|\->|[ \t\r]|\n[ \t]+(?:[\(\)\[\]]|->|=>)";
        private const string toptype = "(?:" + intype + "|::)";
        private const string nestedtype = @"(?:" + intype + ")";


        public IList<LanguageRule> Rules
        {
            get
            {
                return new List<LanguageRule> {
                    // Nested block comments
                    new LanguageRule(
                        // Handle nested block comments using named balanced groups
                        @"{-+" + incomment +
                        @"(" +
                        @"((?<comment>{-)" + incomment + ")+" +
                        @"((?<-comment>-})" + incomment + ")+" +
                        @")*" +
                        @"(-+})",
                        new Dictionary<int, string>
                            {
                                { 0, ScopeName.Comment },
                            }),
           
           
                    // Line comments
                    new LanguageRule(
                        @"(--.*?)\r?$",
                        new Dictionary<int, string>
                            {
                                { 1, ScopeName.Comment }
                            }),    
        
                    // Types
                    new LanguageRule(
                        // Type highlighting using named balanced groups to balance parenthesized sub types
                        // 'toptype' and 'nestedtype' capture two groups: type keyword and type variables 
                        @"(?:" + @"\b(type|data|class|instance|deriving|newtype)\b|"
                                + @"::(?!" + symbol + ")"  + ")" 
                                + toptype + "*" +
                        @"(?:" +
                            @"(?:(?<type>[\(\[<])(?:" + nestedtype + @"|[,]" + @")*)+" +
                            @"(?:(?<-type>[\)\]>])(?:" + nestedtype + @"|(?(type)[,])" + @")*)+" +
                        @")*",
                        new Dictionary<int,string> {
                            { 0, ScopeName.Type },
                    
                            { 1, ScopeName.Keyword },   // type struct etc
                    
                            { 2, ScopeName.Keyword},
                            { 3, ScopeName.TypeVariable },
                    
                            { 4, ScopeName.Keyword },
                            { 5, ScopeName.TypeVariable },
                    
                            { 6, ScopeName.Keyword },
                            { 7, ScopeName.TypeVariable },                
                        }),

                    // Special sequences
                    new LanguageRule(
                        @"\b(module|as)\s+((?:[A-Z]\w*\.)*[A-Z]\w*)",
                        new Dictionary<int, string>
                            {
                                { 1, ScopeName.Keyword },
                                { 2, ScopeName.NameSpace }
                            }),
    
                    new LanguageRule(
                        @"\b(import)\s+(qualified\s+)?((?:[A-Z]\w*\.)*[A-Z]\w*)",
                        new Dictionary<int, string>
                            {
                                { 1, ScopeName.Keyword },
                                { 2, ScopeName.Keyword },
                                { 3, ScopeName.NameSpace }
                            }),
    
                    // Keywords
                    new LanguageRule(
                        @"\b(" + keywords + @")\b",
                        new Dictionary<int, string>
                            {
                                { 1, ScopeName.Keyword },
                            }),
                    new LanguageRule(
                        @"(?<!" + symbol +")(" + opKeywords + ")(?!" + symbol + ")",
                        new Dictionary<int, string>
                            {
                                { 1, ScopeName.Keyword },
                            }),
                                   
                    // Names
                    new LanguageRule(
                        @"([A-Z]\w*\.)*([a-z]\w*|\((" + symbol + @")+\))",
                        new Dictionary<int, string>
                            {
                                { 1, ScopeName.NameSpace }
                            }),
                    new LanguageRule(
                        @"([A-Z]\w*\.)*([A-Z]\w*)",
                        new Dictionary<int, string>
                            {
                                { 1, ScopeName.NameSpace },
                                { 2, ScopeName.Constructor }
                            }),

                    // Operators and punctuation
                    new LanguageRule(
                        "(" + symbol + ")+",
                        new Dictionary<int, string>
                            {
                                { 0, ScopeName.Operator }
                            }),

                    new LanguageRule(
                        @"[{}\(\)\[\];,]",
                        new Dictionary<int, string>
                            {
                                { 0, ScopeName.Delimiter }
                            }),

                    // Literals
                    new LanguageRule(
                        @"0[xX][\da-fA-F]+|\d+(\.\d+([eE][\-+]?\d+)?)?",
                        new Dictionary<int, string>
                            {
                                { 0, ScopeName.Number }
                            }),


                    new LanguageRule(
                        @"'[^\n]*?'",
                        new Dictionary<int, string>
                            {
                                { 0, ScopeName.String },
                            }),
                    new LanguageRule(
                        @"""[^\n]*?""",
                        new Dictionary<int, string>
                            {
                                { 0, ScopeName.String },
                            }),
                };
            }
        }

        public bool HasAlias(string lang)
        {
            switch (lang.ToLower())
            {
                case "hs":
                    return true;

                default:
                    return false;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}