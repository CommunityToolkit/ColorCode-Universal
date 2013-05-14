// Copyright (c) Microsoft Corporation.  All rights reserved.

using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using ColorCode.Common;
using ColorCode.Parsing;
using ColorCode.Styling;

namespace ColorCode.Formatting
{
    public class HtmlFormatter : IFormatter
    {
        public void Write(string parsedSourceCode,
                          IList<Scope> scopes,
                          IStyleSheet styleSheet,
                          TextWriter textWriter)
        {
            var styleInsertions = new List<TextInsertion>();

            foreach (Scope scope in scopes)
                GetStyleInsertionsForCapturedStyle(scope, styleInsertions);

            styleInsertions.SortStable((x, y) => x.Index.CompareTo(y.Index));

            int offset = 0;

            foreach (TextInsertion styleInsertion in styleInsertions)
            {
                textWriter.Write(HttpUtility.HtmlEncode(parsedSourceCode.Substring(offset, styleInsertion.Index - offset)));
                if (string.IsNullOrEmpty(styleInsertion.Text))
                    BuildSpanForCapturedStyle(styleInsertion.Scope, styleSheet, textWriter);
                else
                    textWriter.Write(styleInsertion.Text);
                offset = styleInsertion.Index;
            }

            textWriter.Write(HttpUtility.HtmlEncode(parsedSourceCode.Substring(offset)));
        }

        public void WriteFooter(IStyleSheet styleSheet,
                                ILanguage language,
                                TextWriter textWriter)
        {
            Guard.ArgNotNull(styleSheet, "styleSheet");
            Guard.ArgNotNull(textWriter, "textWriter");
            
            textWriter.WriteLine();
            WriteHeaderPreEnd(textWriter);
            WriteHeaderDivEnd(textWriter);
        }

        public void WriteHeader(IStyleSheet styleSheet,
                                ILanguage language,
                                TextWriter textWriter)
        {
            Guard.ArgNotNull(styleSheet, "styleSheet");
            Guard.ArgNotNull(textWriter, "textWriter");
            
            WriteHeaderDivStart(styleSheet, textWriter);
            WriteHeaderPreStart(textWriter);
            textWriter.WriteLine();
        }

        private static void GetStyleInsertionsForCapturedStyle(Scope scope, ICollection<TextInsertion> styleInsertions)
        {
            styleInsertions.Add(new TextInsertion {
                                                      Index = scope.Index,
                                                      Scope = scope
                                                  });


            foreach (Scope childScope in scope.Children)
                GetStyleInsertionsForCapturedStyle(childScope, styleInsertions);

            styleInsertions.Add(new TextInsertion {
                                                      Index = scope.Index + scope.Length,
                                                      Text = "</span>"
                                                  });
        }

        private static void BuildSpanForCapturedStyle(Scope scope,
                                                        IStyleSheet styleSheet,
                                                        TextWriter writer)
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
            WriteElementStart(writer,"pre");
        }

        private static void WriteHeaderDivStart(IStyleSheet styleSheet,
                                                TextWriter writer)
        {
            Color foreground = Color.Empty;
            Color background = Color.Empty;

            if (styleSheet.Styles.Contains(ScopeName.PlainText))
            {
                Style plainTextStyle = styleSheet.Styles[ScopeName.PlainText];

                foreground = plainTextStyle.Foreground;
                background = plainTextStyle.Background;
            }

            WriteElementStart(writer, "div", foreground, background );
        }

        private static void WriteElementStart(TextWriter writer,
                                              string elementName)
        {
            WriteElementStart(writer, elementName, Color.Empty, Color.Empty);
        }

        private static void WriteElementStart(TextWriter writer,
                                              string elementName,
                                              Color foreground,
                                              Color background,
                                              bool italic = false,
                                              bool bold = false
                                              )
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