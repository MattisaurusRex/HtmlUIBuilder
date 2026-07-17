using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;

namespace HtmlWpf.Controls
{
    /// <summary>
    /// DataGrid replacing the WinUI SimpleTable (which itself replaced the web
    /// DataTables): set ItemsSource to entity rows and it renders one column per
    /// public property (State/PK hidden, DisplayName attributes as headers), with
    /// an optional row-level View action column.
    /// </summary>
    public class EntityTable : DataGrid
    {
        public static readonly DependencyProperty ShowViewButtonProperty = DependencyProperty.Register(
            nameof(ShowViewButton), typeof(bool), typeof(EntityTable),
            new PropertyMetadata(false, (d, _) => ((EntityTable)d).UpdateViewColumn()));

        public event EventHandler<object>? ViewClicked;

        private static readonly IValueConverter DateDisplay = new DateDisplayConverter();
        private static readonly IValueConverter JoinDisplay = new JoinDisplayConverter();

        private readonly DataGridTemplateColumn _viewColumn;

        public bool ShowViewButton
        {
            get => (bool)GetValue(ShowViewButtonProperty);
            set => SetValue(ShowViewButtonProperty, value);
        }

        public EntityTable()
        {
            var cellBorderBrush = new SolidColorBrush(Color.FromRgb(0xD3, 0xD3, 0xE0));
            IsReadOnly = true;
            AutoGenerateColumns = true;
            CanUserAddRows = false;
            CanUserDeleteRows = false;
            CanUserReorderColumns = false;
            CanUserResizeRows = false;
            HeadersVisibility = DataGridHeadersVisibility.Column;
            GridLinesVisibility = DataGridGridLinesVisibility.All;
            HorizontalGridLinesBrush = cellBorderBrush;
            VerticalGridLinesBrush = cellBorderBrush;
            BorderBrush = cellBorderBrush;
            Background = Brushes.White;
            RowBackground = Brushes.White;
            AlternatingRowBackground = new SolidColorBrush(Color.FromRgb(0xF4, 0xF4, 0xF7));
            FontSize = 12;
            HorizontalAlignment = HorizontalAlignment.Left;
            _viewColumn = BuildViewColumn();
        }

        protected override void OnAutoGeneratingColumn(DataGridAutoGeneratingColumnEventArgs e)
        {
            base.OnAutoGeneratingColumn(e);
            if (e.PropertyName is "State" or "PK")
            {
                e.Cancel = true;
                return;
            }
            if (e.PropertyDescriptor is PropertyDescriptor descriptor)
            {
                // PropertyDescriptor.DisplayName honors [DisplayName] and falls
                // back to the property name.
                e.Column.Header = descriptor.DisplayName;
            }
            if (e.Column is DataGridTextColumn textColumn && textColumn.Binding is Binding binding)
            {
                if (e.PropertyType == typeof(DateTime) || e.PropertyType == typeof(DateTime?))
                {
                    binding.Converter = DateDisplay;
                }
                else if (e.PropertyType == typeof(string[]))
                {
                    binding.Converter = JoinDisplay;
                }
            }
        }

        private DataGridTemplateColumn BuildViewColumn()
        {
            var button = new FrameworkElementFactory(typeof(Button));
            button.SetValue(ContentControl.ContentProperty, "View");
            button.SetValue(Control.BackgroundProperty, new SolidColorBrush(Color.FromRgb(0x57, 0x91, 0xEB)));
            button.SetValue(Control.ForegroundProperty, Brushes.White);
            button.SetValue(Control.FontSizeProperty, 12.0);
            button.SetValue(Control.FontWeightProperty, FontWeights.Bold);
            button.SetValue(Control.PaddingProperty, new Thickness(12, 2, 12, 2));
            button.SetValue(FrameworkElement.MarginProperty, new Thickness(4, 2, 4, 2));
            button.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(OnViewButtonClick));
            return new DataGridTemplateColumn { CellTemplate = new DataTemplate { VisualTree = button } };
        }

        private void OnViewButtonClick(object sender, RoutedEventArgs e)
        {
            ViewClicked?.Invoke(this, ((FrameworkElement)sender).DataContext);
        }

        private void UpdateViewColumn()
        {
            if (ShowViewButton)
            {
                if (!Columns.Contains(_viewColumn))
                {
                    Columns.Insert(0, _viewColumn);
                }
            }
            else
            {
                Columns.Remove(_viewColumn);
            }
        }

        private sealed class DateDisplayConverter : IValueConverter
        {
            public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
            {
                return value is DateTime dt && dt != default ? dt.ToString("d", culture) : string.Empty;
            }

            public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => Binding.DoNothing;
        }

        private sealed class JoinDisplayConverter : IValueConverter
        {
            public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
            {
                return value is string[] items ? string.Join(", ", items) : string.Empty;
            }

            public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => Binding.DoNothing;
        }
    }
}
