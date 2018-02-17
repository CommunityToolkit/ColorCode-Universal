using System.Collections.Generic;
using ColorCode.Parsing;
using Windows.UI.Xaml.Controls;
using ColorCode.Styling;
using Windows.UI.Text;
using ColorCode.UWP.Common;
using ColorCode.Common;
using Windows.UI.Xaml;
using System.Text.RegularExpressions;

namespace ColorCode
{
    /// <summary>
    /// Creates a <see cref="RichTextBlockFormatter"/>, for rendering Syntax Highlighted code to a RichTextBlock.
    /// </summary>
    public class RichEditBoxFormatter : CodeColorizerBase
    {
        /// <summary>
        /// Creates a <see cref="RichTextBlockFormatter"/>, for rendering Syntax Highlighted code to a RichTextBlock.
        /// </summary>
        /// <param name="Theme">The Theme to use, determines whether to use Default Light or Default Dark.</param>
        public RichEditBoxFormatter(ElementTheme Theme, ILanguageParser languageParser = null) : this(Theme == ElementTheme.Dark ? StyleDictionary.DefaultDark : StyleDictionary.DefaultLight, languageParser)
        {
        }

        /// <summary>
        /// Creates a <see cref="RichTextBlockFormatter"/>, for rendering Syntax Highlighted code to a RichTextBlock.
        /// </summary>
        /// <param name="Style">The Custom styles to Apply to the formatted Code.</param>
        /// <param name="languageParser">The language parser that the <see cref="RichTextBlockFormatter"/> instance will use for its lifetime.</param>
        public RichEditBoxFormatter(StyleDictionary Style = null, ILanguageParser languageParser = null) : base(Style, languageParser)
        {
        }

        private RichEditBox RichEdit { get; set; }

        public ILanguage Language
        {
            get => _Language;
            set
            {
                _Language = value;
                UpdateText();
            }
        }

        private ILanguage _Language;

        /// <summary>
        /// Adds Syntax Highlighted Source Code to the provided RichTextBlock.
        /// </summary>
        /// <param name="sourceCode">The source code to colorize.</param>
        /// <param name="language">The language to use to colorize the source code.</param>
        /// <param name="RichEdit">The Control to add the Text to.</param>
        public void AttachRichEditBox(RichEditBox RichEdit, ILanguage Language)
        {
            this.RichEdit = RichEdit;
            RichEdit.TextChanging += RichEdit_TextChanging;
            this.Language = Language;
        }

        private void RichEdit_TextChanging(RichEditBox sender, RichEditBoxTextChangingEventArgs args)
        {
            if (args.IsContentChanging)
            {
                UpdateText();
            }
        }

        public void UpdateText()
        {
            if (RichEdit != null)
            {
                // Attempt to get Scrollviewer offsets, to preserve location.
                var scroll = VisualHelpers.FirstChildofType<ScrollViewer>(RichEdit);
                var vertOffset = scroll?.VerticalOffset;
                var horOffset = scroll?.HorizontalOffset;

                var selection = RichEdit.Document.Selection;
                var selectionStart = selection.StartPosition;
                var selectionEnd = selection.EndPosition;

                RichEdit.Document.GetText(TextGetOptions.UseCrlf, out string raw);
                RichEdit.Document.Undo();

                RichEdit.Document.BeginUndoGroup();
                RichEdit.Document.SetText(TextSetOptions.None, raw);

                var newSelection = RichEdit.Document.Selection;
                newSelection.StartPosition = selectionStart;
                newSelection.EndPosition = selectionEnd;

                Index = 0;
                source = raw;

                languageParser.Parse(raw, Language, (range, captures) => Style(range, captures));
                RichEdit.Document.ApplyDisplayUpdates();
                RichEdit.Document.EndUndoGroup();

                if (scroll != null)
                {
                    scroll.ChangeView(horOffset, vertOffset, null, true);
                }
            }
        }

        private static int Index = 0;
        private static string source = string.Empty;

        protected void Style(string range, IList<Scope> scopes)
        {
            var scopeRange = source.Substring(Index);

            var start = Index;

            try
            {
                var previous = source.Remove(Index);
                var crlfCorrection = CountOccurences(previous, "\r\n");
                start -= crlfCorrection;
            }
            catch
            {
            }

            var subIndex = scopeRange.IndexOf(range);
            if (subIndex != -1)
            {
                start += subIndex;
            }

            foreach (var scope in scopes)
            {
                StyleFromScope(start, scope);
            }

            Index += range.Length;
        }

        private int CountOccurences(string str, string match)
        {
            return Regex.Matches(str, match).Count;
        }

        private void StyleFromScope(int Start, Scope Scope)
        {
            Start += Scope.Index;
            var Range = RichEdit.Document.GetRange(Start, Start + Scope.Length);

            string foreground = null;
            string background = null;
            bool italic = false;
            bool bold = false;

            if (Styles.Contains(Scope.Name))
            {
                Styling.Style style = Styles[Scope.Name];

                foreground = style.Foreground;
                background = style.Background;
                italic = style.Italic;
                bold = style.Bold;
            }

            if (!string.IsNullOrWhiteSpace(foreground))
            {
                Range.CharacterFormat.ForegroundColor = foreground.GetColor();
            }

            if (!string.IsNullOrWhiteSpace(background))
            {
                Range.CharacterFormat.BackgroundColor = background.GetColor();
            }

            if (italic)
                Range.CharacterFormat.Italic = FormatEffect.On;

            if (bold)
                Range.CharacterFormat.Bold = FormatEffect.On;

            foreach (var subScope in Scope.Children)
            {
                StyleFromScope(Start, subScope);
            }
        }

        private void Reset(ITextRange Range)
        {
            var defaults = RichEdit.Document.GetDefaultCharacterFormat();
            Range.CharacterFormat.Italic = FormatEffect.Off;
            Range.CharacterFormat.Bold = FormatEffect.Off;
            Range.CharacterFormat.BackgroundColor = defaults.BackgroundColor;
            Range.CharacterFormat.ForegroundColor = defaults.ForegroundColor;
        }
    }
}