using System.Collections.ObjectModel;

namespace ColorCode.Styling
{
    public class StyleDictionary : KeyedCollection<string, Style>
    {
        protected override string GetKeyForItem(Style item)
        {
            return item.ScopeName;
        }
    }
}