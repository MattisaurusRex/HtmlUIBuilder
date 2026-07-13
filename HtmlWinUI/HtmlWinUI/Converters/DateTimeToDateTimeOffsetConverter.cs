using System;
using Microsoft.UI.Xaml.Data;

namespace HtmlWinUI.Converters
{
    /// <summary>
    /// Bridges model DateTime/DateTime? properties to CalendarDatePicker.Date
    /// (DateTimeOffset?). default(DateTime) renders as an empty picker.
    /// </summary>
    public class DateTimeToDateTimeOffsetConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, string language)
        {
            return value is DateTime dt && dt != default ? new DateTimeOffset(dt) : null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, string language)
        {
            if (value is DateTimeOffset dto)
            {
                return dto.DateTime;
            }
            return targetType == typeof(DateTime) ? default(DateTime) : null;
        }
    }
}
