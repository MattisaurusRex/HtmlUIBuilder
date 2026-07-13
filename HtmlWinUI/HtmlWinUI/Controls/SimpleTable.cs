using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using HtmlWinUI.Models.Entities;
using Windows.UI;

namespace HtmlWinUI.Controls
{
    /// <summary>
    /// Lightweight tabular control replacing the web DataTables: set ItemsSource
    /// to entity rows and it renders one column per public property (State/PK
    /// hidden, DisplayName attributes as headers), with an optional row-level
    /// View action column.
    /// </summary>
    public sealed class SimpleTable : UserControl
    {
        private static readonly Brush HeaderBackground = new SolidColorBrush(Color.FromArgb(255, 0xE9, 0xE9, 0xEF));
        private static readonly Brush StripeBackground = new SolidColorBrush(Color.FromArgb(255, 0xF4, 0xF4, 0xF7));
        private static readonly Brush CellBorderBrush = new SolidColorBrush(Color.FromArgb(255, 0xD3, 0xD3, 0xE0));
        private static readonly Brush ViewButtonBrush = new SolidColorBrush(Color.FromArgb(255, 0x57, 0x91, 0xEB));

        public event EventHandler<object>? ViewClicked;

        private IEnumerable? _itemsSource;
        private bool _showViewButton;

        /// <summary>Entity rows to render (any IEnumerable of IEntityBase items).</summary>
        public IEnumerable? ItemsSource
        {
            get => _itemsSource;
            set
            {
                _itemsSource = value;
                Build();
            }
        }

        public bool ShowViewButton
        {
            get => _showViewButton;
            set
            {
                _showViewButton = value;
                Build();
            }
        }

        private void Build()
        {
            var rows = _itemsSource?.Cast<IEntityBase>().ToList() ?? new List<IEntityBase>();
            var rowType = rows.FirstOrDefault()?.GetType();
            if (rowType == null)
            {
                Content = null;
                return;
            }
            var props = rowType.GetProperties().Where(p => p.Name != "State" && p.Name != "PK").ToList();

            var grid = new Grid();
            var columnOffset = _showViewButton ? 1 : 0;
            for (var i = 0; i < props.Count + columnOffset; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            }
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            if (_showViewButton)
            {
                grid.Children.Add(MakeCell(string.Empty, 0, 0, isHeader: true));
            }
            for (var c = 0; c < props.Count; c++)
            {
                grid.Children.Add(MakeCell(GetDisplayName(props[c]), 0, c + columnOffset, isHeader: true));
            }

            for (var r = 0; r < rows.Count; r++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                var row = rows[r];
                var striped = r % 2 == 1;
                if (_showViewButton)
                {
                    grid.Children.Add(MakeViewButtonCell(row, r + 1, striped));
                }
                for (var c = 0; c < props.Count; c++)
                {
                    grid.Children.Add(MakeCell(FormatValue(props[c].GetValue(row)), r + 1, c + columnOffset, isHeader: false, striped));
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

        private static string GetDisplayName(PropertyInfo prop)
        {
            var displayName = prop
                .GetCustomAttributes(typeof(DisplayNameAttribute), true)
                .FirstOrDefault() as DisplayNameAttribute;
            return displayName?.DisplayName ?? prop.Name;
        }

        private static string FormatValue(object? value)
        {
            return value switch
            {
                null => string.Empty,
                DateTime dt => dt == default ? string.Empty : dt.ToString("d"),
                string[] items => string.Join(", ", items),
                _ => value.ToString() ?? string.Empty,
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

        private Border MakeViewButtonCell(IEntityBase item, int row, bool striped)
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
            button.Click += (_, _) => ViewClicked?.Invoke(this, item);

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
