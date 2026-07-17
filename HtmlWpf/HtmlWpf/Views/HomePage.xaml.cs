using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using HtmlWpf.ViewModels;

namespace HtmlWpf.Views
{
    /// <summary>
    /// Home dashboard: top-level sections (ported from Home/Index).
    /// </summary>
    public partial class HomePage : Page
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
