using System.Windows;
using System.Windows.Controls;
using HtmlWpf.Services;
using HtmlWpf.Views;

namespace HtmlWpf
{
    /// <summary>
    /// App shell: top navigation, content frame, footer status bar.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
