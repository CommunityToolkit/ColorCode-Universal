using System;
using Xunit;

namespace ColorCode.Styling
{
    public class Style_Class_Facts
    {
        public class Constructor_Facts
        {
            [Fact]
            public void It_will_set_the_scope_name()
            {
                const string scopeName = "The Scope Name";

                Style style = new Style(scopeName);

                Assert.Equal("The Scope Name", style.ScopeName);
            }

            [Fact]
            public void It_will_throw_when_scope_name_is_null()
            {
                const string scopeName = null;

                Exception ex = Record.Exception(() => new Style(scopeName));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("scopeName", ((ArgumentNullException)ex).ParamName);
            }

            [Fact]
            public void It_will_throw_when_scope_name_is_empty()
            {
                string scopeName = string.Empty;

                Exception ex = Record.Exception(() => new Style(scopeName));

                Assert.IsType<ArgumentException>(ex);
                Assert.Contains("The scopeName argument value must not be empty.", ex.Message);
                Assert.Equal("scopeName", ((ArgumentException)ex).ParamName);
            }
        }

        public class ToString_Method_Facts
        {
            [Fact]
            public void It_will_return_the_scope_name()
            {
                Style style = new Style("The Scope Name");

                string actualScopeName = style.ToString();

                Assert.Equal("The Scope Name", actualScopeName);
            }
        }
    }
}
