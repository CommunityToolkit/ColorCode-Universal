// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using ColorCode.Common;
using ColorCode.Styling;
using ColorCode.WinUI.Common;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.System;
using Microsoft.UI.Xaml;
using System.Runtime.InteropServices;
using WinRT;

namespace ColorCode.WinUITests
{
    public sealed partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region IInitializeWithWindow

        [ComImport]
        [Guid("3E68D4BD-7135-4D10-8018-9FB6D9F33FA1")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IInitializeWithWindow
        {
            void Initialize(IntPtr hwnd);
        }

        #endregion

        private async Task<Tuple<string, ILanguage>> GetCodeFileText()
        {
            try
            {
                var picker = new FileOpenPicker();

                IntPtr windowHandle = (App.Current as App).WindowHandle;
                IInitializeWithWindow initializeWithWindowWrapper = picker.As<IInitializeWithWindow>();
                initializeWithWindowWrapper.Initialize(windowHandle);

                picker.FileTypeFilter.Add("*");

                var file = await picker.PickSingleFileAsync();
                if (file == null) return null;

                System.Diagnostics.Debugger.Launch();

                string text = "";
                using (var reader = new StreamReader(await file.OpenStreamForReadAsync(), true))
                {
                    text = await reader.ReadToEndAsync();
                }

                ILanguage Language = Languages.FindById(file.FileType.Replace(".", "")) ?? Languages.CSharp;
                return new Tuple<string, ILanguage>(text, Language);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return new Tuple<string, ILanguage>("ERROR", Languages.CSharp);
            }
        }

        private void RenderLight(object sender, RoutedEventArgs e)
        {
            MainGrid.RequestedTheme = ElementTheme.Light;
            Render();
        }

        private void RenderDark(object sender, RoutedEventArgs e)
        {
            MainGrid.RequestedTheme = ElementTheme.Dark;
            Render();
        }

        private async void Render()
        {
            PresentationBlock.Blocks.Clear();

            var result = await GetCodeFileText();
            if (result == null) return;

            var formatter = new RichTextBlockFormatter(MainGrid.RequestedTheme);
            var plainText = formatter.Styles[ScopeName.PlainText];
            MainGrid.Background = (plainText?.Background ?? StyleDictionary.White).GetSolidColorBrush();
            formatter.FormatRichTextBlock(result.Item1, result.Item2, PresentationBlock);
        }

        private void HTMLLight(object sender, RoutedEventArgs e)
        {
            MakeHTML(StyleDictionary.DefaultLight);
        }

        private void HTMLDark(object sender, RoutedEventArgs e)
        {
            MakeHTML(StyleDictionary.DefaultDark);
        }

        private async void MakeHTML(StyleDictionary Styles)
        {
            var result = await GetCodeFileText();
            if (result == null) return;

            var formatter = new HtmlFormatter(Styles);
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
