using CSX.Toolkits.DotNet.Mathematics;
using System.Numerics;
using SDColor = System.Drawing.Color;
using WMColor = System.Windows.Media.Color;

namespace CSX.Toolkits.WpfExtensions.Media;

public static partial class ColorExtensions
{
    // To media color

    public static WMColor ToMediaColor(this SDColor color) => WMColor.FromArgb(
        a: color.A,
        r: color.R,
        g: color.G,
        b: color.B);

    public static WMColor ToMediaColor(this Vector4 aggregator) => WMColor.FromArgb(
        a: aggregator.W.ClampAsByte(),
        r: aggregator.X.ClampAsByte(),
        g: aggregator.Y.ClampAsByte(),
        b: aggregator.Z.ClampAsByte());

    // To drawing color

    public static WMColor ToDrawingColor(this SDColor color) => WMColor.FromArgb(
        a: color.A,
        r: color.R,
        g: color.G,
        b: color.B);

    public static SDColor ToDrawingColor(this Vector4 aggregator) => SDColor.FromArgb(
        alpha: aggregator.W.ClampAsByte(),
        red: aggregator.X.ClampAsByte(),
        green: aggregator.Y.ClampAsByte(),
        blue: aggregator.Z.ClampAsByte());
}