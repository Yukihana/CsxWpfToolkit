using System.Windows;

namespace CSX.Toolkits.WpfExtensions.ThemeEngine;

public static partial class ControlComponents
{
    // Background

    public static ResourceKey ControlBackgroundNormalColorKey { get; } = GetColorKey(ThemeSlots.ControlBackgroundNormal);
    public static ResourceKey ControlBackgroundFocusedColorKey { get; } = GetColorKey(ThemeSlots.ControlBackgroundFocused);
    public static ResourceKey ControlBackgroundPressedColorKey { get; } = GetColorKey(ThemeSlots.ControlBackgroundPressed);
    public static ResourceKey ControlBackgroundEmphasisColorKey { get; } = GetColorKey(ThemeSlots.ControlBackgroundEmphasis);
    public static ResourceKey ControlBackgroundDisabledColorKey { get; } = GetColorKey(ThemeSlots.ControlBackgroundDisabled);

    public static ResourceKey ControlBackgroundNormalBrushKey { get; } = GetBrushKey(ThemeSlots.ControlBackgroundNormal);
    public static ResourceKey ControlBackgroundFocusedBrushKey { get; } = GetBrushKey(ThemeSlots.ControlBackgroundFocused);
    public static ResourceKey ControlBackgroundPressedBrushKey { get; } = GetBrushKey(ThemeSlots.ControlBackgroundPressed);
    public static ResourceKey ControlBackgroundEmphasisBrushKey { get; } = GetBrushKey(ThemeSlots.ControlBackgroundEmphasis);
    public static ResourceKey ControlBackgroundDisabledBrushKey { get; } = GetBrushKey(ThemeSlots.ControlBackgroundDisabled);

    // Auxiliary

    public static ResourceKey ControlAuxiliaryNormalColorKey { get; } = GetColorKey(ThemeSlots.ControlAuxiliaryNormal);
    public static ResourceKey ControlAuxiliaryFocusedColorKey { get; } = GetColorKey(ThemeSlots.ControlAuxiliaryFocused);
    public static ResourceKey ControlAuxiliaryPressedColorKey { get; } = GetColorKey(ThemeSlots.ControlAuxiliaryPressed);
    public static ResourceKey ControlAuxiliaryEmphasisColorKey { get; } = GetColorKey(ThemeSlots.ControlAuxiliaryEmphasis);
    public static ResourceKey ControlAuxiliaryDisabledColorKey { get; } = GetColorKey(ThemeSlots.ControlAuxiliaryDisabled);

    public static ResourceKey ControlAuxiliaryNormalBrushKey { get; } = GetBrushKey(ThemeSlots.ControlAuxiliaryNormal);
    public static ResourceKey ControlAuxiliaryFocusedBrushKey { get; } = GetBrushKey(ThemeSlots.ControlAuxiliaryFocused);
    public static ResourceKey ControlAuxiliaryPressedBrushKey { get; } = GetBrushKey(ThemeSlots.ControlAuxiliaryPressed);
    public static ResourceKey ControlAuxiliaryEmphasisBrushKey { get; } = GetBrushKey(ThemeSlots.ControlAuxiliaryEmphasis);
    public static ResourceKey ControlAuxiliaryDisabledBrushKey { get; } = GetBrushKey(ThemeSlots.ControlAuxiliaryDisabled);

    // Border

    public static ResourceKey ControlBorderNormalColorKey { get; } = GetColorKey(ThemeSlots.ControlBorderNormal);
    public static ResourceKey ControlBorderFocusedColorKey { get; } = GetColorKey(ThemeSlots.ControlBorderFocused);
    public static ResourceKey ControlBorderPressedColorKey { get; } = GetColorKey(ThemeSlots.ControlBorderPressed);
    public static ResourceKey ControlBorderEmphasisColorKey { get; } = GetColorKey(ThemeSlots.ControlBorderEmphasis);
    public static ResourceKey ControlBorderDisabledColorKey { get; } = GetColorKey(ThemeSlots.ControlBorderDisabled);

    public static ResourceKey ControlBorderNormalBrushKey { get; } = GetBrushKey(ThemeSlots.ControlBorderNormal);
    public static ResourceKey ControlBorderFocusedBrushKey { get; } = GetBrushKey(ThemeSlots.ControlBorderFocused);
    public static ResourceKey ControlBorderPressedBrushKey { get; } = GetBrushKey(ThemeSlots.ControlBorderPressed);
    public static ResourceKey ControlBorderEmphasisBrushKey { get; } = GetBrushKey(ThemeSlots.ControlBorderEmphasis);
    public static ResourceKey ControlBorderDisabledBrushKey { get; } = GetBrushKey(ThemeSlots.ControlBorderDisabled);

    // Foreground

    public static ResourceKey ControlForegroundNormalColorKey { get; } = GetColorKey(ThemeSlots.ControlForegroundNormal);
    public static ResourceKey ControlForegroundFocusedColorKey { get; } = GetColorKey(ThemeSlots.ControlForegroundFocused);
    public static ResourceKey ControlForegroundPressedColorKey { get; } = GetColorKey(ThemeSlots.ControlForegroundPressed);
    public static ResourceKey ControlForegroundEmphasisColorKey { get; } = GetColorKey(ThemeSlots.ControlForegroundEmphasis);
    public static ResourceKey ControlForegroundDisabledColorKey { get; } = GetColorKey(ThemeSlots.ControlForegroundDisabled);

    public static ResourceKey ControlForegroundNormalBrushKey { get; } = GetBrushKey(ThemeSlots.ControlForegroundNormal);
    public static ResourceKey ControlForegroundFocusedBrushKey { get; } = GetBrushKey(ThemeSlots.ControlForegroundFocused);
    public static ResourceKey ControlForegroundPressedBrushKey { get; } = GetBrushKey(ThemeSlots.ControlForegroundPressed);
    public static ResourceKey ControlForegroundEmphasisBrushKey { get; } = GetBrushKey(ThemeSlots.ControlForegroundEmphasis);
    public static ResourceKey ControlForegroundDisabledBrushKey { get; } = GetBrushKey(ThemeSlots.ControlForegroundDisabled);

    // Text

    public static ResourceKey ControlTextNormalColorKey { get; } = GetColorKey(ThemeSlots.ControlTextNormal);
    public static ResourceKey ControlTextFocusedColorKey { get; } = GetColorKey(ThemeSlots.ControlTextFocused);
    public static ResourceKey ControlTextPressedColorKey { get; } = GetColorKey(ThemeSlots.ControlTextPressed);
    public static ResourceKey ControlTextEmphasisColorKey { get; } = GetColorKey(ThemeSlots.ControlTextEmphasis);
    public static ResourceKey ControlTextDisabledColorKey { get; } = GetColorKey(ThemeSlots.ControlTextDisabled);

    public static ResourceKey ControlTextNormalBrushKey { get; } = GetBrushKey(ThemeSlots.ControlTextNormal);
    public static ResourceKey ControlTextFocusedBrushKey { get; } = GetBrushKey(ThemeSlots.ControlTextFocused);
    public static ResourceKey ControlTextPressedBrushKey { get; } = GetBrushKey(ThemeSlots.ControlTextPressed);
    public static ResourceKey ControlTextEmphasisBrushKey { get; } = GetBrushKey(ThemeSlots.ControlTextEmphasis);
    public static ResourceKey ControlTextDisabledBrushKey { get; } = GetBrushKey(ThemeSlots.ControlTextDisabled);
}