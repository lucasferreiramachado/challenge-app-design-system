using System.Globalization;

namespace DesignSystem.Converters;

public sealed class NotEmptyStringToBoolConverter : IValueConverter
{
    public bool Default { get; set; } = false;
    
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string stringValue)
        {
            return !string.IsNullOrEmpty(stringValue);
        }
        return Default;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}