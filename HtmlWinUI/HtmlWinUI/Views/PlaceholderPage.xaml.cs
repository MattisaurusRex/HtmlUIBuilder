using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace HtmlWinUI.Views
{
    /// <summary>
    /// Placeholder for screens that were scaffold-only in the MVC app
    /// (Customers/Quotes/Invoices actions, Files Create).
    /// Navigation parameter: page title.
    /// </summary>
    public sealed partial class PlaceholderPage : Page
    {
        public PlaceholderPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            TitleText.Text = (string)e.Parameter;
        }
    }
}
