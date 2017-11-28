// Copyright (c) Microsoft Corporation.  All rights reserved.

namespace ColorCode.HTML.Common
{
    public static class ExtensionMethods
    {
        public static string ToHtmlColor(this string color)
        {
            if (color == null) return null;

            var length = 6;
            var start = color.Length - length;
            return "#" + color.Substring(start, length);
        }
    }
}