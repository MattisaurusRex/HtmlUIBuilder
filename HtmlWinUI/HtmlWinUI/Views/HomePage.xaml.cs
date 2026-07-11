using System.Collections.Generic;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using HtmlWinUI.ViewModels;

namespace HtmlWinUI.Views
{
    /// <summary>
    /// Home dashboard: top-level sections (ported from Home/Index).
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            DashboardList.ItemsSource = new List<DashboardItem>
            {
                new DashboardItem("Files", "folder", typeof(SectionDashboardPage), "Files"),
                new DashboardItem("Customers", "customer", typeof(SectionDashboardPage), "Customers"),
                new DashboardItem("Quotes", "quote", typeof(SectionDashboardPage), "Quotes"),
                new DashboardItem("Invoices", "invoice", typeof(SectionDashboardPage), "Invoices"),
            };
        }

        private void DashboardItem_Click(object sender, RoutedEventArgs e)
        {
            ((DashboardItem)((Button)sender).DataContext).Navigate();
        }
    }
}
