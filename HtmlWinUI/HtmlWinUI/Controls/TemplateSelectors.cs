using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using HtmlWinUI.ViewModels;

namespace HtmlWinUI.Controls
{
    /// <summary>Picks the template for a form block (input run, button row, or table).</summary>
    public class FormBlockTemplateSelector : DataTemplateSelector
    {
        public DataTemplate? InputBlockTemplate { get; set; }
        public DataTemplate? ButtonRowBlockTemplate { get; set; }
        public DataTemplate? TableBlockTemplate { get; set; }

        protected override DataTemplate? SelectTemplateCore(object item)
        {
            return item switch
            {
                InputFieldsBlock => InputBlockTemplate,
                ButtonRowBlock => ButtonRowBlockTemplate,
                TableBlock => TableBlockTemplate,
                _ => null,
            };
        }

        protected override DataTemplate? SelectTemplateCore(object item, DependencyObject container)
        {
            return SelectTemplateCore(item);
        }
    }

    /// <summary>Picks the template for a single input field by its kind.</summary>
    public class FormFieldTemplateSelector : DataTemplateSelector
    {
        public DataTemplate? TextTemplate { get; set; }
        public DataTemplate? BoolTemplate { get; set; }
        public DataTemplate? DateTemplate { get; set; }
        public DataTemplate? ComboTemplate { get; set; }

        protected override DataTemplate? SelectTemplateCore(object item)
        {
            return item switch
            {
                TextFormField => TextTemplate,
                BoolFormField => BoolTemplate,
                DateFormField => DateTemplate,
                SelectFormField => ComboTemplate,
                _ => null,
            };
        }

        protected override DataTemplate? SelectTemplateCore(object item, DependencyObject container)
        {
            return SelectTemplateCore(item);
        }
    }
}
