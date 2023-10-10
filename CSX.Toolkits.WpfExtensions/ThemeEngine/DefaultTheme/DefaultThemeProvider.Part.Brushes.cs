using System.Collections.Generic;
using System.Windows.Media;

namespace CSX.Toolkits.WpfExtensions.ThemeEngine.DefaultTheme;

public partial class DefaultThemeProvider
{
    private readonly Dictionary<ThemeSlots, Brush> _brushes = new()
    {
    };
}