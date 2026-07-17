using System;
using System.Windows.Controls;

namespace HtmlWpf.Services
{
    /// <summary>
    /// Implemented by pages that accept a navigation parameter
    /// (replaces WinUI's OnNavigatedTo(NavigationEventArgs)).
    /// </summary>
    public interface INavigable
    {
        void OnNavigatedTo(object? parameter);
    }

    /// <summary>
    /// Replaces MVC action routing: pages navigate through the shell's root Frame.
    /// NOTE: inside Page code-behind, call this as Services.NavigationService —
    /// unqualified, the name resolves to WPF's Page.NavigationService property.
    /// </summary>
    public static class NavigationService
    {
        public static Frame? RootFrame { get; set; }

        public static void Navigate(Type pageType, object? parameter = null)
        {
            if (RootFrame == null)
            {
                return;
            }
            var page = Activator.CreateInstance(pageType);
            if (page is INavigable navigable)
            {
                navigable.OnNavigatedTo(parameter);
            }
            RootFrame.Navigate(page);
        }

        public static void GoBack()
        {
            if (RootFrame?.CanGoBack == true)
            {
                RootFrame.GoBack();
            }
        }
    }
}
