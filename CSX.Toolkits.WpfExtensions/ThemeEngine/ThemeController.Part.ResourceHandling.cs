using System;
using System.Reflection;
using System.Windows;
using System.Windows.Media;

namespace CSX.Toolkits.WpfExtensions.ThemeEngine;

public static partial class ThemeController
{
    // Provider Api

    private static Color GetColor(ThemeSlots slot)
    {
        if (_provider.TryGetColor(slot, out Color color))
            return color;

        WarnColorMissing(slot);
        return ThemeFallback.GetColor(slot);
    }

    private static Brush GetBrush(ThemeSlots slot)
    {
        if (Provider.TryGetBrush(slot, out Brush? brush))
            return brush;

        WarnBrushMissing(slot);
        return ThemeFallback.GetBrush(slot);
    }

    // Provider resource update request handling

    private static void OnRequestColorUpdate(IThemeProvider provider, ThemeSlots slot)
    {
        if (provider != Provider)
            return;

        Color newValue = GetColor(slot);

        if (ControlComponents.TryUpdateColor(slot, newValue))
            return;
        // else if()

        // If nothing succeeds
        WarnColorUpdateFailed(slot);
    }

    private static void OnRequestBrushUpdate(IThemeProvider provider, ThemeSlots slot)
    {
        if (provider != Provider)
            return;

        Brush newValue = GetBrush(slot);

        if (ControlComponents.TryUpdateBrush(slot, newValue))
            return;
        // else if()

        // If nothing succeeds
        WarnBrushUpdateFailed(slot);
    }
}