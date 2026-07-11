using System;
using System.Collections.Generic;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using HtmlWinUI.ViewModels;

namespace HtmlWinUI.Views
{
    /// <summary>
    /// Section dashboard with Search/Create actions
    /// (ported from Home/Files, Home/Customers, Home/Quotes, Home/Invoices).
    /// Navigation parameter: section name.
    /// </summary>
    public sealed partial class SectionDashboardPage : Page
    {
        public SectionDashboardPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var section = (string)e.Parameter;
            // The MVC Files dashboard was headed "Files Search"; the others use the plain section name.
            HeadingText.Text = section == "Files" ? "Files Search" : section;
            // Files search is implemented; the other sections (and Create) were
            // scaffold placeholders in the MVC app and stay placeholders here.
            var searchTarget = section == "Files" ? typeof(FilesSearchPage) : typeof(PlaceholderPage);
            DashboardList.ItemsSource = new List<DashboardItem>
            {
                new DashboardItem("Search", "magnifying-glass", searchTarget, $"{section} Search"),
                new DashboardItem("Create", "plus", typeof(PlaceholderPage), $"{section} Create"),
            };
        }

        private void DashboardItem_Click(object sender, RoutedEventArgs e)
        {
            ((DashboardItem)((Button)sender).DataContext).Navigate();
        }
    }
}
