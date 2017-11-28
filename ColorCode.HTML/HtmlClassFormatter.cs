using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using ColorCode.Common;
using ColorCode.Parsing;
using System.Text;

namespace ColorCode
{
    public class HtmlClassFormatter : CodeColorizerBase
    {
        public HtmlClassFormatter(IStyleSheet styleSheet = null) : base()
        {
            StyleSheet = styleSheet ?? StyleSheets.Default;
        }

        public HtmlClassFormatter(ILanguageParser Parser, IStyleSheet styleSheet = null) : base(Parser)
        {
            StyleSheet = styleSheet ?? StyleSheets.Default;
        }

        public IStyleSheet StyleSheet { get; }
        private TextWriter Writer { get; set; }

        public string GetHtmlString(string sourceCode, ILanguage language)
        {
            var buffer = new StringBuilder(sourceCode.Length * 2);

            using (TextWriter writer = new StringWriter(buffer))
            {
                Writer = writer;
                WriteHeader(language);

                languageParser.Parse(sourceCode, language, (parsedSourceCode, captures) => Write(parsedSourceCode, captures));

                WriteFooter(language);

                writer.Flush();
            }

            return buffer.ToString();
        }

        protected override void Write(string parsedSourceCode, IList<Scope> scopes)
        {
            var styleInsertions = new List<TextInsertion>();

            foreach (Scope scope in scopes)
                GetStyleInsertionsForCapturedStyle(scope, styleInsertions);

            styleInsertions.SortStable((x, y) => x.Index.CompareTo(y.Index));

            int offset = 0;

            foreach (TextInsertion styleInsertion in styleInsertions)
            {
                Writer.Write(HttpUtility.HtmlEncode(parsedSourceCode.Substring(offset, styleInsertion.Index - offset)));
                if (string.IsNullOrEmpty(styleInsertion.Text))
                    BuildSpanForCapturedStyle(styleInsertion.Scope, StyleSheet, Writer);
                else
                    Writer.Write(styleInsertion.Text);
                offset = styleInsertion.Index;
            }

            Writer.Write(HttpUtility.HtmlEncode(parsedSourceCode.Substring(offset)));
        }

        private void WriteFooter(ILanguage language)
        {
            Guard.ArgNotNull(language, "language");

            Writer.WriteLine();
            WriteHeaderPreEnd(Writer);
            WriteHeaderDivEnd(Writer);
        }

        private void WriteHeader(ILanguage language)
        {
            Guard.ArgNotNull(language, "language");

            WriteHeaderDivStart(StyleSheet, language, Writer);
            WriteHeaderPreStart(Writer);
            Writer.WriteLine();
        }

        private static void GetStyleInsertionsForCapturedStyle(Scope scope, ICollection<TextInsertion> styleInsertions)
        {
            styleInsertions.Add(new TextInsertion
            {
                Index = scope.Index,
                Scope = scope
            });

            foreach (Scope childScope in scope.Children)
                GetStyleInsertionsForCapturedStyle(childScope, styleInsertions);

            styleInsertions.Add(new TextInsertion
            {
                Index = scope.Index + scope.Length,
                Text = "</span>"
            });
        }

        private static void BuildSpanForCapturedStyle(Scope scope,
                                                        IStyleSheet styleSheet,
                                                        TextWriter writer)
        {
            string cssClassName = "";

            if (styleSheet.Styles.Contains(scope.Name))
            {
                Style style = styleSheet.Styles[scope.Name];

                cssClassName = style.CssClassName;
            }

            WriteElementStart("span", cssClassName, writer);
        }

        private static void WriteHeaderDivEnd(TextWriter writer)
        {
            WriteElementEnd("div", writer);
        }

        private static void WriteElementEnd(string elementName,
                                            TextWriter writer)
        {
            writer.Write("</{0}>", elementName);
        }

        private static void WriteHeaderPreEnd(TextWriter writer)
        {
            WriteElementEnd("pre", writer);
        }

        private static void WriteHeaderPreStart(TextWriter writer)
        {
            WriteElementStart("pre", writer);
        }

        private static void WriteHeaderDivStart(IStyleSheet styleSheet,
                                                ILanguage language,
                                                TextWriter writer)
        {
            WriteElementStart("div", language.CssClassName, writer);
        }

        private static void WriteElementStart(string elementName,
                                              TextWriter writer)
        {
            WriteElementStart(elementName, "", writer);
        }

        private static void WriteElementStart(string elementName,
                                              string cssClassName,
                                              TextWriter writer)
        {
            writer.Write("<{0}", elementName);
            if (!String.IsNullOrEmpty(cssClassName))
            {
                writer.Write(" class=\"{0}\"", cssClassName);
            }
            writer.Write(">");
        }
    }
}