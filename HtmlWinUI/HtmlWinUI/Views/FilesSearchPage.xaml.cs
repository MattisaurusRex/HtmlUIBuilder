using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using HtmlWinUI.Models.Search;
using HtmlWinUI.Services;

namespace HtmlWinUI.Views
{
    /// <summary>
    /// Files search form (ported from Views/Files/Search.cshtml): FilesSearchModel
    /// fields laid out in their schema groups (Client, Dates, Patient, Office).
    /// </summary>
    public sealed partial class FilesSearchPage : Page
    {
        public FilesSearchModel Model { get; } = new();

        public FilesSearchPage()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            // The MVC controller ignored the posted criteria and returned sample rows.
            var results = SampleDataService.SearchFiles(Model);
            NavigationService.Navigate(typeof(FilesSearchResultPage), results);
        }
    }
}
