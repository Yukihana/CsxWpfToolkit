using CSX.Toolkits.WpfExtensions.Media;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CSX.Toolkits.WpfExtensions.Xaml.Converters;

public class HighlightOverlayMixer : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        => (((Color)values[0] * 0.75f) + ((Color)values[1] * 0.25f)).Flatten();

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}