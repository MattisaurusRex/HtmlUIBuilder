using System.Collections.Generic;
using System.Windows.Controls;
using HtmlWpf.Models.Entities;
using HtmlWpf.Services;

namespace HtmlWpf.Views
{
    /// <summary>
    /// Files search results table (ported from Views/Files/SearchResult.cshtml):
    /// FileEntity columns with a row-level View action opening the detail screen.
    /// Navigation parameter: the result rows.
    /// </summary>
    public partial class FilesSearchResultPage : Page, INavigable
    {
        public FilesSearchResultPage()
        {
            InitializeComponent();
            // Qualified with Services.: unqualified NavigationService resolves to
            // WPF's Page.NavigationService instance property, not our static service.
            ResultsTable.ViewClicked += (_, item) =>
                Services.NavigationService.Navigate(typeof(FileDetailPage), ((FileEntity)item).PK);
        }

        public void OnNavigatedTo(object? parameter)
        {
            ResultsTable.ItemsSource = (List<FileEntity>)parameter!;
        }
    }
}
