using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HtmlWpf.Controls
{
    /// <summary>
    /// ComboBox with WinUI-style PlaceholderText shown while nothing is selected.
    /// </summary>
    public class PlaceholderComboBox : UserControl
    {
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
            nameof(ItemsSource), typeof(IEnumerable), typeof(PlaceholderComboBox),
            new PropertyMetadata(null, (d, e) => ((PlaceholderComboBox)d)._comboBox.ItemsSource = (IEnumerable?)e.NewValue));

        public static readonly DependencyProperty PlaceholderTextProperty = DependencyProperty.Register(
            nameof(PlaceholderText), typeof(string), typeof(PlaceholderComboBox),
            new PropertyMetadata(string.Empty, (d, e) => ((PlaceholderComboBox)d)._placeholder.Text = (string?)e.NewValue ?? string.Empty));

        private readonly ComboBox _comboBox = new();
        private readonly TextBlock _placeholder;

        public IEnumerable? ItemsSource
        {
            get => (IEnumerable?)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public string PlaceholderText
        {
            get => (string)GetValue(PlaceholderTextProperty);
            set => SetValue(PlaceholderTextProperty, value);
        }

        public object? SelectedItem => _comboBox.SelectedItem;

        public PlaceholderComboBox()
        {
            Focusable = false;
            _placeholder = new TextBlock
            {
                Foreground = Brushes.Gray,
                Margin = new Thickness(8, 0, 24, 0),
                VerticalAlignment = VerticalAlignment.Center,
                IsHitTestVisible = false,
                TextTrimming = TextTrimming.CharacterEllipsis,
            };
            _comboBox.SelectionChanged += (_, _) => UpdatePlaceholderVisibility();
            var grid = new Grid();
            grid.Children.Add(_comboBox);
            grid.Children.Add(_placeholder);
            Content = grid;
        }

        private void UpdatePlaceholderVisibility()
        {
            _placeholder.Visibility = _comboBox.SelectedItem == null ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
