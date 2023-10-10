using System.Windows.Media;

namespace CSX.Toolkits.WpfExtensions.Media;

public static partial class ColorExtensions
{
    public static Color AsColor(this byte value, byte alpha = 255)
        => Color.FromArgb(alpha, value, value, value);
}