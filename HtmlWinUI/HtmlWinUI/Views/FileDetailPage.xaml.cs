using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using HtmlWinUI.Controls;
using HtmlWinUI.Services;

namespace HtmlWinUI.Views
{
    /// <summary>
    /// File detail screen (ported from Views/Files/Details.cshtml): header panel
    /// from FileDetailHeader.HeaderView plus one tab per DetailTabItem.
    /// Navigation parameter: the file id.
    /// </summary>
    public sealed partial class FileDetailPage : Page
    {
        public FileDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var header = SampleDataService.GetFileDetail((int)e.Parameter);

            HeaderGroups.Groups = FormFieldFactory.BuildHeaderGroups(header);

            DetailTabs.TabItems.Clear();
            foreach (var tab in header.DetailTabItems)
            {
                var groups = FormFieldFactory.BuildGroups(tab);
                var content = new StackPanel { Padding = new Thickness(12) };
                content.Children.Add(new FormGroupsControl { Groups = groups });
                if (FormFieldFactory.HasInputs(groups))
                {
                    content.Children.Add(new Button
                    {
                        Content = "Submit",
                        Style = (Style)Application.Current.Resources["SubmitButtonStyle"],
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Margin = new Thickness(0, 4, 0, 12),
                    });
                }

                DetailTabs.TabItems.Add(new TabViewItem
                {
                    Header = tab.PageHeading,
                    IsClosable = false,
                    IconSource = new BitmapIconSource
                    {
                        UriSource = new Uri($"ms-appx:///Assets/Images/{tab.IconType}.png"),
                        ShowAsMonochrome = false,
                    },
                    Content = new ScrollViewer { Content = content },
                });
            }
            DetailTabs.SelectedIndex = 0;
        }
    }
}
