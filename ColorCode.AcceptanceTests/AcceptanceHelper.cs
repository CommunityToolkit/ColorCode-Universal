namespace ColorCode
{
    public static class AcceptanceHelper
    {
        const string baseExpectedFormat = @"<div style=""color:Black;background-color:White;""><pre>
{0}
</pre></div>";
        
        public static string BuildExpected(string format, params object[] args)
        {
            var expectedFormat = string.Format(baseExpectedFormat, format);
            return string.Format(expectedFormat, args);
        }
    }
}
