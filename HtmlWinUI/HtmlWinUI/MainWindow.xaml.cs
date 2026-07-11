using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using HtmlWinUI.Services;
using HtmlWinUI.Views;

namespace HtmlWinUI
{
    /// <summary>
    /// App shell: top navigation, content frame, footer status bar.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppWindow.Resize(new Windows.Graphics.SizeInt32(1400, 900));
            NavigationService.RootFrame = ContentFrame;
            NavigationService.Navigate(typeof(HomePage));
        }

        private void Brand_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(HomePage));
        }

        private void NavButton_Click(object sender, RoutedEventArgs e)
        {
            var section = (string)((Button)sender).Tag;
            NavigationService.Navigate(typeof(SectionDashboardPage), section);
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(AboutPage));
        }
    }
}
