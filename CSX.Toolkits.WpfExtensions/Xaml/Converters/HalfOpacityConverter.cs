using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CSX.Toolkits.WpfExtensions.Xaml.Converters;

public class HalfOpacityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not Color color)
            return value;

        return Color.FromArgb(
            a: (byte)(color.A / 2),
            r: color.R,
            g: color.G,
            b: color.B);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not Color color)
            return value;

        return Color.FromArgb(
            a: (byte)(color.A * 2),
            r: color.R,
            g: color.G,
            b: color.B);
    }
}