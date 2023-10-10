using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;

namespace CSX.Toolkits.WpfExtensions.ThemeEngine;

/// <summary>
/// The base contract for a theme provider.
/// To use a minimal existing implementation as base class, use <see cref="ThemeProvider"/> instead.
/// </summary>
public interface IThemeProvider
{
    // Attach

    void OnAttaching();

    void OnAttached();

    // Detach

    void OnDetaching();

    void OnDetached();

    // Update callbacks

    Action<IThemeProvider, ThemeSlots>? ColorUpdatedCallback { get; set; }
    Action<IThemeProvider, ThemeSlots>? BrushUpdatedCallback { get; set; }

    // Required

    bool TryGetColor(ThemeSlots slot, out Color color);

    bool TryGetBrush(ThemeSlots slot, [NotNullWhen(true)] out Brush? brush);
}