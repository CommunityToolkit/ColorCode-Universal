using ColorCode.Styling;

namespace ColorCode
{
    public interface IStyleSheet
    {
        string Name { get; }
        StyleDictionary Styles { get; }
    }
}