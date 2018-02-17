using System.Linq;
using Windows.UI.Xaml.Controls;

namespace ColorCode.UWPTests
{
    public sealed partial class RichEditSample : Page
    {
        public RichEditSample()
        {
            this.InitializeComponent();
            formatter = new RichEditBoxFormatter();

            foreach (var language in Languages.All)
            {
                LanguageBox.Items.Add(language.Name);
            }

            var defaultLang = Languages.Markdown;
            LanguageBox.SelectedItem = defaultLang.Name;
            formatter.AttachRichEditBox(RichEdit, defaultLang);
            LanguageBox.SelectionChanged += LanguageBox_SelectionChanged;
        }

        private void LanguageBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var language = Languages.All.FirstOrDefault(item => item.Name == LanguageBox.SelectedItem.ToString());
            formatter.Language = language;
        }

        private readonly RichEditBoxFormatter formatter;
    }
}