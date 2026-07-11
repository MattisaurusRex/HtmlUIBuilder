using System;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using HtmlWinUI.ViewModels;
using Windows.UI;

namespace HtmlWinUI.Controls
{
    /// <summary>
    /// Lightweight tabular control replacing the web DataTables: a Grid built
    /// from a TableViewModel, with an optional row-level View action column.
    /// </summary>
    public sealed class SimpleTable : UserControl
    {
        private static readonly Brush HeaderBackground = new SolidColorBrush(Color.FromArgb(255, 0xE9, 0xE9, 0xEF));
        private static readonly Brush StripeBackground = new SolidColorBrush(Color.FromArgb(255, 0xF4, 0xF4, 0xF7));
        private static readonly Brush CellBorderBrush = new SolidColorBrush(Color.FromArgb(255, 0xD3, 0xD3, 0xE0));
        private static readonly Brush ViewButtonBrush = new SolidColorBrush(Color.FromArgb(255, 0x57, 0x91, 0xEB));

        public event EventHandler<object>? ViewClicked;

        private TableViewModel _table = new();

        public TableViewModel Table
        {
            get => _table;
            set
            {
                _table = value;
                Build();
            }
        }

        private void Build()
        {
            var grid = new Grid();
            var columnOffset = _table.ShowViewButton ? 1 : 0;
            for (var i = 0; i < _table.ColumnHeaders.Count + columnOffset; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            }
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            if (_table.ShowViewButton)
            {
                grid.Children.Add(MakeCell(string.Empty, 0, 0, isHeader: true));
            }
            for (var c = 0; c < _table.ColumnHeaders.Count; c++)
            {
                grid.Children.Add(MakeCell(_table.ColumnHeaders[c], 0, c + columnOffset, isHeader: true));
            }

            for (var r = 0; r < _table.Rows.Count; r++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                var row = _table.Rows[r];
                var striped = r % 2 == 1;
                if (_table.ShowViewButton)
                {
                    grid.Children.Add(MakeViewButtonCell(row, r + 1, striped));
                }
                for (var c = 0; c < row.Cells.Count; c++)
                {
                    grid.Children.Add(MakeCell(row.Cells[c], r + 1, c + columnOffset, isHeader: false, striped));
                }
            }

            Content = new ScrollViewer
            {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
                HorizontalScrollMode = ScrollMode.Auto,
                VerticalScrollMode = ScrollMode.Disabled,
                Content = grid,
            };
        }

        private Border MakeCell(string text, int row, int column, bool isHeader, bool striped = false)
        {
            var border = new Border
            {
                BorderBrush = CellBorderBrush,
                BorderThickness = new Thickness(0, 0, 1, 1),
                Padding = new Thickness(8, 5, 8, 5),
                Background = isHeader ? HeaderBackground : striped ? StripeBackground : null,
                Child = new TextBlock
                {
                    Text = text,
                    FontSize = 12,
                    FontWeight = isHeader ? Microsoft.UI.Text.FontWeights.SemiBold : Microsoft.UI.Text.FontWeights.Normal,
                    VerticalAlignment = VerticalAlignment.Center,
                },
            };
            Grid.SetRow(border, row);
            Grid.SetColumn(border, column);
            return border;
        }

        private Border MakeViewButtonCell(TableRow tableRow, int row, bool striped)
        {
            var button = new Button
            {
                Content = "View",
                Background = ViewButtonBrush,
                Foreground = new SolidColorBrush(Colors.White),
                FontSize = 12,
                FontWeight = Microsoft.UI.Text.FontWeights.Bold,
                Padding = new Thickness(12, 4, 12, 4),
                CornerRadius = new CornerRadius(4),
            };
            button.Click += (_, _) => ViewClicked?.Invoke(this, tableRow.Item);

            var border = new Border
            {
                BorderBrush = CellBorderBrush,
                BorderThickness = new Thickness(0, 0, 1, 1),
                Padding = new Thickness(6, 4, 6, 4),
                Background = striped ? StripeBackground : null,
                Child = button,
            };
            Grid.SetRow(border, row);
            Grid.SetColumn(border, 0);
            return border;
        }
    }
}
