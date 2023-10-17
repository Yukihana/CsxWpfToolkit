using System;
using System.Windows.Media;

namespace CSX.Toolkits.WpfExtensions.ThemeEngine;

public static partial class ControlComponents
{
    // Assign

    public static void AssignColors(Func<ThemeSlots, Color> getColor)
    {
        ControlBackgroundNormalColor = getColor(ThemeSlots.ControlBackgroundNormal);
        ControlBackgroundFocusedColor = getColor(ThemeSlots.ControlBackgroundFocused);
        ControlBackgroundPressedColor = getColor(ThemeSlots.ControlBackgroundPressed);
        ControlBackgroundEmphasisColor = getColor(ThemeSlots.ControlBackgroundEmphasis);
        ControlBackgroundDisabledColor = getColor(ThemeSlots.ControlBackgroundNormal);

        ControlAuxiliaryNormalColor = getColor(ThemeSlots.ControlAuxiliaryNormal);
        ControlAuxiliaryFocusedColor = getColor(ThemeSlots.ControlAuxiliaryFocused);
        ControlAuxiliaryPressedColor = getColor(ThemeSlots.ControlAuxiliaryPressed);
        ControlAuxiliaryEmphasisColor = getColor(ThemeSlots.ControlAuxiliaryEmphasis);
        ControlAuxiliaryDisabledColor = getColor(ThemeSlots.ControlAuxiliaryNormal);

        ControlBorderNormalColor = getColor(ThemeSlots.ControlBorderNormal);
        ControlBorderFocusedColor = getColor(ThemeSlots.ControlBorderFocused);
        ControlBorderPressedColor = getColor(ThemeSlots.ControlBorderPressed);
        ControlBorderEmphasisColor = getColor(ThemeSlots.ControlBorderEmphasis);
        ControlBorderDisabledColor = getColor(ThemeSlots.ControlBorderNormal);

        ControlForegroundNormalColor = getColor(ThemeSlots.ControlForegroundNormal);
        ControlForegroundFocusedColor = getColor(ThemeSlots.ControlForegroundFocused);
        ControlForegroundPressedColor = getColor(ThemeSlots.ControlForegroundPressed);
        ControlForegroundEmphasisColor = getColor(ThemeSlots.ControlForegroundEmphasis);
        ControlForegroundDisabledColor = getColor(ThemeSlots.ControlForegroundNormal);

        ControlTextNormalColor = getColor(ThemeSlots.ControlTextNormal);
        ControlTextFocusedColor = getColor(ThemeSlots.ControlTextFocused);
        ControlTextPressedColor = getColor(ThemeSlots.ControlTextPressed);
        ControlTextEmphasisColor = getColor(ThemeSlots.ControlTextEmphasis);
        ControlTextDisabledColor = getColor(ThemeSlots.ControlTextNormal);
    }

    public static void AssignBrushes(Func<ThemeSlots, Brush> getBrush)
    {
        ControlBackgroundNormalBrush = getBrush(ThemeSlots.ControlBackgroundNormal);
        ControlBackgroundFocusedBrush = getBrush(ThemeSlots.ControlBackgroundFocused);
        ControlBackgroundPressedBrush = getBrush(ThemeSlots.ControlBackgroundPressed);
        ControlBackgroundEmphasisBrush = getBrush(ThemeSlots.ControlBackgroundEmphasis);
        ControlBackgroundDisabledBrush = getBrush(ThemeSlots.ControlBackgroundNormal);

        ControlAuxiliaryNormalBrush = getBrush(ThemeSlots.ControlAuxiliaryNormal);
        ControlAuxiliaryFocusedBrush = getBrush(ThemeSlots.ControlAuxiliaryFocused);
        ControlAuxiliaryPressedBrush = getBrush(ThemeSlots.ControlAuxiliaryPressed);
        ControlAuxiliaryEmphasisBrush = getBrush(ThemeSlots.ControlAuxiliaryEmphasis);
        ControlAuxiliaryDisabledBrush = getBrush(ThemeSlots.ControlAuxiliaryNormal);

        ControlBorderNormalBrush = getBrush(ThemeSlots.ControlBorderNormal);
        ControlBorderFocusedBrush = getBrush(ThemeSlots.ControlBorderFocused);
        ControlBorderPressedBrush = getBrush(ThemeSlots.ControlBorderPressed);
        ControlBorderEmphasisBrush = getBrush(ThemeSlots.ControlBorderEmphasis);
        ControlBorderDisabledBrush = getBrush(ThemeSlots.ControlBorderNormal);

        ControlForegroundNormalBrush = getBrush(ThemeSlots.ControlForegroundNormal);
        ControlForegroundFocusedBrush = getBrush(ThemeSlots.ControlForegroundFocused);
        ControlForegroundPressedBrush = getBrush(ThemeSlots.ControlForegroundPressed);
        ControlForegroundEmphasisBrush = getBrush(ThemeSlots.ControlForegroundEmphasis);
        ControlForegroundDisabledBrush = getBrush(ThemeSlots.ControlForegroundNormal);

        ControlTextNormalBrush = getBrush(ThemeSlots.ControlTextNormal);
        ControlTextFocusedBrush = getBrush(ThemeSlots.ControlTextFocused);
        ControlTextPressedBrush = getBrush(ThemeSlots.ControlTextPressed);
        ControlTextEmphasisBrush = getBrush(ThemeSlots.ControlTextEmphasis);
        ControlTextDisabledBrush = getBrush(ThemeSlots.ControlTextNormal);
    }

    // Update

    public static bool TryUpdateColor(ThemeSlots slot, Color newColor)
    {
        switch (slot)
        {
            // Background

            case ThemeSlots.ControlBackgroundNormal: ControlBackgroundNormalColor = newColor; break;
            case ThemeSlots.ControlBackgroundFocused: ControlBackgroundFocusedColor = newColor; break;
            case ThemeSlots.ControlBackgroundPressed: ControlBackgroundPressedColor = newColor; break;
            case ThemeSlots.ControlBackgroundEmphasis: ControlBackgroundEmphasisColor = newColor; break;
            case ThemeSlots.ControlBackgroundDisabled: ControlBackgroundDisabledColor = newColor; break;

            // Auxiliary

            case ThemeSlots.ControlAuxiliaryNormal: ControlAuxiliaryNormalColor = newColor; break;
            case ThemeSlots.ControlAuxiliaryFocused: ControlAuxiliaryFocusedColor = newColor; break;
            case ThemeSlots.ControlAuxiliaryPressed: ControlAuxiliaryPressedColor = newColor; break;
            case ThemeSlots.ControlAuxiliaryEmphasis: ControlAuxiliaryEmphasisColor = newColor; break;
            case ThemeSlots.ControlAuxiliaryDisabled: ControlAuxiliaryDisabledColor = newColor; break;

            // Borders

            case ThemeSlots.ControlBorderNormal: ControlBorderNormalColor = newColor; break;
            case ThemeSlots.ControlBorderFocused: ControlBorderFocusedColor = newColor; break;
            case ThemeSlots.ControlBorderPressed: ControlBorderPressedColor = newColor; break;
            case ThemeSlots.ControlBorderEmphasis: ControlBorderEmphasisColor = newColor; break;
            case ThemeSlots.ControlBorderDisabled: ControlBorderDisabledColor = newColor; break;

            // Foregrounds

            case ThemeSlots.ControlForegroundNormal: ControlForegroundNormalColor = newColor; break;
            case ThemeSlots.ControlForegroundFocused: ControlForegroundFocusedColor = newColor; break;
            case ThemeSlots.ControlForegroundPressed: ControlForegroundPressedColor = newColor; break;
            case ThemeSlots.ControlForegroundEmphasis: ControlForegroundEmphasisColor = newColor; break;
            case ThemeSlots.ControlForegroundDisabled: ControlForegroundDisabledColor = newColor; break;

            // Texts

            case ThemeSlots.ControlTextNormal: ControlTextNormalColor = newColor; break;
            case ThemeSlots.ControlTextFocused: ControlTextFocusedColor = newColor; break;
            case ThemeSlots.ControlTextPressed: ControlTextPressedColor = newColor; break;
            case ThemeSlots.ControlTextEmphasis: ControlTextEmphasisColor = newColor; break;
            case ThemeSlots.ControlTextDisabled: ControlTextDisabledColor = newColor; break;

            default:
                // On Fail
                return false;
        }

        // On Success
        return true;
    }

    public static bool TryUpdateBrush(ThemeSlots slot, Brush newBrush)
    {
        switch (slot)
        {
            // Background

            case ThemeSlots.ControlBackgroundNormal: ControlBackgroundNormalBrush = newBrush; break;
            case ThemeSlots.ControlBackgroundFocused: ControlBackgroundFocusedBrush = newBrush; break;
            case ThemeSlots.ControlBackgroundPressed: ControlBackgroundPressedBrush = newBrush; break;
            case ThemeSlots.ControlBackgroundEmphasis: ControlBackgroundEmphasisBrush = newBrush; break;
            case ThemeSlots.ControlBackgroundDisabled: ControlBackgroundDisabledBrush = newBrush; break;

            // Auxiliary

            case ThemeSlots.ControlAuxiliaryNormal: ControlAuxiliaryNormalBrush = newBrush; break;
            case ThemeSlots.ControlAuxiliaryFocused: ControlAuxiliaryFocusedBrush = newBrush; break;
            case ThemeSlots.ControlAuxiliaryPressed: ControlAuxiliaryPressedBrush = newBrush; break;
            case ThemeSlots.ControlAuxiliaryEmphasis: ControlAuxiliaryEmphasisBrush = newBrush; break;
            case ThemeSlots.ControlAuxiliaryDisabled: ControlAuxiliaryDisabledBrush = newBrush; break;

            // Borders

            case ThemeSlots.ControlBorderNormal: ControlBorderNormalBrush = newBrush; break;
            case ThemeSlots.ControlBorderFocused: ControlBorderFocusedBrush = newBrush; break;
            case ThemeSlots.ControlBorderPressed: ControlBorderPressedBrush = newBrush; break;
            case ThemeSlots.ControlBorderEmphasis: ControlBorderEmphasisBrush = newBrush; break;
            case ThemeSlots.ControlBorderDisabled: ControlBorderDisabledBrush = newBrush; break;

            // Foregrounds

            case ThemeSlots.ControlForegroundNormal: ControlForegroundNormalBrush = newBrush; break;
            case ThemeSlots.ControlForegroundFocused: ControlForegroundFocusedBrush = newBrush; break;
            case ThemeSlots.ControlForegroundPressed: ControlForegroundPressedBrush = newBrush; break;
            case ThemeSlots.ControlForegroundEmphasis: ControlForegroundEmphasisBrush = newBrush; break;
            case ThemeSlots.ControlForegroundDisabled: ControlForegroundDisabledBrush = newBrush; break;

            // Texts

            case ThemeSlots.ControlTextNormal: ControlTextNormalBrush = newBrush; break;
            case ThemeSlots.ControlTextFocused: ControlTextFocusedBrush = newBrush; break;
            case ThemeSlots.ControlTextPressed: ControlTextPressedBrush = newBrush; break;
            case ThemeSlots.ControlTextEmphasis: ControlTextEmphasisBrush = newBrush; break;
            case ThemeSlots.ControlTextDisabled: ControlTextDisabledBrush = newBrush; break;

            default:
                // On Fail
                return false;
        }

        // On Success
        return true;
    }
}