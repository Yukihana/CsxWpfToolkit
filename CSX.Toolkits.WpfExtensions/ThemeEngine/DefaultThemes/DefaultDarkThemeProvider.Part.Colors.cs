using CSX.Toolkits.WpfExtensions.Media;
using System.Collections.Generic;
using System.Windows.Media;

namespace CSX.Toolkits.WpfExtensions.ThemeEngine.DefaultThemes;

public partial class DefaultDarkThemeProvider
{
    private readonly Dictionary<ThemeSlots, Color> _colors = new()
    {
        // Control Background
        { ThemeSlots.ControlBackgroundNormal, ColorValues.Hex55.AsColor() },
        { ThemeSlots.ControlBackgroundFocused, ColorValues.Hex77.AsColor() },
        { ThemeSlots.ControlBackgroundPressed, ColorValues.Hex99.AsColor() },
        { ThemeSlots.ControlBackgroundEmphasis, ColorValues.HexBB.AsColor() },
        { ThemeSlots.ControlBackgroundDisabled, ColorValues.HexBB.AsColor(ColorValues.HexBB) },

        // Control Border
        { ThemeSlots.ControlBorderNormal, ColorValues.Hex55.AsColor() },
        { ThemeSlots.ControlBorderFocused, ColorValues.Hex77.AsColor() },
        { ThemeSlots.ControlBorderPressed, ColorValues.Hex99.AsColor() },
        { ThemeSlots.ControlBorderEmphasis, ColorValues.HexBB.AsColor() },
        { ThemeSlots.ControlBorderDisabled, ColorValues.HexBB.AsColor(ColorValues.HexBB) },

        // Control Foreground
        { ThemeSlots.ControlForegroundNormal, ColorValues.Hex55.AsColor() },
        { ThemeSlots.ControlForegroundFocused, ColorValues.Hex77.AsColor() },
        { ThemeSlots.ControlForegroundPressed, ColorValues.Hex99.AsColor() },
        { ThemeSlots.ControlForegroundEmphasis, ColorValues.HexBB.AsColor() },
        { ThemeSlots.ControlForegroundDisabled, ColorValues.HexBB.AsColor(ColorValues.HexBB) },

        // Control Text
        { ThemeSlots.ControlTextNormal, ColorValues.Hex55.AsColor() },
        { ThemeSlots.ControlTextFocused, ColorValues.Hex77.AsColor() },
        { ThemeSlots.ControlTextPressed, ColorValues.Hex99.AsColor() },
        { ThemeSlots.ControlTextEmphasis, ColorValues.HexBB.AsColor() },
        { ThemeSlots.ControlTextDisabled, ColorValues.HexBB.AsColor(ColorValues.HexBB) },
    };
}