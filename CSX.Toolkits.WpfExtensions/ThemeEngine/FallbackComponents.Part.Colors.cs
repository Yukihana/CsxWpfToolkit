using System.Windows.Media;

namespace CSX.Toolkits.WpfExtensions.ThemeEngine;

public static partial class FallbackComponents
{
    private static readonly Color _defaultFallbackColor = Color.FromArgb(255, 255, 0, 255);

    public static Color GetColor(ThemeSlots slot) => slot switch
    {
        _ => _defaultFallbackColor,
    };
}