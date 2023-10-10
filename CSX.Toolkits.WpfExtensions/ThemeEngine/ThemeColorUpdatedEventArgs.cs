using System;

namespace CSX.Toolkits.WpfExtensions.ThemeEngine;

public class ThemeColorUpdatedEventArgs : EventArgs
{
    public ThemeSlots ThemeSlot { get; set; }

    public ThemeColorUpdatedEventArgs(ThemeSlots slot)
        => ThemeSlot = slot;
}