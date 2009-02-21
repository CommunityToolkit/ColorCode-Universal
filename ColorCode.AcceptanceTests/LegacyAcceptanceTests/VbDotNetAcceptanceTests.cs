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
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">Imports</span> System
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleImportStatementWithNestedNamespace()
        {
            string source =
@"Imports System.Regex";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">Imports</span> System.Regex
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleNamespaceStatement()
        {
            string source =
@"    Namespace My.Namespace";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
    <span style=""color:Blue;"">Namespace</span> <span style=""color:Blue;"">My</span>.<span style=""color:Blue;"">Namespace</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleDocComments()
        {
            string source =
@"''' <summary>";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Green;"">''' &lt;summary&gt;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleComments()
        {
            string source =
@"' this is a comment";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Green;"">' this is a comment</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleDoubleQuotesStrings()
        {
            string source =
@"""this is a double-quoted string""";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:#A31515;"">&quot;this is a double-quoted string&quot;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet);

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
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">Public</span> <span style=""color:Blue;"">Class</span> SomeClass
    <span style=""color:Blue;"">Inherits</span> SomeOtherClass
    <span style=""color:Blue;"">Implements</span> SomeInterface
<span style=""color:Blue;"">End</span> <span style=""color:Blue;"">Class</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleVariableDeclaration()
        {
            string source =
@"Private Const SomeVariable As String = ""SomeValue""";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">Private</span> <span style=""color:Blue;"">Const</span> SomeVariable <span style=""color:Blue;"">As</span> <span style=""color:Blue;"">String</span> = <span style=""color:#A31515;"">&quot;SomeValue&quot;</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet);

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
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">Protected</span> <span style=""color:Blue;"">Overridable</span> <span style=""color:Blue;"">Sub</span> SomeEventHandler(<span style=""color:Blue;"">ByVal</span> e <span style=""color:Blue;"">As</span> EventArgs)
    <span style=""color:Blue;"">If</span> <span style=""color:Blue;"">Not</span> SomeEvent <span style=""color:Blue;"">Is</span> <span style=""color:Blue;"">Nothing</span> <span style=""color:Blue;"">Then</span>
        <span style=""color:Blue;"">RaiseEvent</span> Some(<span style=""color:Blue;"">Me</span>, e)
    <span style=""color:Blue;"">End</span> <span style=""color:Blue;"">If</span>
<span style=""color:Blue;"">End</span> <span style=""color:Blue;"">Sub</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet);

            Assert.Equal(expected, actual);
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
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">CBool</span>(foo)
<span style=""color:Blue;"">CByte</span>(foo)
<span style=""color:Blue;"">CChar</span>(foo)
<span style=""color:Blue;"">CDate</span>(foo)
<span style=""color:Blue;"">CDec</span>(foo)
<span style=""color:Blue;"">CDbl</span>(foo)
<span style=""color:Blue;"">Char</span>(foo)
<span style=""color:Blue;"">CInt</span>(foo)
<span style=""color:Blue;"">CLng</span>(foo)
<span style=""color:Blue;"">CObj</span>(foo)
<span style=""color:Blue;"">CShort</span>(foo)
<span style=""color:Blue;"">CSng</span>(foo)
<span style=""color:Blue;"">CStr</span>(foo)
<span style=""color:Blue;"">CSByte</span>(foo)
<span style=""color:Blue;"">CUInt</span>(foo)
<span style=""color:Blue;"">CULng</span>(foo)
<span style=""color:Blue;"">CUShort</span>(foo)
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet);

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
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">String</span>
<span style=""color:Blue;"">Date</span>
<span style=""color:Blue;"">Decimal</span>
<span style=""color:Blue;"">Double</span>
<span style=""color:Blue;"">Enum</span>
<span style=""color:Blue;"">Integer</span>
<span style=""color:Blue;"">Long</span>
<span style=""color:Blue;"">Short</span>
<span style=""color:Blue;"">Single</span>
<span style=""color:Blue;"">Boolean</span>
<span style=""color:Blue;"">Byte</span>
<span style=""color:Blue;"">SByte</span>
<span style=""color:Blue;"">UInteger</span>
<span style=""color:Blue;"">ULong</span>
<span style=""color:Blue;"">UShort</span>
<span style=""color:Blue;"">Char</span>
<span style=""color:Blue;"">Structure</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleAddHandlerStatement()
        {
            string source =
@"AddHandler event, AddressOf eventHandler";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">AddHandler</span> <span style=""color:Blue;"">event</span>, <span style=""color:Blue;"">AddressOf</span> eventHandler
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleDeclareStatement()
        {
            string source =
@"Declare Function FunctioName Lib ""some.dll"" Alias ""FunctionNameInDll"" (ByVal arg1 As String, ByRef arg2 As Integer) As Integer";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">Declare</span> <span style=""color:Blue;"">Function</span> FunctioName <span style=""color:Blue;"">Lib</span> <span style=""color:#A31515;"">&quot;some.dll&quot;</span> <span style=""color:Blue;"">Alias</span> <span style=""color:#A31515;"">&quot;FunctionNameInDll&quot;</span> (<span style=""color:Blue;"">ByVal</span> arg1 <span style=""color:Blue;"">As</span> <span style=""color:Blue;"">String</span>, <span style=""color:Blue;"">ByRef</span> arg2 <span style=""color:Blue;"">As</span> <span style=""color:Blue;"">Integer</span>) <span style=""color:Blue;"">As</span> <span style=""color:Blue;"">Integer</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillNotStyleObjectInSystemDotObject()
        {
            string source =
@"System.Object";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
System.Object
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleObjectInDimStatement()
        {
            string source =
@"Dim foo as Object";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">Dim</span> foo <span style=""color:Blue;"">as</span> <span style=""color:Blue;"">Object</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleLowerCaseKeywords()
        {
            string source =
@"dim foo as object";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">dim</span> foo <span style=""color:Blue;"">as</span> <span style=""color:Blue;"">object</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillNotStyleAssemblyKeywordInAttribute()
        {
            string source =
@"<Assembly: CLSCompliant(True)>";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
&lt;Assembly: CLSCompliant(<span style=""color:Blue;"">True</span>)&gt;
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TransformWillStyleRegionAndIfDirectives()
        {
            string source =
@"#Region ""A comment""
' this is a comment
#End Region
#If
#Else
#End If";
            string expected =
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">#Region</span> <span style=""color:#A31515;"">&quot;A comment&quot;</span>
<span style=""color:Green;"">' this is a comment</span>
<span style=""color:Blue;"">#End Region</span>
<span style=""color:Blue;"">#If</span>
<span style=""color:Blue;"">#Else</span>
<span style=""color:Blue;"">#End If</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet);

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
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">Sub</span> TestEvents()
    <span style=""color:Blue;"">Dim</span> Obj <span style=""color:Blue;"">As</span> <span style=""color:Blue;"">New</span> Class1
    <span style=""color:Green;"">' Associate an event handler with an event.</span>
    <span style=""color:Blue;"">AddHandler</span> Obj.Ev_Event, <span style=""color:Blue;"">AddressOf</span> EventHandler
    <span style=""color:Green;"">' Call the method to raise the event.</span>
    Obj.CauseSomeEvent()
    <span style=""color:Green;"">' Stop handling events.</span>
    <span style=""color:Blue;"">RemoveHandler</span> Obj.Ev_Event, <span style=""color:Blue;"">AddressOf</span> EventHandler
    <span style=""color:Green;"">' This event will not be handled.</span>
    Obj.CauseSomeEvent()
<span style=""color:Blue;"">End</span> <span style=""color:Blue;"">Sub</span>

<span style=""color:Blue;"">Sub</span> EventHandler()
    <span style=""color:Green;"">' Handle the event.</span>
    MsgBox(<span style=""color:#A31515;"">&quot;EventHandler caught event.&quot;</span>)
<span style=""color:Blue;"">End</span> <span style=""color:Blue;"">Sub</span>

<span style=""color:Blue;"">Public</span> <span style=""color:Blue;"">Class</span> Class1
    <span style=""color:Green;"">' Declare an event.</span>
    <span style=""color:Blue;"">Public</span> <span style=""color:Blue;"">Event</span> Ev_Event()
    <span style=""color:Blue;"">Sub</span> CauseSomeEvent()
        <span style=""color:Green;"">' Raise an event.</span>
        <span style=""color:Blue;"">RaiseEvent</span> Ev_Event()
    <span style=""color:Blue;"">End</span> <span style=""color:Blue;"">Sub</span>
<span style=""color:Blue;"">End</span> <span style=""color:Blue;"">Class</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet);

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
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">Dim</span> demoStr1, demoStr2 <span style=""color:Blue;"">As</span> <span style=""color:Blue;"">String</span>
demoStr1 = <span style=""color:#A31515;"">&quot;Hello&quot;</span> <span style=""color:Green;"">REM Comment after a statement using REM.</span>
demoStr2 = <span style=""color:#A31515;"">&quot;Goodbye&quot;</span> <span style=""color:Green;"">' Comment after a statement using the ' character.</span>
<span style=""color:Green;"">REM This entire line is a comment.</span>
<span style=""color:Green;"">' This entire line is also a comment.</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet);

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
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">#ExternalSource</span>(<span style=""color:#A31515;"">&quot;C:\Documents and Settings\ITO-User\My Documents\Visual Studio 2005\WebSites\WebSite1\Next.aspx&quot;</span>,10)
    <span style=""color:Blue;"">Protected</span> <span style=""color:Blue;"">WithEvents</span> form1 <span style=""color:Blue;"">As</span> Global.System.Web.UI.HtmlControls.HtmlForm
<span style=""color:Blue;"">#End ExternalSource</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet);

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
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">#ExternalSource</span> (<span style=""color:#A31515;"">&quot;C:\Documents and Settings\ITO-User\My Documents\Visual Studio 2005\WebSites\WebSite1\Next.aspx&quot;</span>,10)
    <span style=""color:Blue;"">Protected</span> <span style=""color:Blue;"">WithEvents</span> form1 <span style=""color:Blue;"">As</span> Global.System.Web.UI.HtmlControls.HtmlForm
<span style=""color:Blue;"">#End ExternalSource</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet);

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
@"<div style=""color:Black;background-color:White;""><pre>
<span style=""color:Blue;"">Partial</span> <span style=""color:Blue;"">Class</span> Customer
    <span style=""color:Blue;"">Partial</span> <span style=""color:Blue;"">Private</span> <span style=""color:Blue;"">Sub</span> OnNameChanged()
    <span style=""color:Blue;"">End</span> <span style=""color:Blue;"">Sub</span>
<span style=""color:Blue;"">End</span> <span style=""color:Blue;"">Class</span>

<span style=""color:Blue;"">Partial</span> <span style=""color:Blue;"">Class</span> Customer
    <span style=""color:Blue;"">Private</span> <span style=""color:Blue;"">Sub</span> OnNameChanged()
    <span style=""color:Blue;"">End</span> <span style=""color:Blue;"">Sub</span>
<span style=""color:Blue;"">End</span> <span style=""color:Blue;"">Class</span>
</pre></div>";

            string actual = new CodeColorizer().Colorize(source, Languages.VbDotNet);

            Assert.Equal(expected, actual);
        }
    }
}