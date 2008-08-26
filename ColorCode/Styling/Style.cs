using System.Drawing;
using ColorCode.Common;

namespace ColorCode.Styling
{
    public class Style
    {
        public Style(string scopeName)
        {
            Guard.ArgNotNullAndNotEmpty(scopeName, "scopeName");
            
            ScopeName = scopeName;
        }
        
        public Color Background { get; set; }
        public Color Foreground { get; set; }
        public string ScopeName { get; set; }

        public override string ToString()
        {
            return ScopeName ?? string.Empty;
        }
    }
}