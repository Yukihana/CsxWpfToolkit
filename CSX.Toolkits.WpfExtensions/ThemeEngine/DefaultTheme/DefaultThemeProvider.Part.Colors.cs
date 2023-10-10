using CSX.Toolkits.WpfExtensions.Media;
using System.Collections.Generic;
using System.Windows.Media;

namespace CSX.Toolkits.WpfExtensions.ThemeEngine.DefaultTheme;

public partial class DefaultThemeProvider
{
    private readonly Dictionary<ThemeSlots, Color> _colors = new()
    {
        // Control Background
        { ThemeSlots.ControlBackgroundNormal, ColorValues.Hex55.AsColor() },
        { ThemeSlots.ControlBackgroundFocused, ColorValues.Hex77.AsColor() },
        { ThemeSlots.ControlBackgroundPressed, ColorValues.Hex99.AsColor() },
        { ThemeSlots.ControlBackgroundEmphasis, ColorValues.HexBB.AsColor() },
        { ThemeSlots.ControlBackgroundDisabled, ColorValues.HexBB.AsColor(ColorValues.HexBB) },
    };
}