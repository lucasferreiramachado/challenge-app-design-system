using System.Globalization;

namespace DesignSystem.Converters;

public sealed class EmptyStringColorConverter : IValueConverter
{
    public Color EmptyColor { get; set; } = Colors.Transparent;
    public Color NotEmptyColor { get; set; } = Colors.Transparent;

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string stringValue)
        {
            
            return string.IsNullOrEmpty(stringValue) ? EmptyColor : NotEmptyColor;
        }
        return NotEmptyColor;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}