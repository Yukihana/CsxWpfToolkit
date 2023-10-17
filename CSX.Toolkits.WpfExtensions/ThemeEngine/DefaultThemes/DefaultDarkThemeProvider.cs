using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;

namespace CSX.Toolkits.WpfExtensions.ThemeEngine.DefaultThemes;

public partial class DefaultDarkThemeProvider : IThemeProvider
{
    public Action<IThemeProvider, ThemeSlots>? ColorUpdatedCallback { get; set; } = null;
    public Action<IThemeProvider, ThemeSlots>? BrushUpdatedCallback { get; set; } = null;

    public void OnAttaching()
    { }

    public void OnAttached()
    { }

    public void OnDetaching()
    { }

    public void OnDetached()
    { }

    public bool TryGetColor(ThemeSlots slot, out Color color)
        => _colors.TryGetValue(slot, out color);

    public bool TryGetBrush(ThemeSlots slot, [NotNullWhen(true)] out Brush? brush)
    {
        // Attempts to retrieve the ThemeBrush for this slot.
        if (_brushes.TryGetValue(slot, out brush) && brush is not null)
            return true;

        // On fail, attempts to generate a brush based on the color.
        if (_colors.TryGetValue(slot, out Color color))
        {
            brush = color.GenerateSolidColorBrush();
            return true;
        }

        return false;
    }
}