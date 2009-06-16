public class StringEncoding
{
    public void Foo()
    {
        string a = @"""someText""";
        string b = "\"someText\"";
        string c = @"
""someText""
";
        char d = 'a';
        char e = '\'';
    }
}