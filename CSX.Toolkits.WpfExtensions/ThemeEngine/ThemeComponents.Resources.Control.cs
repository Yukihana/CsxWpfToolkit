using System.Windows;
using System.Windows.Media;

namespace CSX.Toolkits.WpfExtensions.ThemeEngine;

public static partial class ThemeComponents
{
    // Resource Keys : Colors

    public static ResourceKey ControlBackgroundNormalColorKey { get; } = GetColorKey(ThemeSlots.ControlBackgroundNormal);
    public static ResourceKey ControlBackgroundFocusedColorKey { get; } = GetColorKey(ThemeSlots.ControlBackgroundFocused);
    public static ResourceKey ControlBackgroundPressedColorKey { get; } = GetColorKey(ThemeSlots.ControlBackgroundPressed);
    public static ResourceKey ControlBackgroundEmphasisColorKey { get; } = GetColorKey(ThemeSlots.ControlBackgroundEmphasis);
    public static ResourceKey ControlBackgroundDisabledColorKey { get; } = GetColorKey(ThemeSlots.ControlBackgroundDisabled);

    public static ResourceKey ControlBorderNormalColorKey { get; } = GetColorKey(ThemeSlots.ControlBorderNormal);
    public static ResourceKey ControlBorderFocusedColorKey { get; } = GetColorKey(ThemeSlots.ControlBorderFocused);
    public static ResourceKey ControlBorderPressedColorKey { get; } = GetColorKey(ThemeSlots.ControlBorderPressed);
    public static ResourceKey ControlBorderEmphasisColorKey { get; } = GetColorKey(ThemeSlots.ControlBorderEmphasis);
    public static ResourceKey ControlBorderDisabledColorKey { get; } = GetColorKey(ThemeSlots.ControlBorderDisabled);

    public static ResourceKey ControlForegroundNormalColorKey { get; } = GetColorKey(ThemeSlots.ControlForegroundNormal);
    public static ResourceKey ControlForegroundFocusedColorKey { get; } = GetColorKey(ThemeSlots.ControlForegroundFocused);
    public static ResourceKey ControlForegroundPressedColorKey { get; } = GetColorKey(ThemeSlots.ControlForegroundPressed);
    public static ResourceKey ControlForegroundEmphasisColorKey { get; } = GetColorKey(ThemeSlots.ControlForegroundEmphasis);
    public static ResourceKey ControlForegroundDisabledColorKey { get; } = GetColorKey(ThemeSlots.ControlForegroundDisabled);

    public static ResourceKey ControlTextNormalColorKey { get; } = GetColorKey(ThemeSlots.ControlTextNormal);
    public static ResourceKey ControlTextFocusedColorKey { get; } = GetColorKey(ThemeSlots.ControlTextFocused);
    public static ResourceKey ControlTextPressedColorKey { get; } = GetColorKey(ThemeSlots.ControlTextPressed);
    public static ResourceKey ControlTextEmphasisColorKey { get; } = GetColorKey(ThemeSlots.ControlTextEmphasis);
    public static ResourceKey ControlTextDisabledColorKey { get; } = GetColorKey(ThemeSlots.ControlTextDisabled);

    // Resource Keys : Brushes

    public static ResourceKey ControlBackgroundNormalBrushKey { get; } = GetBrushKey(ThemeSlots.ControlBackgroundNormal);
    public static ResourceKey ControlBackgroundFocusedBrushKey { get; } = GetBrushKey(ThemeSlots.ControlBackgroundFocused);
    public static ResourceKey ControlBackgroundPressedBrushKey { get; } = GetBrushKey(ThemeSlots.ControlBackgroundPressed);
    public static ResourceKey ControlBackgroundEmphasisBrushKey { get; } = GetBrushKey(ThemeSlots.ControlBackgroundEmphasis);
    public static ResourceKey ControlBackgroundDisabledBrushKey { get; } = GetBrushKey(ThemeSlots.ControlBackgroundDisabled);

    public static ResourceKey ControlBorderNormalBrushKey { get; } = GetBrushKey(ThemeSlots.ControlBorderNormal);
    public static ResourceKey ControlBorderFocusedBrushKey { get; } = GetBrushKey(ThemeSlots.ControlBorderFocused);
    public static ResourceKey ControlBorderPressedBrushKey { get; } = GetBrushKey(ThemeSlots.ControlBorderPressed);
    public static ResourceKey ControlBorderEmphasisBrushKey { get; } = GetBrushKey(ThemeSlots.ControlBorderEmphasis);
    public static ResourceKey ControlBorderDisabledBrushKey { get; } = GetBrushKey(ThemeSlots.ControlBorderDisabled);

    public static ResourceKey ControlForegroundNormalBrushKey { get; } = GetBrushKey(ThemeSlots.ControlForegroundNormal);
    public static ResourceKey ControlForegroundFocusedBrushKey { get; } = GetBrushKey(ThemeSlots.ControlForegroundFocused);
    public static ResourceKey ControlForegroundPressedBrushKey { get; } = GetBrushKey(ThemeSlots.ControlForegroundPressed);
    public static ResourceKey ControlForegroundEmphasisBrushKey { get; } = GetBrushKey(ThemeSlots.ControlForegroundEmphasis);
    public static ResourceKey ControlForegroundDisabledBrushKey { get; } = GetBrushKey(ThemeSlots.ControlForegroundDisabled);

    public static ResourceKey ControlTextNormalBrushKey { get; } = GetBrushKey(ThemeSlots.ControlTextNormal);
    public static ResourceKey ControlTextFocusedBrushKey { get; } = GetBrushKey(ThemeSlots.ControlTextFocused);
    public static ResourceKey ControlTextPressedBrushKey { get; } = GetBrushKey(ThemeSlots.ControlTextPressed);
    public static ResourceKey ControlTextEmphasisBrushKey { get; } = GetBrushKey(ThemeSlots.ControlTextEmphasis);
    public static ResourceKey ControlTextDisabledBrushKey { get; } = GetBrushKey(ThemeSlots.ControlTextDisabled);

    // Fields

    private static Color _controlBackgroundNormalColor = SystemColors.ControlColor;
    private static Color _controlBackgroundFocusedColor = SystemColors.ControlColor;
    private static Color _controlBackgroundPressedColor = SystemColors.ControlColor;
    private static Color _controlBackgroundEmphasisColor = SystemColors.ControlColor;
    private static Color _controlBackgroundDisabledColor = SystemColors.ControlColor;

    private static Color _controlBorderNormalColor = SystemColors.ControlColor;
    private static Color _controlBorderFocusedColor = SystemColors.ControlColor;
    private static Color _controlBorderPressedColor = SystemColors.ControlColor;
    private static Color _controlBorderEmphasisColor = SystemColors.ControlColor;
    private static Color _controlBorderDisabledColor = SystemColors.ControlColor;

    private static Color _controlForegroundNormalColor = SystemColors.ControlColor;
    private static Color _controlForegroundFocusedColor = SystemColors.ControlColor;
    private static Color _controlForegroundPressedColor = SystemColors.ControlColor;
    private static Color _controlForegroundEmphasisColor = SystemColors.ControlColor;
    private static Color _controlForegroundDisabledColor = SystemColors.ControlColor;

    private static Color _controlTextNormalColor = SystemColors.ControlColor;
    private static Color _controlTextFocusedColor = SystemColors.ControlColor;
    private static Color _controlTextPressedColor = SystemColors.ControlColor;
    private static Color _controlTextEmphasisColor = SystemColors.ControlColor;
    private static Color _controlTextDisabledColor = SystemColors.ControlColor;

    // Brush

    private static Brush _controlBackgroundNormalBrush = SystemColors.ControlBrush;
    private static Brush _controlBackgroundFocusedBrush = SystemColors.ControlBrush;
    private static Brush _controlBackgroundPressedBrush = SystemColors.ControlBrush;
    private static Brush _controlBackgroundEmphasisBrush = SystemColors.ControlBrush;
    private static Brush _controlBackgroundDisabledBrush = SystemColors.ControlBrush;

    private static Brush _controlBorderNormalBrush = SystemColors.ControlBrush;
    private static Brush _controlBorderFocusedBrush = SystemColors.ControlBrush;
    private static Brush _controlBorderPressedBrush = SystemColors.ControlBrush;
    private static Brush _controlBorderEmphasisBrush = SystemColors.ControlBrush;
    private static Brush _controlBorderDisabledBrush = SystemColors.ControlBrush;

    private static Brush _controlForegroundNormalBrush = SystemColors.ControlBrush;
    private static Brush _controlForegroundFocusedBrush = SystemColors.ControlBrush;
    private static Brush _controlForegroundPressedBrush = SystemColors.ControlBrush;
    private static Brush _controlForegroundEmphasisBrush = SystemColors.ControlBrush;
    private static Brush _controlForegroundDisabledBrush = SystemColors.ControlBrush;

    private static Brush _controlTextNormalBrush = SystemColors.ControlBrush;
    private static Brush _controlTextFocusedBrush = SystemColors.ControlBrush;
    private static Brush _controlTextPressedBrush = SystemColors.ControlBrush;
    private static Brush _controlTextEmphasisBrush = SystemColors.ControlBrush;
    private static Brush _controlTextDisabledBrush = SystemColors.ControlBrush;

    // Setup

    private static void AssignControlTheme()
    {
        // Colors

        ControlBackgroundNormalColor = GetColor(ThemeSlots.ControlBackgroundNormal);
        ControlBackgroundFocusedColor = GetColor(ThemeSlots.ControlBackgroundFocused);
        ControlBackgroundPressedColor = GetColor(ThemeSlots.ControlBackgroundPressed);
        ControlBackgroundEmphasisColor = GetColor(ThemeSlots.ControlBackgroundEmphasis);
        ControlBackgroundDisabledColor = GetColor(ThemeSlots.ControlBackgroundNormal);

        ControlBorderNormalColor = GetColor(ThemeSlots.ControlBorderNormal);
        ControlBorderFocusedColor = GetColor(ThemeSlots.ControlBorderFocused);
        ControlBorderPressedColor = GetColor(ThemeSlots.ControlBorderPressed);
        ControlBorderEmphasisColor = GetColor(ThemeSlots.ControlBorderEmphasis);
        ControlBorderDisabledColor = GetColor(ThemeSlots.ControlBorderNormal);

        ControlForegroundNormalColor = GetColor(ThemeSlots.ControlForegroundNormal);
        ControlForegroundFocusedColor = GetColor(ThemeSlots.ControlForegroundFocused);
        ControlForegroundPressedColor = GetColor(ThemeSlots.ControlForegroundPressed);
        ControlForegroundEmphasisColor = GetColor(ThemeSlots.ControlForegroundEmphasis);
        ControlForegroundDisabledColor = GetColor(ThemeSlots.ControlForegroundNormal);

        ControlTextNormalColor = GetColor(ThemeSlots.ControlTextNormal);
        ControlTextFocusedColor = GetColor(ThemeSlots.ControlTextFocused);
        ControlTextPressedColor = GetColor(ThemeSlots.ControlTextPressed);
        ControlTextEmphasisColor = GetColor(ThemeSlots.ControlTextEmphasis);
        ControlTextDisabledColor = GetColor(ThemeSlots.ControlTextNormal);

        // Brushes

        ControlBackgroundNormalBrush = GetBrush(ThemeSlots.ControlBackgroundNormal);
        ControlBackgroundFocusedBrush = GetBrush(ThemeSlots.ControlBackgroundFocused);
        ControlBackgroundPressedBrush = GetBrush(ThemeSlots.ControlBackgroundPressed);
        ControlBackgroundEmphasisBrush = GetBrush(ThemeSlots.ControlBackgroundEmphasis);
        ControlBackgroundDisabledBrush = GetBrush(ThemeSlots.ControlBackgroundNormal);

        ControlBorderNormalBrush = GetBrush(ThemeSlots.ControlBorderNormal);
        ControlBorderFocusedBrush = GetBrush(ThemeSlots.ControlBorderFocused);
        ControlBorderPressedBrush = GetBrush(ThemeSlots.ControlBorderPressed);
        ControlBorderEmphasisBrush = GetBrush(ThemeSlots.ControlBorderEmphasis);
        ControlBorderDisabledBrush = GetBrush(ThemeSlots.ControlBorderNormal);

        ControlForegroundNormalBrush = GetBrush(ThemeSlots.ControlForegroundNormal);
        ControlForegroundFocusedBrush = GetBrush(ThemeSlots.ControlForegroundFocused);
        ControlForegroundPressedBrush = GetBrush(ThemeSlots.ControlForegroundPressed);
        ControlForegroundEmphasisBrush = GetBrush(ThemeSlots.ControlForegroundEmphasis);
        ControlForegroundDisabledBrush = GetBrush(ThemeSlots.ControlForegroundNormal);

        ControlTextNormalBrush = GetBrush(ThemeSlots.ControlTextNormal);
        ControlTextFocusedBrush = GetBrush(ThemeSlots.ControlTextFocused);
        ControlTextPressedBrush = GetBrush(ThemeSlots.ControlTextPressed);
        ControlTextEmphasisBrush = GetBrush(ThemeSlots.ControlTextEmphasis);
        ControlTextDisabledBrush = GetBrush(ThemeSlots.ControlTextNormal);
    }

    // ControlBackground

    public static Color ControlBackgroundNormalColor
    {
        get => _controlBackgroundNormalColor;
        set
        {
            _controlBackgroundNormalColor = value;
            _resourceDictionary[ControlBackgroundNormalColorKey] = value;
        }
    }

    public static Color ControlBackgroundFocusedColor
    {
        get => _controlBackgroundFocusedColor;
        set
        {
            _controlBackgroundFocusedColor = value;
            _resourceDictionary[ControlBackgroundFocusedColorKey] = value;
        }
    }

    public static Color ControlBackgroundPressedColor
    {
        get => _controlBackgroundPressedColor;
        set
        {
            _controlBackgroundPressedColor = value;
            _resourceDictionary[ControlBackgroundPressedColorKey] = value;
        }
    }

    public static Color ControlBackgroundEmphasisColor
    {
        get => _controlBackgroundEmphasisColor;
        set
        {
            _controlBackgroundEmphasisColor = value;
            _resourceDictionary[ControlBackgroundEmphasisColorKey] = value;
        }
    }

    public static Color ControlBackgroundDisabledColor
    {
        get => _controlBackgroundDisabledColor;
        set
        {
            _controlBackgroundDisabledColor = value;
            _resourceDictionary[ControlBackgroundDisabledColorKey] = value;
        }
    }

    public static Brush ControlBackgroundNormalBrush
    {
        get => _controlBackgroundNormalBrush;
        set
        {
            _controlBackgroundNormalBrush = value;
            _resourceDictionary[ControlBackgroundNormalBrushKey] = value;
        }
    }

    public static Brush ControlBackgroundFocusedBrush
    {
        get => _controlBackgroundFocusedBrush;
        set
        {
            _controlBackgroundFocusedBrush = value;
            _resourceDictionary[ControlBackgroundFocusedBrushKey] = value;
        }
    }

    public static Brush ControlBackgroundPressedBrush
    {
        get => _controlBackgroundPressedBrush;
        set
        {
            _controlBackgroundPressedBrush = value;
            _resourceDictionary[ControlBackgroundPressedBrushKey] = value;
        }
    }

    public static Brush ControlBackgroundEmphasisBrush
    {
        get => _controlBackgroundEmphasisBrush;
        set
        {
            _controlBackgroundEmphasisBrush = value;
            _resourceDictionary[ControlBackgroundEmphasisBrushKey] = value;
        }
    }

    public static Brush ControlBackgroundDisabledBrush
    {
        get => _controlBackgroundDisabledBrush;
        set
        {
            _controlBackgroundDisabledBrush = value;
            _resourceDictionary[ControlBackgroundDisabledBrushKey] = value;
        }
    }

    // ControlBorder

    public static Color ControlBorderNormalColor
    {
        get => _controlBorderNormalColor;
        set
        {
            _controlBorderNormalColor = value;
            _resourceDictionary[ControlBorderNormalColorKey] = value;
        }
    }

    public static Color ControlBorderFocusedColor
    {
        get => _controlBorderFocusedColor;
        set
        {
            _controlBorderFocusedColor = value;
            _resourceDictionary[ControlBorderFocusedColorKey] = value;
        }
    }

    public static Color ControlBorderPressedColor
    {
        get => _controlBorderPressedColor;
        set
        {
            _controlBorderPressedColor = value;
            _resourceDictionary[ControlBorderPressedColorKey] = value;
        }
    }

    public static Color ControlBorderEmphasisColor
    {
        get => _controlBorderEmphasisColor;
        set
        {
            _controlBorderEmphasisColor = value;
            _resourceDictionary[ControlBorderEmphasisColorKey] = value;
        }
    }

    public static Color ControlBorderDisabledColor
    {
        get => _controlBorderDisabledColor;
        set
        {
            _controlBorderDisabledColor = value;
            _resourceDictionary[ControlBorderDisabledColorKey] = value;
        }
    }

    public static Brush ControlBorderNormalBrush
    {
        get => _controlBorderNormalBrush;
        set
        {
            _controlBorderNormalBrush = value;
            _resourceDictionary[ControlBorderNormalBrushKey] = value;
        }
    }

    public static Brush ControlBorderFocusedBrush
    {
        get => _controlBorderFocusedBrush;
        set
        {
            _controlBorderFocusedBrush = value;
            _resourceDictionary[ControlBorderFocusedBrushKey] = value;
        }
    }

    public static Brush ControlBorderPressedBrush
    {
        get => _controlBorderPressedBrush;
        set
        {
            _controlBorderPressedBrush = value;
            _resourceDictionary[ControlBorderPressedBrushKey] = value;
        }
    }

    public static Brush ControlBorderEmphasisBrush
    {
        get => _controlBorderEmphasisBrush;
        set
        {
            _controlBorderEmphasisBrush = value;
            _resourceDictionary[ControlBorderEmphasisBrushKey] = value;
        }
    }

    public static Brush ControlBorderDisabledBrush
    {
        get => _controlBorderDisabledBrush;
        set
        {
            _controlBorderDisabledBrush = value;
            _resourceDictionary[ControlBorderDisabledBrushKey] = value;
        }
    }

    // ControlForeground

    public static Color ControlForegroundNormalColor
    {
        get => _controlForegroundNormalColor;
        set
        {
            _controlForegroundNormalColor = value;
            _resourceDictionary[ControlForegroundNormalColorKey] = value;
        }
    }

    public static Color ControlForegroundFocusedColor
    {
        get => _controlForegroundFocusedColor;
        set
        {
            _controlForegroundFocusedColor = value;
            _resourceDictionary[ControlForegroundFocusedColorKey] = value;
        }
    }

    public static Color ControlForegroundPressedColor
    {
        get => _controlForegroundPressedColor;
        set
        {
            _controlForegroundPressedColor = value;
            _resourceDictionary[ControlForegroundPressedColorKey] = value;
        }
    }

    public static Color ControlForegroundEmphasisColor
    {
        get => _controlForegroundEmphasisColor;
        set
        {
            _controlForegroundEmphasisColor = value;
            _resourceDictionary[ControlForegroundEmphasisColorKey] = value;
        }
    }

    public static Color ControlForegroundDisabledColor
    {
        get => _controlForegroundDisabledColor;
        set
        {
            _controlForegroundDisabledColor = value;
            _resourceDictionary[ControlForegroundDisabledColorKey] = value;
        }
    }

    public static Brush ControlForegroundNormalBrush
    {
        get => _controlForegroundNormalBrush;
        set
        {
            _controlForegroundNormalBrush = value;
            _resourceDictionary[ControlForegroundNormalBrushKey] = value;
        }
    }

    public static Brush ControlForegroundFocusedBrush
    {
        get => _controlForegroundFocusedBrush;
        set
        {
            _controlForegroundFocusedBrush = value;
            _resourceDictionary[ControlForegroundFocusedBrushKey] = value;
        }
    }

    public static Brush ControlForegroundPressedBrush
    {
        get => _controlForegroundPressedBrush;
        set
        {
            _controlForegroundPressedBrush = value;
            _resourceDictionary[ControlForegroundPressedBrushKey] = value;
        }
    }

    public static Brush ControlForegroundEmphasisBrush
    {
        get => _controlForegroundEmphasisBrush;
        set
        {
            _controlForegroundEmphasisBrush = value;
            _resourceDictionary[ControlForegroundEmphasisBrushKey] = value;
        }
    }

    public static Brush ControlForegroundDisabledBrush
    {
        get => _controlForegroundDisabledBrush;
        set
        {
            _controlForegroundDisabledBrush = value;
            _resourceDictionary[ControlForegroundDisabledBrushKey] = value;
        }
    }

    // ControlText

    public static Color ControlTextNormalColor
    {
        get => _controlTextNormalColor;
        set
        {
            _controlTextNormalColor = value;
            _resourceDictionary[ControlTextNormalColorKey] = value;
        }
    }

    public static Color ControlTextFocusedColor
    {
        get => _controlTextFocusedColor;
        set
        {
            _controlTextFocusedColor = value;
            _resourceDictionary[ControlTextFocusedColorKey] = value;
        }
    }

    public static Color ControlTextPressedColor
    {
        get => _controlTextPressedColor;
        set
        {
            _controlTextPressedColor = value;
            _resourceDictionary[ControlTextPressedColorKey] = value;
        }
    }

    public static Color ControlTextEmphasisColor
    {
        get => _controlTextEmphasisColor;
        set
        {
            _controlTextEmphasisColor = value;
            _resourceDictionary[ControlTextEmphasisColorKey] = value;
        }
    }

    public static Color ControlTextDisabledColor
    {
        get => _controlTextDisabledColor;
        set
        {
            _controlTextDisabledColor = value;
            _resourceDictionary[ControlTextDisabledColorKey] = value;
        }
    }

    public static Brush ControlTextNormalBrush
    {
        get => _controlTextNormalBrush;
        set
        {
            _controlTextNormalBrush = value;
            _resourceDictionary[ControlTextNormalBrushKey] = value;
        }
    }

    public static Brush ControlTextFocusedBrush
    {
        get => _controlTextFocusedBrush;
        set
        {
            _controlTextFocusedBrush = value;
            _resourceDictionary[ControlTextFocusedBrushKey] = value;
        }
    }

    public static Brush ControlTextPressedBrush
    {
        get => _controlTextPressedBrush;
        set
        {
            _controlTextPressedBrush = value;
            _resourceDictionary[ControlTextPressedBrushKey] = value;
        }
    }

    public static Brush ControlTextEmphasisBrush
    {
        get => _controlTextEmphasisBrush;
        set
        {
            _controlTextEmphasisBrush = value;
            _resourceDictionary[ControlTextEmphasisBrushKey] = value;
        }
    }

    public static Brush ControlTextDisabledBrush
    {
        get => _controlTextDisabledBrush;
        set
        {
            _controlTextDisabledBrush = value;
            _resourceDictionary[ControlTextDisabledBrushKey] = value;
        }
    }
}