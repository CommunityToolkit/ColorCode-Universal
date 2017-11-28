// Copyright (c) Microsoft Corporation.  All rights reserved.

using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using ColorCode.Common;
using ColorCode.Parsing;
using System.Text;
using ColorCode.HTML.Common;

namespace ColorCode
{
    public class HtmlFormatter : CodeColorizerBase
    {
        public HtmlFormatter(IStyleSheet styleSheet = null) : base()
        {
            StyleSheet = styleSheet ?? StyleSheets.Default;
        }

        public HtmlFormatter(ILanguageParser Parser, IStyleSheet styleSheet = null) : base(Parser)
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
            Writer.WriteLine();
            WriteHeaderPreEnd(Writer);
            WriteHeaderDivEnd(Writer);
        }

        private void WriteHeader(ILanguage language)
        {
            WriteHeaderDivStart(StyleSheet, Writer);
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

        private static void BuildSpanForCapturedStyle(Scope scope, IStyleSheet styleSheet, TextWriter writer)
        {
            Color foreground = Color.Empty;
            Color background = Color.Empty;
            bool italic = false;
            bool bold = false;

            if (styleSheet.Styles.Contains(scope.Name))
            {
                Style style = styleSheet.Styles[scope.Name];

                foreground = style.Foreground;
                background = style.Background;
                italic = style.Italic;
                bold = style.Bold;
            }

            WriteElementStart(writer, "span", foreground, background, italic, bold);
        }

        private static void WriteHeaderDivEnd(TextWriter writer)
        {
            WriteElementEnd("div", writer);
        }

        private static void WriteElementEnd(string elementName, TextWriter writer)
        {
            writer.Write("</{0}>", elementName);
        }

        private static void WriteHeaderPreEnd(TextWriter writer)
        {
            WriteElementEnd("pre", writer);
        }

        private static void WriteHeaderPreStart(TextWriter writer)
        {
            WriteElementStart(writer, "pre");
        }

        private static void WriteHeaderDivStart(IStyleSheet styleSheet, TextWriter writer)
        {
            Color foreground = Color.Empty;
            Color background = Color.Empty;

            if (styleSheet.Styles.Contains(ScopeName.PlainText))
            {
                Style plainTextStyle = styleSheet.Styles[ScopeName.PlainText];

                foreground = plainTextStyle.Foreground;
                background = plainTextStyle.Background;
            }

            WriteElementStart(writer, "div", foreground, background);
        }

        private static void WriteElementStart(TextWriter writer, string elementName)
        {
            WriteElementStart(writer, elementName, Color.Empty, Color.Empty);
        }

        private static void WriteElementStart(TextWriter writer, string elementName, Color foreground, Color background, bool italic = false, bool bold = false)
        {
            writer.Write("<{0}", elementName);

            if (foreground != Color.Empty || background != Color.Empty || italic || bold)
            {
                writer.Write(" style=\"");

                if (foreground != Color.Empty)
                    writer.Write("color:{0};", foreground.ToHtmlColor());

                if (background != Color.Empty)
                    writer.Write("background-color:{0};", background.ToHtmlColor());

                if (italic)
                    writer.Write("font-style: italic;");

                if (bold)
                    writer.Write("font-weight: bold;");

                writer.Write("\"");
            }

            writer.Write(">");
        }
    }
}