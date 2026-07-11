using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using HtmlWinUI.Models.Search;
using HtmlWinUI.Services;

namespace HtmlWinUI.Views
{
    /// <summary>
    /// Files search form (ported from Views/Files/Search.cshtml): renders
    /// FilesSearchModel fields in their schema groups (Client, Dates, Patient, Office).
    /// </summary>
    public sealed partial class FilesSearchPage : Page
    {
        private readonly FilesSearchModel _model = new();

        public FilesSearchPage()
        {
            InitializeComponent();
            SearchGroups.Groups = FormFieldFactory.BuildGroups(_model);
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            // The MVC controller ignored the posted criteria and returned sample rows.
            var results = SampleDataService.SearchFiles(_model);
            NavigationService.Navigate(typeof(FilesSearchResultPage), results);
        }
    }
}
