using System.Windows.Media;

namespace CSX.Toolkits.WpfExtensions.ThemeEngine;

public static partial class ThemeEngineHelper
{
    public static SolidColorBrush GenerateSolidColorBrush(this Color color)
    {
        SolidColorBrush brush = new(color);
        brush.Freeze();
        return brush;
    }

    public static string ToColorResourceId(this ThemeSlots slot)
        => $"Theme{slot}ColorKey";

    public static string ToBrushResourceId(this ThemeSlots slot)
        => $"Theme{slot}BrushKey";
}