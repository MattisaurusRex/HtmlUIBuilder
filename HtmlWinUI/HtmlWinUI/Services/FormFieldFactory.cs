using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Microsoft.UI;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using HtmlWinUI.Models;
using HtmlWinUI.Models.Buttons;
using HtmlWinUI.Models.Details;
using HtmlWinUI.Models.Entities;
using HtmlWinUI.ViewModels;
using Windows.UI;

namespace HtmlWinUI.Services
{
    /// <summary>
    /// Contained adapter layer: turns the schema metadata on the domain models
    /// (IFormBase.Headings, IDetailHeader.HeaderView, DisplayName attributes) into
    /// form-field view models. This is the only place UI generation uses reflection;
    /// it replaces the HTML string builders in the MVC project's HtmlHelpers.
    /// </summary>
    public static class FormFieldFactory
    {
        // Button colour classes from site.css (xxxFrontDetailBtn).
        private static readonly Dictionary<string, (Color Background, Color Foreground)> ButtonColors =
            new(StringComparer.OrdinalIgnoreCase)
            {
                ["purple"] = (Color.FromArgb(255, 0xA7, 0x41, 0x82), Colors.White),
                ["blue"] = (Color.FromArgb(255, 0x57, 0x91, 0xEB), Colors.White),
                ["orange"] = (Color.FromArgb(255, 0xFF, 0x88, 0x03), Colors.White),
                ["green"] = (Color.FromArgb(255, 0x1E, 0x98, 0x55), Colors.White),
                ["white"] = (Color.FromArgb(255, 0xE9, 0xE9, 0xEF), Colors.Black),
                ["brown"] = (Color.FromArgb(255, 0xA9, 0x90, 0x87), Colors.White),
            };

        /// <summary>Builds the grouped form sections for a search form or detail tab.</summary>
        public static List<FormGroup> BuildGroups(IFormBase form)
        {
            return BuildGroupsFromView(form, form.Headings);
        }

        /// <summary>Builds the detail header panel as a single unheaded group.</summary>
        public static List<FormGroup> BuildHeaderGroups(IDetailHeader header)
        {
            return BuildGroupsFromView(header, header.HeaderView);
        }

        /// <summary>True when a form has anything besides button rows (the MVC DetailForm's "submit needed" rule).</summary>
        public static bool HasInputs(List<FormGroup> groups)
        {
            return groups.Any(g => g.Blocks.Any(b => b is not ButtonRowBlock));
        }

        private static List<FormGroup> BuildGroupsFromView(object model, string[][] view)
        {
            var props = model.GetType().GetProperties();
            var inlineButtonRows = props
                .Where(p => p.PropertyType == typeof(ButtonRow))
                .Select(p => (ButtonRow?)p.GetValue(model))
                .Where(r => r != null && r.AssociatedInput.Length > 0)
                .ToLookup(r => r!.AssociatedInput, r => r!);

            var groups = new List<FormGroup>();
            foreach (var heading in view.Select(entry => entry[0]).Distinct())
            {
                var group = new FormGroup { Heading = heading.Trim() };
                foreach (var entry in view.Where(v => v[0] == heading))
                {
                    var prop = props.FirstOrDefault(p => p.Name == entry[1]);
                    if (prop == null)
                    {
                        continue; // schema references a property the model doesn't have
                    }
                    AddField(group, model, prop, inlineButtonRows);
                }
                if (group.Blocks.Count > 0)
                {
                    groups.Add(group);
                }
            }
            return groups;
        }

        private static void AddField(FormGroup group, object model, PropertyInfo prop, ILookup<string, ButtonRow> inlineButtonRows)
        {
            var value = prop.GetValue(model);
            var label = GetDisplayName(prop);
            var inline = inlineButtonRows[prop.Name].SelectMany(r => r.Buttons).Select(MapButton).ToList();

            if (prop.PropertyType == typeof(ButtonRow))
            {
                var row = (ButtonRow?)value;
                if (row != null && row.AssociatedInput.Length == 0)
                {
                    group.Blocks.Add(new ButtonRowBlock { Buttons = row.Buttons.Select(MapButton).ToList() });
                }
                return; // associated rows are rendered inline with their input
            }

            if (prop.PropertyType == typeof(string[]))
            {
                AddInput(group, new SelectFormField
                {
                    Label = label,
                    Options = ((string[]?)value ?? Array.Empty<string>()).ToList(),
                    Placeholder = $"Select a {label}",
                    InlineButtons = inline,
                });
            }
            else if (prop.PropertyType == typeof(bool) || prop.PropertyType == typeof(bool?))
            {
                AddInput(group, new BoolFormField { Label = label, Value = value as bool? });
            }
            else if (prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?))
            {
                var date = value as DateTime?;
                AddInput(group, new DateFormField
                {
                    Label = label,
                    Date = date == null || date == default(DateTime) ? null : new DateTimeOffset(date.Value),
                });
            }
            else if (prop.PropertyType == typeof(string) || prop.PropertyType == typeof(int))
            {
                AddInput(group, new TextFormField
                {
                    // The MVC header renderer labelled EntityID as "ID#".
                    Label = prop.Name == "EntityID" ? "ID#" : label,
                    Text = FormatValue(value),
                    InlineButtons = inline,
                });
            }
            else if (value is IEnumerable<IEntityBase> rows)
            {
                group.Blocks.Add(new TableBlock { Label = label, Table = BuildTable(rows) });
            }
            // other property types (PK, State, tab metadata) are not rendered
        }

        private static void AddInput(FormGroup group, FormField field)
        {
            if (group.Blocks.LastOrDefault() is not InputFieldsBlock block)
            {
                block = new InputFieldsBlock();
                group.Blocks.Add(block);
            }
            block.Fields.Add(field);
        }

        /// <summary>Builds a table from entity rows, one column per public property (State/PK hidden).</summary>
        public static TableViewModel BuildTable(IEnumerable<IEntityBase> rows, bool showViewButton = false)
        {
            var table = new TableViewModel { ShowViewButton = showViewButton };
            var rowList = rows.ToList();
            var rowType = rowList.FirstOrDefault()?.GetType();
            if (rowType == null)
            {
                return table;
            }

            var props = rowType.GetProperties().Where(p => p.Name != "State" && p.Name != "PK").ToList();
            table.ColumnHeaders.AddRange(props.Select(GetDisplayName));
            foreach (var row in rowList)
            {
                var tableRow = new TableRow(row);
                tableRow.Cells.AddRange(props.Select(p => FormatValue(p.GetValue(row))));
                table.Rows.Add(tableRow);
            }
            return table;
        }

        public static string GetDisplayName(PropertyInfo prop)
        {
            var displayName = prop
                .GetCustomAttributes(typeof(DisplayNameAttribute), true)
                .FirstOrDefault() as DisplayNameAttribute;
            return displayName?.DisplayName ?? prop.Name;
        }

        private static ButtonSpec MapButton(Models.Buttons.Button button)
        {
            var colors = ButtonColors.TryGetValue(button.Color, out var mapped)
                ? mapped
                : ButtonColors["blue"];
            return new ButtonSpec
            {
                Text = button.Text.Length > 0 || button.Icon.Length > 0 ? button.Text : button.Name,
                Tooltip = button.Name,
                Icon = button.Icon.Length > 0
                    ? new BitmapImage(new Uri($"ms-appx:///Assets/Images/{button.Icon}.png"))
                    : null,
                Background = new SolidColorBrush(colors.Background),
                Foreground = new SolidColorBrush(colors.Foreground),
            };
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
    }
}
