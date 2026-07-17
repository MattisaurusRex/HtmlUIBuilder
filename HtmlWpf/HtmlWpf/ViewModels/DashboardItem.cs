using System;
using HtmlWpf.Services;

namespace HtmlWpf.ViewModels
{
    /// <summary>
    /// One dashboard action: icon + label navigating to a page.
    /// Replaces HomeModel.DashboardOptions (page name -> icon name).
    /// </summary>
    public class DashboardItem
    {
        public string Label { get; }
        public string IconPath { get; }
        private readonly Type _pageType;
        private readonly object? _parameter;

        public DashboardItem(string label, string icon, Type pageType, object? parameter = null)
        {
            Label = label;
            IconPath = $"pack://application:,,,/Assets/Images/{icon}.png";
            _pageType = pageType;
            _parameter = parameter;
        }

        public void Navigate() => NavigationService.Navigate(_pageType, _parameter);
    }
}
