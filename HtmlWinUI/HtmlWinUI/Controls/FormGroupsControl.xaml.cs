using System.Collections.Generic;
using Microsoft.UI.Xaml.Controls;
using HtmlWinUI.ViewModels;

namespace HtmlWinUI.Controls
{
    /// <summary>
    /// Renders a list of FormGroup view models as bordered, headed sections.
    /// Replaces the SearchForm/DetailForm HTML builders from the MVC project.
    /// </summary>
    public sealed partial class FormGroupsControl : UserControl
    {
        public FormGroupsControl()
        {
            InitializeComponent();
        }

        private List<FormGroup> _groups = new();

        public List<FormGroup> Groups
        {
            get => _groups;
            set
            {
                _groups = value;
                GroupsHost.ItemsSource = value;
            }
        }
    }
}
