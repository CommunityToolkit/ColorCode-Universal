using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ColorCode.UWPTests
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Load_Click(object sender, RoutedEventArgs e)
        {
            PresentationBlock.Blocks.Clear();

            var result = await GetCodeFileText();
            if (result == null) return;

            var formatter = new RichTextBlockFormatter();
            formatter.FormatRichTextBlock(result.Item1, result.Item2, PresentationBlock);
        }

        private async Task<Tuple<string, ILanguage>> GetCodeFileText()
        {
            var picker = new FileOpenPicker();
            picker.FileTypeFilter.Add("*");

            var file = await picker.PickSingleFileAsync();
            if (file == null) return null;
            var text = await FileIO.ReadTextAsync(file);

            ILanguage Language = Languages.CSharp;

            if (LanguageBox.Text != null)
            {
                Language = Languages.FindById(LanguageBox.Text) ?? Languages.CSharp;
            }
            return new Tuple<string, ILanguage>(text, Language);
        }

        private async void MakeHTML(object sender, RoutedEventArgs e)
        {
            var result = await GetCodeFileText();
            if (result == null) return;

            var formatter = new HtmlFormatter();
            var html = formatter.GetHtmlString(result.Item1, result.Item2);

            var tempfile = await ApplicationData.Current.TemporaryFolder.CreateFileAsync("HTMLResult.html", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(tempfile, html);

            try
            {
                await Launcher.LaunchFileAsync(tempfile);
            }
            catch { }
        }
    }
}