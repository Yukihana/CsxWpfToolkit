using CSX.Toolkits.WpfExtensions.EventSystem;
using System;
using System.Windows;

namespace CSX.Toolkits.WpfExtensions.Controls;

public partial class Button : System.Windows.Controls.Button
{
    // Override metadata so it targets styles meant for this type
    static Button()
        => DefaultStyleKeyProperty.OverrideMetadata(
            forType: typeof(Button),
            typeMetadata: new FrameworkPropertyMetadata(typeof(Button)));

    public Button()
        => SetResourceReference(StyleProperty, typeof(Button));

    // CornerRadius

    public static CornerRadius DefaultCornerRadius => new(3);

    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            name: nameof(CornerRadius),
            propertyType: typeof(CornerRadius),
            ownerType: typeof(Button),
            typeMetadata: new PropertyMetadata(DefaultCornerRadius, CornerRadiusChanged));

    public CornerRadius CornerRadius
    {
        get { return (CornerRadius)GetValue(CornerRadiusProperty); }
        set { SetValue(CornerRadiusProperty, value); }
    }

    public event EventHandler<ValueChangedEventArgs<CornerRadius>>? OnCornerRadiusChanged;

    private static void CornerRadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ValueChangedEventArgs<CornerRadius> args = new(
            propertyName: nameof(CornerRadius),
            oldValue: (CornerRadius)e.OldValue,
            newValue: (CornerRadius)e.NewValue);

        if (d is Button button)
            button.OnCornerRadiusChanged?.Invoke(d, args);
    }
}