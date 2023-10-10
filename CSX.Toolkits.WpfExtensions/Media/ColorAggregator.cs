using CSX.Toolkits.CSharp.Mathematics;
using System.Numerics;
using SDColor = System.Drawing.Color;
using WMColor = System.Windows.Media.Color;

namespace CSX.Toolkits.WpfExtensions.Media;

public partial class ColorAggregator
{
    // Properties

    public double A { get; set; } = 0;
    public double R { get; set; } = 0;
    public double G { get; set; } = 0;
    public double B { get; set; } = 0;

    // Initialize

    public ColorAggregator()
    { }

    public ColorAggregator(SDColor color)
        => Add(color);

    public ColorAggregator(WMColor color)
        => Add(color);

    // Add

    public void Add(SDColor color)
    {
        A += color.A;
        R += color.R;
        G += color.G;
        B += color.B;
    }

    public void Add(WMColor color)
    {
        A += color.A;
        R += color.R;
        G += color.G;
        B += color.B;
    }

    //

    public Vector4 ToVector(int factor) => new(
        w: (float)A / factor,
        x: (float)R / factor,
        y: (float)G / factor,
        z: (float)B / factor);

    public WMColor ToMediaColor(int factor) => WMColor.FromArgb(
        a: (A / factor).ClampAsByte(),
        r: (R / factor).ClampAsByte(),
        g: (G / factor).ClampAsByte(),
        b: (B / factor).ClampAsByte());
}