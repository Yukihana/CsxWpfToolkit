using System;
using System.Windows.Media;

namespace CSX.Toolkits.WpfExtensions.ThemeEngine;

public class ThemeColorUpdatingEventArgs : EventArgs
{
    public ThemeSlots ThemeSlot { get; set; }
    public bool Cancel { get; set; } = false;
    public Color? OldValue { get; set; } = null;
    public Color? NewValue { get; set; } = null;

    public ThemeColorUpdatingEventArgs(ThemeSlots slot)
        => ThemeSlot = slot;
}