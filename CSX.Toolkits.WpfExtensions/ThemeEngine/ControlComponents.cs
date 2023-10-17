using System.Windows;

namespace CSX.Toolkits.WpfExtensions.ThemeEngine;

public static partial class ControlComponents
{
    private static readonly ThemeComponentsDictionary _resourceDictionary = new();
    public static ResourceDictionary ResourceDictionary => _resourceDictionary;

    // Init

    static ControlComponents()
        => Application.Current.Resources.MergedDictionaries.Add(_resourceDictionary);

    // Keymakers

    private static ResourceKey GetColorKey(ThemeSlots slot)
        => new ComponentResourceKey(typeof(ControlComponents), slot.ToColorResourceId());

    private static ResourceKey GetBrushKey(ThemeSlots slot)
        => new ComponentResourceKey(typeof(ControlComponents), slot.ToBrushResourceId());
}