using ColorCode.Styling.StyleSheets;

namespace ColorCode
{
    public static class StyleSheets
    {
        public static IStyleSheet Default { get { return new DefaultStyleSheet(); }}
    }
}
