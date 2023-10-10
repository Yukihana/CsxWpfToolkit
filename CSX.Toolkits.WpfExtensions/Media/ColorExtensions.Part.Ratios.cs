using System.Windows.Media;

namespace CSX.Toolkits.WpfExtensions.Media;

public static partial class ColorExtensions
{
    public static Color MixInProportions(Color color1, Color color2, float ratio = 0.5f)
        => color1 * ratio + color2 * (1 - ratio);

    public static Color Flatten(this Color color) => Color.FromArgb(
        a: byte.MaxValue,
        r: color.R,
        g: color.G,
        b: color.B);
}