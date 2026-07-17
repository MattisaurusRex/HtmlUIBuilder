using System.Windows;
using System.Windows.Controls;
using HtmlWpf.Models.Search;
using HtmlWpf.Services;

namespace HtmlWpf.Views
{
    /// <summary>
    /// Files search form (ported from Views/Files/Search.cshtml): FilesSearchModel
    /// fields laid out in their schema groups (Client, Dates, Patient, Office).
    /// </summary>
    public partial class FilesSearchPage : Page
    {
        public FilesSearchModel Model { get; } = new();

        public FilesSearchPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            // The MVC controller ignored the posted criteria and returned sample rows.
            var results = SampleDataService.SearchFiles(Model);
            // Qualified with Services.: unqualified NavigationService resolves to
            // WPF's Page.NavigationService instance property, not our static service.
            Services.NavigationService.Navigate(typeof(FilesSearchResultPage), results);
        }
    }
}
