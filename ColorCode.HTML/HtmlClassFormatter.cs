// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections.Generic;
using System.IO;
using ColorCode.Common;
using ColorCode.Parsing;
using System.Text;
using ColorCode.Styling;
using System.Net;
using ColorCode.HTML.Common;

namespace ColorCode
{
    /// <summary>
    /// Creates a <see cref="HtmlClassFormatter"/>, for creating HTML to display Syntax Highlighted code.
    /// </summary>
    public class HtmlClassFormatter : CodeColorizerBase
    {
        /// <summary>
        /// Creates a <see cref="HtmlClassFormatter"/>, for creating HTML to display Syntax Highlighted code, with Styles applied via CSS.
        /// </summary>
        /// <param name="Style">The Custom styles to Apply to the formatted Code.</param>
        /// <param name="languageParser">The language parser that the <see cref="HtmlClassFormatter"/> instance will use for its lifetime.</param>
        public HtmlClassFormatter(StyleDictionary Style = null, ILanguageParser languageParser = null) : base(Style, languageParser)
        {
        }

        private TextWriter Writer { get; set; }

        /// <summary>
        /// Creates the HTML Markup, which can be saved to a .html file.
        /// </summary>
        /// <param name="sourceCode">The source code to colorize.</param>
        /// <param name="language">The language to use to colorize the source code.</param>
        /// <returns>Colorised HTML Markup.</returns>
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

        /// <summary>
        /// Creates the CSS Markup, which can be saved to a .CSS file. <para/>
        /// This is required for Coloring the Html output. Be sure to reference the File from the HTML, or insert it inline to the Head.
        /// </summary>
        /// <returns></returns>
        public string GetCSSString()
        {
            var str = new StringBuilder();

            var plainText = Styles[ScopeName.PlainText];
            if (!string.IsNullOrWhiteSpace(plainText?.Background)) str.Append($"body{{background-color:{plainText.Background};}}");

            foreach (var style in Styles)
            {
                str.Append($" .{style.ReferenceName}{{");

                if (!string.IsNullOrWhiteSpace(style.Foreground))
                    str.Append($"color:{style.Foreground.ToHtmlColor()};");

                if (!string.IsNullOrWhiteSpace(style.Background))
                    str.Append($"color:{style.Background.ToHtmlColor()};");

                if (style.Italic)
                    str.Append("font-style: italic;");

                if (style.Bold)
                    str.Append("font-weight: bold;");

                str.Append("}");
            }

            return str.ToString();
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
                Writer.Write(WebUtility.HtmlEncode(parsedSourceCode.Substring(offset, styleInsertion.Index - offset)));
                if (string.IsNullOrEmpty(styleInsertion.Text))
                    BuildSpanForCapturedStyle(styleInsertion.Scope);
                else
                    Writer.Write(styleInsertion.Text);
                offset = styleInsertion.Index;
            }

            Writer.Write(WebUtility.HtmlEncode(parsedSourceCode.Substring(offset)));
        }

        private void WriteFooter(ILanguage language)
        {
            Guard.ArgNotNull(language, "language");

            Writer.WriteLine();
            WriteHeaderPreEnd();
            WriteHeaderDivEnd();
        }

        private void WriteHeader(ILanguage language)
        {
            Guard.ArgNotNull(language, "language");

            WriteHeaderDivStart(language);
            WriteHeaderPreStart();
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

        private void BuildSpanForCapturedStyle(Scope scope)
        {
            string cssClassName = "";

            if (Styles.Contains(scope.Name))
            {
                Style style = Styles[scope.Name];

                cssClassName = style.ReferenceName;
            }

            WriteElementStart("span", cssClassName);
        }

        private void WriteHeaderDivEnd()
        {
            WriteElementEnd("div");
        }

        private void WriteElementEnd(string elementName)
        {
            Writer.Write("</{0}>", elementName);
        }

        private void WriteHeaderPreEnd()
        {
            WriteElementEnd("pre");
        }

        private void WriteHeaderPreStart()
        {
            WriteElementStart("pre");
        }

        private void WriteHeaderDivStart(ILanguage language)
        {
            WriteElementStart("div", language.CssClassName);
        }

        private void WriteElementStart(string elementName)
        {
            WriteElementStart(elementName, "");
        }

        private void WriteElementStart(string elementName, string cssClassName)
        {
            Writer.Write("<{0}", elementName);
            if (!String.IsNullOrEmpty(cssClassName))
            {
                Writer.Write(" class=\"{0}\"", cssClassName);
            }
            Writer.Write(">");
        }
    }
}