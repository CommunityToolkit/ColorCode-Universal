using System;

namespace ColorCode.BasicTests
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var csharpstring = "public void Method()\n{\n}";
            var formatter = new HtmlClassFormatter();
            var html = formatter.GetHtmlString(csharpstring, Languages.CSharp);
            var css = formatter.GetCSSString();

            Console.WriteLine("Original:");
            Console.WriteLine(csharpstring);

            Console.WriteLine("HTML:");
            Console.WriteLine(html);

            Console.ReadKey();
        }
    }
}