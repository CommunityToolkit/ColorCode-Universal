using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ColorCode.UWPTests
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private SystemNavigationManager Manager;
        private static bool HasLoaded;

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
            Manager = SystemNavigationManager.GetForCurrentView();
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!HasLoaded)
            {
                this.Frame.Navigated += Frame_Navigated;
                Manager.BackRequested += Manager_BackRequested;
                HasLoaded = true;
            }
        }

        private void Manager_BackRequested(object sender, BackRequestedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void Frame_Navigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            Manager.AppViewBackButtonVisibility = Frame.CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
        }

        private void RichTextSample_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RichTextSample));
        }

        private void RichEditSample_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RichEditSample));
        }
    }
}