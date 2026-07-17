using System;
using System.Globalization;
using System.Windows.Data;

namespace HtmlWpf.Converters
{
    /// <summary>
    /// Bridges model DateTime/DateTime? properties to DatePicker.SelectedDate
    /// (DateTime?). default(DateTime) renders as an empty picker.
    /// </summary>
    public class DateTimeToNullableDateTimeConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value is DateTime dt && dt != default ? dt : null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is DateTime dt)
            {
                return dt;
            }
            return targetType == typeof(DateTime) ? default(DateTime) : null;
        }
    }
}
