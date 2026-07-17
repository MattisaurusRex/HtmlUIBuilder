using System.Windows.Controls;
using HtmlWpf.Services;

namespace HtmlWpf.Views
{
    /// <summary>
    /// Placeholder for screens that were scaffold-only in the MVC app
    /// (Customers/Quotes/Invoices actions, Files Create).
    /// Navigation parameter: page title.
    /// </summary>
    public partial class PlaceholderPage : Page, INavigable
    {
        public PlaceholderPage()
        {
            InitializeComponent();
        }

        public void OnNavigatedTo(object? parameter)
        {
            TitleText.Text = (string)parameter!;
        }
    }
}
