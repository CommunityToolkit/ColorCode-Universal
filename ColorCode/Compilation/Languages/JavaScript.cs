using System.Collections.Generic;
using ColorCode.Common;

namespace ColorCode.Compilation.Languages
{
    public class JavaScript : ILanguage
    {
//        private static ILanguageDefinition js;

//        public static ILanguageDefinition JavaScript
//        {
//            get
//            {
//                if (js == null) 
//                    BuildJs();
                
//                return js;
//            }
//        }

//        private static void BuildJs()
//        {
//            js = new CompiledGrammar
//                 {
//                     Id = "js",
//                     Name = "JavaScript",
//                     FileExtensions = new[]
//                                      {
//                                          "js"
//                                      },
//                     Regex = new Regex(@"(?x)
//                                       (/\*.*?\*/) # comment.block.js
//                                       |(//[^\r\n]*?)\r?$ # comment.line.js
//                                       |('[^\n]*?') # string.quoted.single.js
//                                       |(""[^\n]*?"") # string.quoted.double.js
//                                       |\b(abstract|boolean|break|byte|case|catch|char|class|const|continue|debugger|default|delete|do|double|else|enum|export|extends|false|final|finally|float|for|function|goto|if|implements|import|in|instanceof|int|interface|long|native|new|null|package|private|protected|public|return|short|static|super|switch|synchronized|this|throw|throws|transient|true|try|typeof|var|void|volatile|while|with)\b # keyword.js",
//                                       RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.Compiled),
//                     Scopes = new[]
//                              {
//                                  null,
//                                  "comment.block.js",
//                                  "comment.line.js",
//                                  "string.quoted.single.js",
//                                  "string.quoted.double.js",
//                                  "keyword.js"
//                              }
//                 };
//        }

        public string Id
        {
            get { return LanguageId.JavaScript; }
        }

        public string Name
        {
            get { return "JavaScript"; }
        }

        public IList<LanguageRule> Rules
        {
            get
            {
                return new List<LanguageRule>
                           {
                               new LanguageRule(
                                   @"(?s)/\*.*\*/",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.Comment },
                                       }),
                               new LanguageRule(
                                   @"(//.*?)\r?$",
                                   new Dictionary<int, string>
                                       {
                                           { 1, ScopeName.Comment },
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
                               new LanguageRule(
                                   @"\b(abstract|boolean|break|byte|case|catch|char|class|const|continue|debugger|default|delete|do|double|else|enum|export|extends|false|final|finally|float|for|function|goto|if|implements|import|in|instanceof|int|interface|long|native|new|null|package|private|protected|public|return|short|static|super|switch|synchronized|this|throw|throws|transient|true|try|typeof|var|void|volatile|while|with)\b",
                                   new Dictionary<int, string>
                                       {
                                           { 1, ScopeName.Keyword },
                                       }),
                           };
            }
        }
    }
}