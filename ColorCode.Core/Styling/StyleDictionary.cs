// Copyright (c) Microsoft Corporation.  All rights reserved.

using ColorCode.Common;
using System.Collections.ObjectModel;

namespace ColorCode.Styling
{
    /// <summary>
    /// A dictionary of <see cref="Style" /> instances, keyed by the styles' scope name.
    /// </summary>
    public class StyleDictionary : KeyedCollection<string, Style>
    {
        /// <summary>
        /// When implemented in a derived class, extracts the key from the specified element.
        /// </summary>
        /// <param name="item">The element from which to extract the key.</param>
        /// <returns>The key for the specified element.</returns>
        protected override string GetKeyForItem(Style item)
        {
            return item.ScopeName;
        }

        public static StyleDictionary Default
        {
            get
            {
                var blue = "#FF0000FF";
                var white = "#FFFFFFFF";
                var black = "#FF000000";
                var dullRed = "#FFA31515";
                var yellow = "#FFFFFF00";
                var green = "#FF008000";
                var powderBlue = "#FFB0E0E6";
                var teal = "#FF008080";
                var gray = "#FF808080";
                var navy = "#FF000080";
                var orangeRed = "#FFFF4500";
                var purple = "#FF800080";
                var red = "#FFFF0000";
                var mediumTurqoise = "FF48D1CC";
                var magenta = "FFFF00FF";
                var oliveDrab = "#FF6B8E23";
                var darkOliveGreen = "#FF556B2F";
                var darkCyan = "#FF008B8B";

                return new StyleDictionary
                {
                    new Style(ScopeName.PlainText)
                    {
                        Foreground = black,
                        Background = white,
                        ReferenceName = "plainText"
                    },
                    new Style(ScopeName.HtmlServerSideScript)
                    {
                        Background = yellow,
                        ReferenceName = "htmlServerSideScript"
                    },
                    new Style(ScopeName.HtmlComment)
                    {
                        Foreground = green,
                        ReferenceName = "htmlComment"
                    },
                    new Style(ScopeName.HtmlTagDelimiter)
                    {
                        Foreground = blue,
                        ReferenceName = "htmlTagDelimiter"
                    },
                    new Style(ScopeName.HtmlElementName)
                    {
                        Foreground = dullRed,
                        ReferenceName = "htmlElementName"
                    },
                    new Style(ScopeName.HtmlAttributeName)
                    {
                        Foreground = red,
                        ReferenceName = "htmlAttributeName"
                    },
                    new Style(ScopeName.HtmlAttributeValue)
                    {
                        Foreground = blue,
                        ReferenceName = "htmlAttributeValue"
                    },
                    new Style(ScopeName.HtmlOperator)
                    {
                        Foreground = blue,
                        ReferenceName = "htmlOperator"
                    },
                    new Style(ScopeName.Comment)
                    {
                        Foreground = green,
                        ReferenceName = "comment"
                    },
                    new Style(ScopeName.XmlDocTag)
                    {
                        Foreground = gray,
                        ReferenceName = "xmlDocTag"
                    },
                    new Style(ScopeName.XmlDocComment)
                    {
                        Foreground = green,
                        ReferenceName = "xmlDocComment"
                    },
                    new Style(ScopeName.String)
                    {
                        Foreground = dullRed,
                        ReferenceName = "string"
                    },
                    new Style(ScopeName.StringCSharpVerbatim)
                    {
                        Foreground = dullRed,
                        ReferenceName = "stringCSharpVerbatim"
                    },
                    new Style(ScopeName.Keyword)
                    {
                        Foreground = blue,
                        ReferenceName = "keyword"
                    },
                    new Style(ScopeName.PreprocessorKeyword)
                    {
                        Foreground = blue,
                        ReferenceName = "preprocessorKeyword"
                    },
                    new Style(ScopeName.HtmlEntity)
                    {
                        Foreground = red,
                        ReferenceName = "htmlEntity"
                    },
                    new Style(ScopeName.XmlAttribute)
                    {
                        Foreground = red,
                        ReferenceName = "xmlAttribute"
                    },
                    new Style(ScopeName.XmlAttributeQuotes)
                    {
                        Foreground = black,
                        ReferenceName = "xmlAttributeQuotes"
                    },
                    new Style(ScopeName.XmlAttributeValue)
                    {
                        Foreground = blue,
                        ReferenceName = "xmlAttributeValue"
                    },
                    new Style(ScopeName.XmlCDataSection)
                    {
                        Foreground = gray,
                        ReferenceName = "xmlCDataSection"
                    },
                    new Style(ScopeName.XmlComment)
                    {
                        Foreground = green,
                        ReferenceName = "xmlComment"
                    },
                    new Style(ScopeName.XmlDelimiter)
                    {
                        Foreground = blue,
                        ReferenceName = "xmlDelimiter"
                    },
                    new Style(ScopeName.XmlName)
                    {
                        Foreground = dullRed,
                        ReferenceName = "xmlName"
                    },
                    new Style(ScopeName.ClassName)
                    {
                        Foreground = mediumTurqoise,
                        ReferenceName = "className"
                    },
                    new Style(ScopeName.CssSelector)
                    {
                        Foreground = dullRed,
                        ReferenceName = "cssSelector"
                    },
                    new Style(ScopeName.CssPropertyName)
                    {
                        Foreground = red,
                        ReferenceName = "cssPropertyName"
                    },
                    new Style(ScopeName.CssPropertyValue)
                    {
                        Foreground = blue,
                        ReferenceName = "cssPropertyValue"
                    },
                    new Style(ScopeName.SqlSystemFunction)
                    {
                        Foreground = magenta,
                        ReferenceName = "sqlSystemFunction"
                    },
                    new Style(ScopeName.PowerShellAttribute)
                    {
                        Foreground = powderBlue,
                        ReferenceName = "powershellAttribute"
                    },
                    new Style(ScopeName.PowerShellOperator)
                    {
                        Foreground = gray,
                        ReferenceName = "powershellOperator"
                    },
                    new Style(ScopeName.PowerShellType)
                    {
                        Foreground = teal,
                        ReferenceName = "powershellType"
                    },
                    new Style(ScopeName.PowerShellVariable)
                    {
                        Foreground = orangeRed,
                        ReferenceName = "powershellVariable"
                    },

                    new Style(ScopeName.Type)
                    {
                        Foreground = teal,
                        ReferenceName = "type"
                    },
                    new Style(ScopeName.TypeVariable)
                    {
                        Foreground = teal,
                        Italic = true,
                        ReferenceName = "typeVariable"
                    },
                    new Style(ScopeName.NameSpace)
                    {
                        Foreground = navy,
                        ReferenceName = "namespace"
                    },
                    new Style(ScopeName.Constructor)
                    {
                        Foreground = purple,
                        ReferenceName = "constructor"
                    },
                    new Style(ScopeName.Predefined)
                    {
                        Foreground = navy,
                        ReferenceName = "predefined"
                    },
                    new Style(ScopeName.PseudoKeyword)
                    {
                        Foreground = navy,
                        ReferenceName = "pseudoKeyword"
                    },
                    new Style(ScopeName.StringEscape)
                    {
                        Foreground = gray,
                        ReferenceName = "stringEscape"
                    },
                    new Style(ScopeName.ControlKeyword)
                    {
                        Foreground = blue,
                        ReferenceName = "controlKeyword"
                    },
                    new Style(ScopeName.Number)
                    {
                        ReferenceName = "number"
                    },
                    new Style(ScopeName.Operator)
                    {
                        ReferenceName = "operator"
                    },
                    new Style(ScopeName.Delimiter)
                    {
                        ReferenceName = "delimiter"
                    },

                    new Style(ScopeName.MarkdownHeader)
                    {
                        Foreground = blue,
                        Bold = true,
                        ReferenceName = "markdownHeader"
                    },
                    new Style(ScopeName.MarkdownCode)
                    {
                        Foreground = teal,
                        ReferenceName = "markdownCode"
                    },
                    new Style(ScopeName.MarkdownListItem)
                    {
                        Bold = true,
                        ReferenceName = "markdownListItem"
                    },
                    new Style(ScopeName.MarkdownEmph)
                    {
                        Italic = true,
                        ReferenceName = "italic"
                    },
                    new Style(ScopeName.MarkdownBold)
                    {
                        Bold = true,
                        ReferenceName = "bold"
                    },

                    new Style(ScopeName.BuiltinFunction)
                    {
                        Foreground = oliveDrab,
                        Bold = true,
                        ReferenceName = "builtinFunction"
                    },
                    new Style(ScopeName.BuiltinValue)
                    {
                        Foreground = darkOliveGreen,
                        Bold = true,
                        ReferenceName = "builtinValue"
                    },
                    new Style(ScopeName.Attribute)
                    {
                        Foreground = darkCyan,
                        Italic = true,
                        ReferenceName = "attribute"
                    },
                    new Style(ScopeName.SpecialCharacter)
                    {
                        ReferenceName = "specialChar"
                    },
                };
            }
        }
    }
}