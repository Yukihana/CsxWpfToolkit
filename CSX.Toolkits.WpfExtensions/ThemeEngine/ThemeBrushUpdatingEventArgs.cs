using System;

namespace CSX.Toolkits.WpfExtensions.ThemeEngine;

public class ThemeBrushUpdatingEventArgs : EventArgs
{
    public ThemeSlots? ThemeSlot { get; set; } = null;

    public ThemeBrushUpdatingEventArgs(ThemeSlots slot)
        => ThemeSlot = slot;
}