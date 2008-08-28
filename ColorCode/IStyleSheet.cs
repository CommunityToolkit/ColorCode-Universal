// Copyright (c) Microsoft Corporation.  All rights reserved.

using ColorCode.Styling;

namespace ColorCode
{
    public interface IStyleSheet
    {
        string Name { get; }
        StyleDictionary Styles { get; }
    }
}