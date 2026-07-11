using System;
using Microsoft.UI.Xaml.Controls;

namespace HtmlWinUI.Services
{
    /// <summary>
    /// Replaces MVC action routing: pages navigate through the shell's root Frame.
    /// </summary>
    public static class NavigationService
    {
        public static Frame? RootFrame { get; set; }

        public static void Navigate(Type pageType, object? parameter = null)
        {
            RootFrame?.Navigate(pageType, parameter);
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
