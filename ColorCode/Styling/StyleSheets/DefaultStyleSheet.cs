using System.Drawing;
using ColorCode.Common;

namespace ColorCode.Styling.StyleSheets
{
    public class DefaultStyleSheet : IStyleSheet
    {
        public readonly static Color DullRed = Color.FromArgb(163, 21, 21);
        
        public string Name { get { return "DefaultStyleSheet"; } }

        public StyleDictionary Styles
        {
            get
            {
                return new StyleDictionary
                           {
                               new Style(ScopeName.PlainText)
                                   {
                                       Foreground = Color.Black,
                                       Background = Color.White
                                   },
                               new Style(ScopeName.HtmlServerSideScript)
                                   {
                                       Background = Color.Yellow
                                   },
                               new Style(ScopeName.HtmlComment)
                                   {
                                       Foreground = Color.Green
                                   },
                               new Style(ScopeName.HtmlTagDelimiter)
                                   {
                                       Foreground = Color.Blue
                                   },
                               new Style(ScopeName.HtmlElementName)
                                   {
                                       Foreground = DullRed
                                   },
                               new Style(ScopeName.HtmlAttributeName)
                                   {
                                       Foreground = Color.Red
                                   },
                               new Style(ScopeName.HtmlAttributeValue)
                                   {
                                       Foreground = Color.Blue
                                   },
                               new Style(ScopeName.HtmlOperator)
                                   {
                                       Foreground = Color.Blue
                                   },
                               new Style(ScopeName.Comment)
                                   {
                                       Foreground = Color.Green
                                   },
                               new Style(ScopeName.XmlDocTag)
                                   {
                                       Foreground = Color.Gray
                                   },
                               new Style(ScopeName.XmlDocComment)
                                   {
                                       Foreground = Color.Green
                                   },
                               new Style(ScopeName.String)
                                   {
                                       Foreground = DullRed
                                   },
                               new Style(ScopeName.StringCSharpVerbatim)
                                   {
                                       Foreground = DullRed
                                   },
                               new Style(ScopeName.Keyword)
                                   {
                                       Foreground = Color.Blue
                                   },
                               new Style(ScopeName.PreprocessorKeyword)
                                   {
                                       Foreground = Color.Blue
                                   },
                               new Style(ScopeName.HtmlEntity)
                                   {
                                       Foreground = Color.Red
                                   },    
                               new Style(ScopeName.XmlAttribute)
                                   {
                                       Foreground = Color.Red
                                   },
                               new Style(ScopeName.XmlAttributeQuotes)
                                   {
                                       Foreground = Color.Black
                                   },
                               new Style(ScopeName.XmlAttributeValue)
                                   {
                                       Foreground = Color.Blue
                                   },
                               new Style(ScopeName.XmlCDataSection)
                                   {
                                       Foreground = Color.Gray
                                   },
                               new Style(ScopeName.XmlComment)
                                   {
                                       Foreground = Color.Green
                                   },
                               new Style(ScopeName.XmlDelimiter)
                                   {
                                       Foreground = Color.Blue
                                   },
                               new Style(ScopeName.XmlName)
                                   {
                                       Foreground = DullRed
                                   }
                           };
            }
        }
    }
}