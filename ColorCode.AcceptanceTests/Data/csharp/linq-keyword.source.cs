using System.Linq;

// keywords_base.cs
// Accessing base class members
public class LinqTest
{
    public void DoSomething()
    {
        LinqObj[] data = new[]
                             {
                                 new LinqObj { Key = "abc", Value = "def" },
                                 new LinqObj { Key = "def", Value = "ghi" }
                             };

        var test = from d in data
                   join d2 in data on d.Key equals d2.Key
                   group d by d.Key into g
                   orderby g.Key ascending, g.Key descending
                   let w = g.Key
                   where g.Key == "abc"
                   select g;
    }

    private class LinqObj
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
