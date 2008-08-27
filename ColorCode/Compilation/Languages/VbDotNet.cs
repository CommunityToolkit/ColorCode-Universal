using System.Text.RegularExpressions;
using ColorCode.Parsing;

namespace ColorCode.Compilation.Languages
{
    public static partial class Grammars
    {
        private static ILanguageDefinition vb;

        public static ILanguageDefinition VbDotNet
        {
            get
            {
                if (vb == null) 
                    BuildVb();
                
                return vb;
            }
        }

        private static void BuildVb()
        {
            vb = new CompiledGrammar
                 {
                     Id = "vb",
                     Name = "VB.NET",
                     FileExtensions = new[]
                                      {
                                          "vb"
                                      },
                     Regex = new Regex(@"(?x)(?i)
                                       ((?:''')[^\n]*?)$
                                       |((?:'|REM\s+).*?)(?:\r\n|$)
                                       |(""[^\n]*?"")
                                       |(?:(?:\s|^)(\#End\sRegion|\#Region|\#Const|\#End\sExternalSource|\#ExternalSource|\#If|\#Else)(?:\s|\(|$))
                                       |\b(AddHandler|AddressOf|Alias|And|AndAlso|Ansi|As|(?<!<)Assembly|Auto|Boolean|ByRef|Byte|ByVal|Call|Case|Catch|CBool|CByte|CChar|CDate|CDec|CDbl|Char|CInt|Class|CLng|CObj|Const|Continue|CShort|CSng|CStr|CType|Date|Decimal|Declare|DefaultStyleSheet|Delegate|Dim|DirectCast|Do|Double|Each|Else|ElseIf|End|Enum|Erase|Error|Event|Exit|Explicit|False|Finally|For|Friend|Function|Get|GetType|GoSub|GoTo|Handles|If|Implements|Imports|In|Inherits|Integer|Interface|Is|IsNot|Let|Lib|Like|Long|Loop|Me|Mod|Module|MustInherit|MustOverride|My|MyBase|MyClass|Namespace|New|Next|Not|Nothing|NotInheritable|NotOverridable|(?<!\.)Object|Off|On|Option|Optional|Or|OrElse|Overloads|Overridable|Overrides|ParamArray|Partial|Preserve|Private|Property|Protected|Public|RaiseEvent|ReadOnly|ReDim|RemoveHandler|Resume|Return|Select|Set|Shadows|Shared|Short|Single|Static|Step|Stop|String|Structure|Sub|SyncLock|Then|Throw|To|True|Try|TypeOf|Unicode|Until|Variant|When|While|With|WithEvents|WriteOnly|Xor|SByte|UInteger|ULong|UShort|Using|CSByte|CUInt|CULng|CUShort)\b",
                                       RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.Compiled),
                     Scopes = new[]
                              {
                                  null,
                                  "comment.line.documentation.vb",
                                  "comment.line.vb",
                                  "string.quoted.double.vb",
                                  "keyword.vb",
                                  "keyword.vb"
                              }
                 };
        }
    }
}