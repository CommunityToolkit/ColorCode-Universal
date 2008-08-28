// Copyright (c) Microsoft Corporation.  All rights reserved.

using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
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
            parsedSourceCode = HtmlEncode(parsedSourceCode, scopes);

            List<TextInsertion> styleInsertions = new List<TextInsertion>();

            foreach (Scope scope in scopes)
                GetStyleInsertionsForCapturedStyle(scope, styleInsertions, styleSheet);

            styleInsertions.SortStable((x, y) => x.Index.CompareTo(y.Index));

            int offset = 0;

            string formattedSourceCode = parsedSourceCode;

            foreach (TextInsertion styleInsertion in styleInsertions)
            {
                formattedSourceCode = formattedSourceCode.Insert(styleInsertion.Index + offset, styleInsertion.Text);
                offset += styleInsertion.Text.Length;
            }

            textWriter.Write(formattedSourceCode);
        }

        public void WriteFooter(IStyleSheet styleSheet,
                                TextWriter textWriter)
        {
            Guard.ArgNotNull(styleSheet, "styleSheet");
            Guard.ArgNotNull(textWriter, "textWriter");
            
            textWriter.WriteLine();
            WriteHeaderPreEnd(textWriter);
            WriteHeaderDivEnd(textWriter);
        }

        public void WriteHeader(IStyleSheet styleSheet,
                                TextWriter textWriter)
        {
            Guard.ArgNotNull(styleSheet, "styleSheet");
            Guard.ArgNotNull(textWriter, "textWriter");
            
            WriteHeaderDivStart(styleSheet, textWriter);
            WriteHeaderPreStart(textWriter);
            textWriter.WriteLine();
        }

        private static void GetStyleInsertionsForCapturedStyle(Scope scope,
                                                               ICollection<TextInsertion> styleInsertions,
                                                               IStyleSheet styleSheet)
        {
            styleInsertions.Add(new TextInsertion {
                                                      Index = scope.Index,
                                                      Text = BuildSpanForCapturedStyle(scope, styleSheet)
                                                  });


            foreach (Scope childScope in scope.Children)
                GetStyleInsertionsForCapturedStyle(childScope, styleInsertions, styleSheet);

            styleInsertions.Add(new TextInsertion {
                                                      Index = scope.Index + scope.Length,
                                                      Text = "</span>"
                                                  });
        }

        private static string BuildSpanForCapturedStyle(Scope scope,
                                                        IStyleSheet styleSheet)
        {
            Color foreground = Color.Empty;
            Color background = Color.Empty;

            if (styleSheet.Styles.Contains(scope.Name))
            {
                Style style = styleSheet.Styles[scope.Name];

                foreground = style.Foreground;
                background = style.Background;
            }

            return BuildStyledElement("span", foreground, background);
        }

        private static string BuildStyledElement(string elementName,
                                                 Color foreground,
                                                 Color background)
        {
            StringBuilder buffer = new StringBuilder();

            buffer.AppendFormat("<{0} style=\"", elementName);

            if (foreground != Color.Empty)
                buffer.AppendFormat("color:{0};", foreground.ToHtmlColor());

            if (background != Color.Empty)
                buffer.AppendFormat("background-color:{0};", background.ToHtmlColor());

            buffer.Append("\">");

            return buffer.ToString();
        }

        private static string HtmlEncode(string parsedSourceCode,
                                         IList<Scope> scopes)
        {
            StringBuilder encodedSourceCodeFragment = new StringBuilder();

            int cursor = 0;

            for (int i = 0; i < parsedSourceCode.Length; i++)
            {
                char c = parsedSourceCode[i];

                string encodedValue = HttpUtility.HtmlEncode(c.ToString());

                if (encodedValue != c.ToString())
                {
                    encodedSourceCodeFragment.Append(encodedValue);
                    IncreaseCapturedStyleIndicies(scopes, cursor, encodedValue.Length - 1);
                    cursor += encodedValue.Length;
                }
                else
                {
                    encodedSourceCodeFragment.Append(c);
                    cursor += 1;
                }
            }

            return encodedSourceCodeFragment.ToString();
        }

        private static void IncreaseCapturedStyleIndicies(IList<Scope> capturedStyles,
                                                          int startIndex,
                                                          int amountToIncrease)
        {
            for (int i = 0; i < capturedStyles.Count; i++)
            {
                Scope scope = capturedStyles[i];

                if (scope.Index > startIndex)
                    scope.Index += amountToIncrease;
                else if (startIndex >= scope.Index && startIndex < scope.Index + scope.Length)
                    scope.Length += amountToIncrease;

                if (scope.Children.Count > 0)
                    IncreaseCapturedStyleIndicies(scope.Children, startIndex, amountToIncrease);
            }
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

            WriteElementStart("div", foreground, background, writer);
        }

        private static void WriteElementStart(string elementName,
                                              TextWriter writer)
        {
            WriteElementStart(elementName, Color.Empty, Color.Empty, writer);
        }

        private static void WriteElementStart(string elementName,
                                              Color foreground,
                                              Color background,
                                              TextWriter writer)
        {
            writer.Write("<{0}", elementName);

            if (foreground != Color.Empty || background != Color.Empty)
            {
                writer.Write(" style=\"");

                if (foreground != Color.Empty)
                    writer.Write("color:{0};", foreground.ToHtmlColor());

                if (background != Color.Empty)
                    writer.Write("background-color:{0};", background.ToHtmlColor());

                writer.Write("\"");
            }

            writer.Write(">");
        }
    }
}