// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

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