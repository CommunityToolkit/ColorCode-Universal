using System;
using System.Collections.Generic;
using System.Drawing;
using ColorCode.Common;
using Xunit;

namespace ColorCode.Common
{
    public class ExtensionMethods_Facts
    {
        public class SortStable_Method_Facts
        {
            [Fact]
            public void It_will_preserve_the_order_of_existing_equal_list_items()
            {
                NameValueItem item1 = new NameValueItem {Name = "a", Value = 3};
                NameValueItem item2 = new NameValueItem {Name = "b", Value = 2};
                NameValueItem item3 = new NameValueItem {Name = "c", Value = 2};
                NameValueItem item4 = new NameValueItem {Name = "d", Value = 1};
                List<NameValueItem> list = new List<NameValueItem>();
                list.Add(item1);
                list.Add(item2);
                list.Add(item3);
                list.Add(item4);
                List<NameValueItem> expected = new List<NameValueItem>
                                                   {
                                                       item4,
                                                       item2,
                                                       item3,
                                                       item1
                                                   };

                list.SortStable((a, b) => a.Value.CompareTo(b.Value));

                Assert.Equal(expected[0], list[0]);
                Assert.Equal(expected[1], list[1]);
                Assert.Equal(expected[2], list[2]);
                Assert.Equal(expected[3], list[3]);
            }

            [Fact]
            public void It_will_throw_if_the_list_is_null()
            {
                const List<int> list = null;

                Exception ex = Record.Exception(() => list.SortStable((x, y) => x.CompareTo(y)));

                Assert.IsType<ArgumentNullException>(ex);
                Assert.Equal("list", ((ArgumentNullException)ex).ParamName);
            }

            private class NameValueItem
            {
                public string Name { get; set; }
                public int Value { get; set; }
            }
        }

        public class The_ToHtmlColor_method
        {
            [Fact]
            public void Will_return_the_correct_HTML_named_color_for_a_named_framework_color()
            {
                // no arrange

                string actual = Color.Black.ToHtmlColor();

                Assert.Equal("Black", actual);
            }

            [Fact]
            public void Will_return_the_correct_HTML_hex_color_for_an_RGB_framework_color()
            {
                // no arrange

                string actual = Color.FromArgb(0, 0, 0).ToHtmlColor();

                Assert.Equal("#000000", actual);
            }

            [Fact]
            public void WillThrowForEmptyColor()
            {
                // no arrange

                Assert.Throws<ArgumentException>(() => Color.Empty.ToHtmlColor());
            }
        }
    }
}