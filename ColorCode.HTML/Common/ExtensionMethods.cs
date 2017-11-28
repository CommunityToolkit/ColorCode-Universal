// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Drawing;

namespace ColorCode.HTML.Common
{
    public static class ExtensionMethods
    {
        public static string ToHtmlColor(this Color color)
        {
            if (color == Color.Empty)
                throw new ArgumentException("You may not create a hex string from an empty color.");

            return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}",
                     color.A,
                     color.R,
                     color.G,
                     color.B);
        }
    }
}