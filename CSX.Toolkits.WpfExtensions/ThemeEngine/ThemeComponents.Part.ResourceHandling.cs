using System.Reflection;
using System.Windows;
using System.Windows.Media;

namespace CSX.Toolkits.WpfExtensions.ThemeEngine;

public static partial class ThemeComponents
{
    // Key creators

    private static ResourceKey GetColorKey(ThemeSlots slot)
        => new ComponentResourceKey(typeof(ThemeComponents), slot.ToColorResourceId());

    private static ResourceKey GetBrushKey(ThemeSlots slot)
        => new ComponentResourceKey(typeof(ThemeComponents), slot.ToBrushResourceId());

    // Provider Api

    private static Color GetColor(ThemeSlots slot)
    {
        if (_provider.TryGetColor(slot, out Color color))
            return color;

        WarnColorMissing(slot);
        return FallbackComponents.GetColor(slot);
    }

    private static Brush GetBrush(ThemeSlots slot)
    {
        if (Provider.TryGetBrush(slot, out Brush? brush))
            return brush;

        WarnBrushMissing(slot);
        return FallbackComponents.GetBrush(slot);
    }

    // Provider resource update request handling

    private static void OnRequestColorUpdate(IThemeProvider provider, ThemeSlots slot)
    {
        if (provider != Provider)
            return;

        var keyPropertyName = $"{slot}ColorKey";
        var key = typeof(ThemeComponents).GetProperty(keyPropertyName, BindingFlags.Static)?.GetValue(null);
        if (key is null)
        {
            WarnKeyMissing(keyPropertyName);
            return;
        }

        ResourceDictionary[key] = GetColor(slot);
    }

    private static void OnRequestBrushUpdate(IThemeProvider provider, ThemeSlots slot)
    {
        if (provider != Provider)
            return;

        var keyPropertyName = $"{slot}BrushKey";
        var key = typeof(ThemeComponents).GetProperty(keyPropertyName, BindingFlags.Static)?.GetValue(null);
        if (key is null)
        {
            WarnKeyMissing(keyPropertyName);
            return;
        }

        ResourceDictionary[key] = GetBrush(slot);
    }
}