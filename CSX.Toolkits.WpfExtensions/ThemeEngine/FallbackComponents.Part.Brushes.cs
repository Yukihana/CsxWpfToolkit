using System.Windows.Media;

namespace CSX.Toolkits.WpfExtensions.ThemeEngine;

public static partial class FallbackComponents
{
    private static readonly Brush _defaultFallbackBrush = new SolidColorBrush(Color.FromArgb(255, 255, 0, 255));

    public static Brush GetBrush(ThemeSlots slot) => slot switch
    {
        _ => _defaultFallbackBrush,
    };
}