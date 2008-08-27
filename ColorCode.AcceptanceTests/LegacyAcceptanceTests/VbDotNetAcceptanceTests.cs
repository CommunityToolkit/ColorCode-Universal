using System.IO;
using System.Text;
using Xunit;

namespace ColorCode
{
    public class VbDotNetAcceptanceTests
    {
        [Fact]
        public void TransformWillStyleImportStatement()
        {
            string source =
@"Imports System";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">Imports</span> System
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleImportStatementWithNestedNamespace()
        {
            string source =
@"Imports System.Regex";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">Imports</span> System.Regex
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleNamespaceStatement()
        {
            string source =
@"    Namespace My.Namespace";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
    <span style=""color:#0000FF;"">Namespace</span> <span style=""color:#0000FF;"">My</span>.<span style=""color:#0000FF;"">Namespace</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleDocComments()
        {
            string source =
@"''' <summary>";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#008000;"">''' &lt;summary&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleComments()
        {
            string source =
@"' this is a comment";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#008000;"">' this is a comment</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleDoubleQuotesStrings()
        {
            string source =
@"""this is a double-quoted string""";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#A31515;"">&quot;this is a double-quoted string&quot;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleClassDeclaration()
        {
            string source =
@"Public Class SomeClass
    Inherits SomeOtherClass
    Implements SomeInterface
End Class";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">Public</span> <span style=""color:#0000FF;"">Class</span> SomeClass
    <span style=""color:#0000FF;"">Inherits</span> SomeOtherClass
    <span style=""color:#0000FF;"">Implements</span> SomeInterface
<span style=""color:#0000FF;"">End</span> <span style=""color:#0000FF;"">Class</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleVariableDeclaration()
        {
            string source =
@"Private Const SomeVariable As String = ""SomeValue""";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">Private</span> <span style=""color:#0000FF;"">Const</span> SomeVariable <span style=""color:#0000FF;"">As</span> <span style=""color:#0000FF;"">String</span> = <span style=""color:#A31515;"">&quot;SomeValue&quot;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleSubBlock()
        {
            string source =
@"Protected Overridable Sub SomeEventHandler(ByVal e As EventArgs)
    If Not SomeEvent Is Nothing Then
        RaiseEvent Some(Me, e)
    End If
End Sub";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">Protected</span> <span style=""color:#0000FF;"">Overridable</span> <span style=""color:#0000FF;"">Sub</span> SomeEventHandler(<span style=""color:#0000FF;"">ByVal</span> e <span style=""color:#0000FF;"">As</span> EventArgs)
    <span style=""color:#0000FF;"">If</span> <span style=""color:#0000FF;"">Not</span> SomeEvent <span style=""color:#0000FF;"">Is</span> <span style=""color:#0000FF;"">Nothing</span> <span style=""color:#0000FF;"">Then</span>
        <span style=""color:#0000FF;"">RaiseEvent</span> Some(<span style=""color:#0000FF;"">Me</span>, e)
    <span style=""color:#0000FF;"">End</span> <span style=""color:#0000FF;"">If</span>
<span style=""color:#0000FF;"">End</span> <span style=""color:#0000FF;"">Sub</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FileExtensionsWillIncludeVb()
        {
            ILanguage language = Languages.VbDotNet;

            Assert.Contains("vb", language.FileExtensions);
        }

        [Fact]
        public void TransformWillStyleCastingFunctions()
        {
            string source =
@"CBool(foo)
CByte(foo)
CChar(foo)
CDate(foo)
CDec(foo)
CDbl(foo)
Char(foo)
CInt(foo)
CLng(foo)
CObj(foo)
CShort(foo)
CSng(foo)
CStr(foo)
CSByte(foo)
CUInt(foo)
CULng(foo)
CUShort(foo)";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">CBool</span>(foo)
<span style=""color:#0000FF;"">CByte</span>(foo)
<span style=""color:#0000FF;"">CChar</span>(foo)
<span style=""color:#0000FF;"">CDate</span>(foo)
<span style=""color:#0000FF;"">CDec</span>(foo)
<span style=""color:#0000FF;"">CDbl</span>(foo)
<span style=""color:#0000FF;"">Char</span>(foo)
<span style=""color:#0000FF;"">CInt</span>(foo)
<span style=""color:#0000FF;"">CLng</span>(foo)
<span style=""color:#0000FF;"">CObj</span>(foo)
<span style=""color:#0000FF;"">CShort</span>(foo)
<span style=""color:#0000FF;"">CSng</span>(foo)
<span style=""color:#0000FF;"">CStr</span>(foo)
<span style=""color:#0000FF;"">CSByte</span>(foo)
<span style=""color:#0000FF;"">CUInt</span>(foo)
<span style=""color:#0000FF;"">CULng</span>(foo)
<span style=""color:#0000FF;"">CUShort</span>(foo)
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleTypeNames()
        {
            string source =
@"String
Date
Decimal
Double
Enum
Integer
Long
Short
Single
Boolean
Byte
SByte
UInteger
ULong
UShort
Char
Structure";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">String</span>
<span style=""color:#0000FF;"">Date</span>
<span style=""color:#0000FF;"">Decimal</span>
<span style=""color:#0000FF;"">Double</span>
<span style=""color:#0000FF;"">Enum</span>
<span style=""color:#0000FF;"">Integer</span>
<span style=""color:#0000FF;"">Long</span>
<span style=""color:#0000FF;"">Short</span>
<span style=""color:#0000FF;"">Single</span>
<span style=""color:#0000FF;"">Boolean</span>
<span style=""color:#0000FF;"">Byte</span>
<span style=""color:#0000FF;"">SByte</span>
<span style=""color:#0000FF;"">UInteger</span>
<span style=""color:#0000FF;"">ULong</span>
<span style=""color:#0000FF;"">UShort</span>
<span style=""color:#0000FF;"">Char</span>
<span style=""color:#0000FF;"">Structure</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleAddHandlerStatement()
        {
            string source =
@"AddHandler event, AddressOf eventHandler";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">AddHandler</span> <span style=""color:#0000FF;"">event</span>, <span style=""color:#0000FF;"">AddressOf</span> eventHandler
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleDeclareStatement()
        {
            string source =
@"Declare Function FunctioName Lib ""some.dll"" Alias ""FunctionNameInDll"" (ByVal arg1 As String, ByRef arg2 As Integer) As Integer";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">Declare</span> <span style=""color:#0000FF;"">Function</span> FunctioName <span style=""color:#0000FF;"">Lib</span> <span style=""color:#A31515;"">&quot;some.dll&quot;</span> <span style=""color:#0000FF;"">Alias</span> <span style=""color:#A31515;"">&quot;FunctionNameInDll&quot;</span> (<span style=""color:#0000FF;"">ByVal</span> arg1 <span style=""color:#0000FF;"">As</span> <span style=""color:#0000FF;"">String</span>, <span style=""color:#0000FF;"">ByRef</span> arg2 <span style=""color:#0000FF;"">As</span> <span style=""color:#0000FF;"">Integer</span>) <span style=""color:#0000FF;"">As</span> <span style=""color:#0000FF;"">Integer</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillNotStyleObjectInSystemDotObject()
        {
            string source =
@"System.Object";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
System.Object
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleObjectInDimStatement()
        {
            string source =
@"Dim foo as Object";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">Dim</span> foo <span style=""color:#0000FF;"">as</span> <span style=""color:#0000FF;"">Object</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleLowerCaseKeywords()
        {
            string source =
@"dim foo as object";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">dim</span> foo <span style=""color:#0000FF;"">as</span> <span style=""color:#0000FF;"">object</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillNotStyleAssemblyKeywordInAttribute()
        {
            string source =
@"<Assembly: CLSCompliant(True)>";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
&lt;Assembly: CLSCompliant(<span style=""color:#0000FF;"">True</span>)&gt;
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleRegionDirectives()
        {
            string source =
@"#Region ""A comment""
' this is a comment
#End Region";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">#Region</span> <span style=""color:#A31515;"">&quot;A comment&quot;</span>
<span style=""color:#008000;"">' this is a comment</span>
<span style=""color:#0000FF;"">#End Region</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        } 

        [Fact]
        public void TransformWillStyleRemoveHandlerStatement()
        {
            string source =
@"Sub TestEvents()
    Dim Obj As New Class1
    ' Associate an event handler with an event.
    AddHandler Obj.Ev_Event, AddressOf EventHandler
    ' Call the method to raise the event.
    Obj.CauseSomeEvent()
    ' Stop handling events.
    RemoveHandler Obj.Ev_Event, AddressOf EventHandler
    ' This event will not be handled.
    Obj.CauseSomeEvent()
End Sub

Sub EventHandler()
    ' Handle the event.
    MsgBox(""EventHandler caught event."")
End Sub

Public Class Class1
    ' Declare an event.
    Public Event Ev_Event()
    Sub CauseSomeEvent()
        ' Raise an event.
        RaiseEvent Ev_Event()
    End Sub
End Class";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">Sub</span> TestEvents()
    <span style=""color:#0000FF;"">Dim</span> Obj <span style=""color:#0000FF;"">As</span> <span style=""color:#0000FF;"">New</span> Class1
    <span style=""color:#008000;"">' Associate an event handler with an event.</span>
    <span style=""color:#0000FF;"">AddHandler</span> Obj.Ev_Event, <span style=""color:#0000FF;"">AddressOf</span> EventHandler
    <span style=""color:#008000;"">' Call the method to raise the event.</span>
    Obj.CauseSomeEvent()
    <span style=""color:#008000;"">' Stop handling events.</span>
    <span style=""color:#0000FF;"">RemoveHandler</span> Obj.Ev_Event, <span style=""color:#0000FF;"">AddressOf</span> EventHandler
    <span style=""color:#008000;"">' This event will not be handled.</span>
    Obj.CauseSomeEvent()
<span style=""color:#0000FF;"">End</span> <span style=""color:#0000FF;"">Sub</span>

<span style=""color:#0000FF;"">Sub</span> EventHandler()
    <span style=""color:#008000;"">' Handle the event.</span>
    MsgBox(<span style=""color:#A31515;"">&quot;EventHandler caught event.&quot;</span>)
<span style=""color:#0000FF;"">End</span> <span style=""color:#0000FF;"">Sub</span>

<span style=""color:#0000FF;"">Public</span> <span style=""color:#0000FF;"">Class</span> Class1
    <span style=""color:#008000;"">' Declare an event.</span>
    <span style=""color:#0000FF;"">Public</span> <span style=""color:#0000FF;"">Event</span> Ev_Event()
    <span style=""color:#0000FF;"">Sub</span> CauseSomeEvent()
        <span style=""color:#008000;"">' Raise an event.</span>
        <span style=""color:#0000FF;"">RaiseEvent</span> Ev_Event()
    <span style=""color:#0000FF;"">End</span> <span style=""color:#0000FF;"">Sub</span>
<span style=""color:#0000FF;"">End</span> <span style=""color:#0000FF;"">Class</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleRemStatement()
        {
            string source =
@"Dim demoStr1, demoStr2 As String
demoStr1 = ""Hello"" REM Comment after a statement using REM.
demoStr2 = ""Goodbye"" ' Comment after a statement using the ' character.
REM This entire line is a comment.
' This entire line is also a comment.";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">Dim</span> demoStr1, demoStr2 <span style=""color:#0000FF;"">As</span> <span style=""color:#0000FF;"">String</span>
demoStr1 = <span style=""color:#A31515;"">&quot;Hello&quot;</span> <span style=""color:#008000;"">REM Comment after a statement using REM.</span>
demoStr2 = <span style=""color:#A31515;"">&quot;Goodbye&quot;</span> <span style=""color:#008000;"">' Comment after a statement using the ' character.</span>
<span style=""color:#008000;"">REM This entire line is a comment.</span>
<span style=""color:#008000;"">' This entire line is also a comment.</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleExternalSourceDirectiveNoSpaceBeforeParenthesis()
        {
            string source =
@"#ExternalSource(""C:\Documents and Settings\ITO-User\My Documents\Visual Studio 2005\WebSites\WebSite1\Next.aspx"",10)
    Protected WithEvents form1 As Global.System.Web.UI.HtmlControls.HtmlForm
#End ExternalSource";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">#ExternalSource</span>(<span style=""color:#A31515;"">&quot;C:\Documents and Settings\ITO-User\My Documents\Visual Studio 2005\WebSites\WebSite1\Next.aspx&quot;</span>,10)
    <span style=""color:#0000FF;"">Protected</span> <span style=""color:#0000FF;"">WithEvents</span> form1 <span style=""color:#0000FF;"">As</span> Global.System.Web.UI.HtmlControls.HtmlForm
<span style=""color:#0000FF;"">#End ExternalSource</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleExternalSourceDirectiveWithSpaceBeforeParenthesis()
        {
            string source =
@"#ExternalSource (""C:\Documents and Settings\ITO-User\My Documents\Visual Studio 2005\WebSites\WebSite1\Next.aspx"",10)
    Protected WithEvents form1 As Global.System.Web.UI.HtmlControls.HtmlForm
#End ExternalSource";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">#ExternalSource</span> (<span style=""color:#A31515;"">&quot;C:\Documents and Settings\ITO-User\My Documents\Visual Studio 2005\WebSites\WebSite1\Next.aspx&quot;</span>,10)
    <span style=""color:#0000FF;"">Protected</span> <span style=""color:#0000FF;"">WithEvents</span> form1 <span style=""color:#0000FF;"">As</span> Global.System.Web.UI.HtmlControls.HtmlForm
<span style=""color:#0000FF;"">#End ExternalSource</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStylePartialClassesAndMethods()
        {
            string source =
@"Partial Class Customer
    Partial Private Sub OnNameChanged()
    End Sub
End Class

Partial Class Customer
    Private Sub OnNameChanged()
    End Sub
End Class";
            string expected =
@"<div style=""color:#000000;background-color:#FFFFFF;""><pre>
<span style=""color:#0000FF;"">Partial</span> <span style=""color:#0000FF;"">Class</span> Customer
    <span style=""color:#0000FF;"">Partial</span> <span style=""color:#0000FF;"">Private</span> <span style=""color:#0000FF;"">Sub</span> OnNameChanged()
    <span style=""color:#0000FF;"">End</span> <span style=""color:#0000FF;"">Sub</span>
<span style=""color:#0000FF;"">End</span> <span style=""color:#0000FF;"">Class</span>

<span style=""color:#0000FF;"">Partial</span> <span style=""color:#0000FF;"">Class</span> Customer
    <span style=""color:#0000FF;"">Private</span> <span style=""color:#0000FF;"">Sub</span> OnNameChanged()
    <span style=""color:#0000FF;"">End</span> <span style=""color:#0000FF;"">Sub</span>
<span style=""color:#0000FF;"">End</span> <span style=""color:#0000FF;"">Class</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet, StyleSheets.VisualStudio);

            Assert.Equal(expected, actual);
        }
    }
}