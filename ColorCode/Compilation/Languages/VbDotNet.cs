// Copyright (c) Microsoft Corporation.  All rights reserved.

using System.Collections.Generic;
using ColorCode.Common;

namespace ColorCode.Compilation.Languages
{
    public class VbDotNet : ILanguage
    {
        public string Id
        {
            get { return LanguageId.VbDotNet; }
        }

        public string Name
        {
            get { return "VB.NET"; }
        }

        public string FirstLinePattern
        {
            get
            {
                return null;
            }
        }

        public IList<LanguageRule> Rules
        {
            get
            {
                return new List<LanguageRule>
                           {
                               new LanguageRule(
                                   @"('''[^\n]*?)\r?$",
                                   new Dictionary<int, string>
                                       {
                                           { 1, ScopeName.Comment },
                                       }),
                               new LanguageRule(
                                   @"((?:'|REM\s+).*?)\r?$",
                                   new Dictionary<int, string>
                                       {
                                           { 1, ScopeName.Comment },
                                       }),
                               new LanguageRule(
                                   @"""[^\n]*?""",
                                   new Dictionary<int, string>
                                       {
                                           { 0, ScopeName.String },
                                       }),
                               new LanguageRule(
                                   @"(?:\s|^)(\#End\sRegion|\#Region|\#Const|\#End\sExternalSource|\#ExternalSource|\#If|\#Else|\#End\sIf)(?:\s|\(|\r?$)",
                                   new Dictionary<int, string>
                                       {
                                           { 1, ScopeName.PreprocessorKeyword },
                                       }),
                               new LanguageRule(
                                   @"(?i)\b(AddHandler|AddressOf|Alias|And|AndAlso|Ansi|As|(?<!<)Assembly|Auto|Boolean|ByRef|Byte|ByVal|Call|Case|Catch|CBool|CByte|CChar|CDate|CDec|CDbl|Char|CInt|Class|CLng|CObj|Const|Continue|CShort|CSng|CStr|CType|Date|Decimal|Declare|Default|DefaultStyleSheet|Delegate|Dim|DirectCast|Do|Double|Each|Else|ElseIf|End|Enum|Erase|Error|Event|Exit|Explicit|False|Finally|For|Friend|Function|Get|GetType|GoSub|GoTo|Handles|If|Implements|Imports|In|Inherits|Integer|Interface|Is|IsNot|Let|Lib|Like|Long|Loop|Me|Mod|Module|MustInherit|MustOverride|My|MyBase|MyClass|Namespace|New|Next|Not|Nothing|NotInheritable|NotOverridable|(?<!\.)Object|Off|On|Option|Optional|Or|OrElse|Overloads|Overridable|Overrides|ParamArray|Partial|Preserve|Private|Property|Protected|Public|RaiseEvent|ReadOnly|ReDim|RemoveHandler|Resume|Return|Select|Set|Shadows|Shared|Short|Single|Static|Step|Stop|String|Structure|Sub|SyncLock|Then|Throw|To|True|Try|TypeOf|Unicode|Until|Variant|When|While|With|WithEvents|WriteOnly|Xor|SByte|UInteger|ULong|UShort|Using|CSByte|CUInt|CULng|CUShort)\b",
                                   new Dictionary<int, string>
                                       {
                                           { 1, ScopeName.Keyword },
                                       }),
                           };
            }
        }
    }
}