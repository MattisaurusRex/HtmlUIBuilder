using System.Windows;

namespace HtmlWpf.Controls
{
    /// <summary>
    /// Attached CornerRadius for buttons: WinUI buttons expose CornerRadius
    /// directly, WPF buttons need it fed into their ControlTemplate
    /// (see RoundedButtonTemplate in App.xaml).
    /// </summary>
    public static class ButtonProperties
    {
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.RegisterAttached(
            "CornerRadius", typeof(CornerRadius), typeof(ButtonProperties), new PropertyMetadata(new CornerRadius(0)));

        public static CornerRadius GetCornerRadius(DependencyObject obj) => (CornerRadius)obj.GetValue(CornerRadiusProperty);

        public static void SetCornerRadius(DependencyObject obj, CornerRadius value) => obj.SetValue(CornerRadiusProperty, value);
    }
}
