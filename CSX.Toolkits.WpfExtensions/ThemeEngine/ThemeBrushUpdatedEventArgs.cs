using System;

namespace CSX.Toolkits.WpfExtensions.ThemeEngine;

public class ThemeBrushUpdatedEventArgs : EventArgs
{
    public ThemeSlots ThemeSlot { get; set; }

    public ThemeBrushUpdatedEventArgs(ThemeSlots slot)
        => ThemeSlot = slot;
}