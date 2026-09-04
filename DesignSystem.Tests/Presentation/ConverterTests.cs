using System.Globalization;
using DesignSystem.Converters;
using Xunit;

namespace DesignSystem.Tests.Presentation;

public class ConverterTests
{
    private static readonly CultureInfo Culture = CultureInfo.InvariantCulture;

    [Fact]
    public void EmptyStringColorConverter_ReturnsEmptyColorForEmptyText()
    {
        var converter = new EmptyStringColorConverter
        {
            EmptyColor = Colors.Red,
            NotEmptyColor = Colors.Green
        };

        var result = converter.Convert(string.Empty, typeof(Color), null!, Culture);

        Assert.Equal(Colors.Red, result);
    }

    [Fact]
    public void EmptyStringColorConverter_ReturnsNotEmptyColorForText()
    {
        var converter = new EmptyStringColorConverter
        {
            EmptyColor = Colors.Red,
            NotEmptyColor = Colors.Green
        };

        var result = converter.Convert("value", typeof(Color), null!, Culture);

        Assert.Equal(Colors.Green, result);
    }

    [Fact]
    public void NotEmptyStringToBoolConverter_ReturnsTrueOnlyForNonEmptyText()
    {
        var converter = new NotEmptyStringToBoolConverter();

        Assert.True((bool)converter.Convert("value", typeof(bool), null!, Culture));
        Assert.False((bool)converter.Convert(string.Empty, typeof(bool), null!, Culture));
    }
}
