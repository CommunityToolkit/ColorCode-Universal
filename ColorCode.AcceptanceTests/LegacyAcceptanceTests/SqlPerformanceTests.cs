using System;
using System.Diagnostics;
using System.IO;
using Xunit;

namespace ColorCode.SqlAcceptanceTests
{
    public class SqlPerformanceTests
    {
        public class Transform
        {
            [Fact]
            public void WillStyleLargeSourceTextIn1SecondOrLess()
            {
                string source = File.ReadAllText(@"..\..\LegacyAcceptanceTests\large.sql");
                Stopwatch sw = new Stopwatch();
                sw.Start();

                ColorCode.Colorize(source, Languages.Sql);

                sw.Stop();
                TimeSpan elapsed = sw.Elapsed;
                Assert.True(elapsed.Seconds <= 1);
            }
        }
    }
}
