using System;
using System.Linq;
using System.Threading.Tasks;

namespace ColorCode.BasicTests
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Contains("--concurrent"))
            {
                var tasks = new Task[100];
                for (int i = 0; i < 100; i++)
                {
                    tasks[i] = Task.Run(() =>
                    {
                        var code = "public void Method()\n{\n}";
                        var formatter = new HtmlFormatter();
                        var html = formatter.GetHtmlString(code, Languages.CSharp);
                        Console.WriteLine(html);
                    });
                }
                Task.WaitAll(tasks);
            }
            else
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
}