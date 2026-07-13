using System.Collections.Generic;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using HtmlWinUI.Models.Entities;
using HtmlWinUI.Services;

namespace HtmlWinUI.Views
{
    /// <summary>
    /// Files search results table (ported from Views/Files/SearchResult.cshtml):
    /// FileEntity columns with a row-level View action opening the detail screen.
    /// Navigation parameter: the result rows.
    /// </summary>
    public sealed partial class FilesSearchResultPage : Page
    {
        public FilesSearchResultPage()
        {
            InitializeComponent();
            ResultsTable.ViewClicked += (_, item) =>
                NavigationService.Navigate(typeof(FileDetailPage), ((FileEntity)item).PK);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ResultsTable.ItemsSource = (List<FileEntity>)e.Parameter;
        }
    }
}
