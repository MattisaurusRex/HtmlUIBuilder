using System.Collections.Generic;
using System.Linq;
using Microsoft.UI.Xaml.Media;
using Windows.Foundation;

namespace HtmlWinUI.ViewModels
{
    /// <summary>
    /// View models produced by FormFieldFactory from the model schema metadata
    /// (IFormBase.Headings / IDetailHeader.HeaderView) and rendered by FormGroupsControl.
    /// </summary>
    public abstract class FormField
    {
        public string Label { get; set; } = string.Empty;
    }

    public class TextFormField : FormField
    {
        public string Text { get; set; } = string.Empty;
        public List<ButtonSpec> InlineButtons { get; set; } = new();
        public bool HasInlineButtons => InlineButtons.Count > 0;
    }

    public class BoolFormField : FormField
    {
        public bool? Value { get; set; }
    }

    public class DateFormField : FormField
    {
        public System.DateTimeOffset? Date { get; set; }
    }

    public class SelectFormField : FormField
    {
        public List<string> Options { get; set; } = new();
        public string Placeholder { get; set; } = string.Empty;
        public string? Selected { get; set; }
        public List<ButtonSpec> InlineButtons { get; set; } = new();
        public bool HasInlineButtons => InlineButtons.Count > 0;
    }

    /// <summary>One action button (ported from Models.Buttons.Button + the site.css colour classes).</summary>
    public class ButtonSpec
    {
        public string Text { get; set; } = string.Empty;
        public string Tooltip { get; set; } = string.Empty;
        public ImageSource? Icon { get; set; }
        public Brush? Background { get; set; }
        public Brush? Foreground { get; set; }
        public bool HasIcon => Icon != null;
        public bool HasText => Text.Length > 0;
    }

    /// <summary>A bordered, headed section of a form (one distinct Headings group).</summary>
    public class FormGroup
    {
        public string Heading { get; set; } = string.Empty;
        public bool HasHeading => Heading.Trim().Length > 0;
        public List<FormBlock> Blocks { get; } = new();
    }

    /// <summary>A full-width chunk within a group: a run of input fields, a button row, or a table.</summary>
    public abstract class FormBlock
    {
    }

    public class InputFieldsBlock : FormBlock
    {
        public List<FormField> Fields { get; } = new();
    }

    public class ButtonRowBlock : FormBlock
    {
        public List<ButtonSpec> Buttons { get; set; } = new();
    }

    public class TableBlock : FormBlock
    {
        public string Label { get; set; } = string.Empty;
        public bool HasLabel => Label.Length > 0;
        public TableViewModel Table { get; set; } = new();
    }

    public class TableViewModel
    {
        public List<string> ColumnHeaders { get; } = new();
        public List<TableRow> Rows { get; } = new();
        public bool ShowViewButton { get; set; }
    }

    public class TableRow
    {
        public TableRow(object item)
        {
            Item = item;
        }

        /// <summary>The underlying entity (used by the View action).</summary>
        public object Item { get; }
        public List<string> Cells { get; } = new();
    }
}
