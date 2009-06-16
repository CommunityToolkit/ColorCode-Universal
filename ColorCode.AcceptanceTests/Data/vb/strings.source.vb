Public Class StringsTest
    Public Sub DoSomething()
        Dim a As String = "someText"
        Dim b As String = """someText"""
        Dim c As String = "foo ""someText"" foo"
        Dim d As String = ""
        Dim e As String = "foo " & "bar"
    End Sub
End Class