using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace CSX.Toolkits.WpfExtensions.Controls;

[TemplatePart(Name = "PART_TextBox", Type = typeof(TextBox))]
[TemplatePart(Name = "PART_IncreaseButton", Type = typeof(RepeatButton))]
[TemplatePart(Name = "PART_DecreaseButton", Type = typeof(RepeatButton))]
public class NumericUpDown : Control
{
    // Constructor and Prerequisites

    static NumericUpDown() => DefaultStyleKeyProperty.OverrideMetadata(
        forType: typeof(NumericUpDown),
        typeMetadata: new FrameworkPropertyMetadata(typeof(NumericUpDown)));

    public NumericUpDown()
    {
        Culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
        Culture.NumberFormat.NumberDecimalDigits = DecimalPlaces;

        Loaded += OnLoaded;
    }

    protected readonly CultureInfo Culture;

    // Initialize: Visual Tree

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        AttachToVisualTree();
        AttachCommands();
    }

    private void AttachToVisualTree()
    {
        AttachTextBox();
        AttachIncreaseButton();
        AttachDecreaseButton();
    }

    private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        => InvalidateProperty(ValueProperty);

    // VisualTree: Commands

    private readonly RoutedUICommand _minorIncreaseValueCommand = new("MinorIncreaseValue", "MinorIncreaseValue", typeof(NumericUpDown));
    private readonly RoutedUICommand _minorDecreaseValueCommand = new("MinorDecreaseValue", "MinorDecreaseValue", typeof(NumericUpDown));
    private readonly RoutedUICommand _majorIncreaseValueCommand = new("MajorIncreaseValue", "MajorIncreaseValue", typeof(NumericUpDown));
    private readonly RoutedUICommand _majorDecreaseValueCommand = new("MajorDecreaseValue", "MajorDecreaseValue", typeof(NumericUpDown));
    private readonly RoutedUICommand _updateValueStringCommand = new("UpdateValueString", "UpdateValueString", typeof(NumericUpDown));
    private readonly RoutedUICommand _cancelChangesCommand = new("CancelChanges", "CancelChanges", typeof(NumericUpDown));

    private void AttachCommands()
    {
        CommandBindings.Add(new CommandBinding(_minorIncreaseValueCommand, (a, b) => IncreaseValue(true)));
        CommandBindings.Add(new CommandBinding(_minorDecreaseValueCommand, (a, b) => DecreaseValue(true)));
        CommandBindings.Add(new CommandBinding(_majorIncreaseValueCommand, (a, b) => IncreaseValue(false)));
        CommandBindings.Add(new CommandBinding(_majorDecreaseValueCommand, (a, b) => DecreaseValue(false)));
        CommandBindings.Add(new CommandBinding(_updateValueStringCommand, (a, b) => Value = TextBox is not null ? ParseStringToDecimal(TextBox.Text) : 0));
        CommandBindings.Add(new CommandBinding(_cancelChangesCommand, (a, b) => CancelChanges()));

        CommandManager.RegisterClassInputBinding(typeof(TextBox), new KeyBinding(_minorIncreaseValueCommand, new KeyGesture(Key.Up)));
        CommandManager.RegisterClassInputBinding(typeof(TextBox), new KeyBinding(_minorDecreaseValueCommand, new KeyGesture(Key.Down)));
        CommandManager.RegisterClassInputBinding(typeof(TextBox), new KeyBinding(_majorIncreaseValueCommand, new KeyGesture(Key.PageUp)));
        CommandManager.RegisterClassInputBinding(typeof(TextBox), new KeyBinding(_majorDecreaseValueCommand, new KeyGesture(Key.PageDown)));
        CommandManager.RegisterClassInputBinding(typeof(TextBox), new KeyBinding(_updateValueStringCommand, new KeyGesture(Key.Enter)));
        CommandManager.RegisterClassInputBinding(typeof(TextBox), new KeyBinding(_cancelChangesCommand, new KeyGesture(Key.Escape)));

        /*
        //Incase multiple of these controls on the same page conflict with Up/Down buttons

        TextBox.InputBindings.Add(new KeyBinding(_minorIncreaseValueCommand, new KeyGesture(Key.Up)));
        TextBox.InputBindings.Add(new KeyBinding(_minorDecreaseValueCommand, new KeyGesture(Key.Down)));
        */
    }

    // VisualTree

    protected TextBox? TextBox = null;
    protected RepeatButton? IncreaseButton = null;
    protected RepeatButton? DecreaseButton = null;

    private void AttachTextBox()
    {
        if (GetTemplateChild("PART_TextBox") is TextBox textBox)
        {
            TextBox = textBox;
            TextBox.LostFocus += TextBoxOnLostFocus;
            TextBox.PreviewMouseLeftButtonUp += TextBoxOnPreviewMouseLeftButtonUp;

            TextBox.UndoLimit = 1;
            TextBox.IsUndoEnabled = true;
        }
    }

    private void AttachIncreaseButton()
    {
        if (GetTemplateChild("PART_IncreaseButton") is RepeatButton increaseButton)
        {
            IncreaseButton = increaseButton;
            IncreaseButton.Focusable = false;
            IncreaseButton.Command = _minorIncreaseValueCommand;
            IncreaseButton.PreviewMouseRightButtonDown += ButtonOnPreviewMouseRightButtonDown;
            IncreaseButton.PreviewMouseLeftButtonDown += (sender, args) => RemoveFocus();
        }
    }

    private void AttachDecreaseButton()
    {
        if (GetTemplateChild("PART_DecreaseButton") is RepeatButton decreaseButton)
        {
            DecreaseButton = decreaseButton;
            DecreaseButton.Focusable = false;
            DecreaseButton.Command = _minorDecreaseValueCommand;
            DecreaseButton.PreviewMouseRightButtonDown += ButtonOnPreviewMouseRightButtonDown;
            DecreaseButton.PreviewMouseLeftButtonDown += (sender, args) => RemoveFocus();
        }
    }

    // Property: Value

    public static readonly DependencyProperty ValueProperty
        = DependencyProperty.Register("Value", typeof(decimal), typeof(NumericUpDown), new PropertyMetadata(0m, OnValueChanged, CoerceValue));

    public decimal Value
    {
        get { return (decimal)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value); }
    }

    private static void OnValueChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
    {
        var control = (NumericUpDown)element;

        if (control.TextBox != null)
        {
            control.TextBox.UndoLimit = 0;
            control.TextBox.UndoLimit = 1;
        }
    }

    private static object CoerceValue(DependencyObject element, object baseValue)
    {
        var control = (NumericUpDown)element;
        var value = (decimal)baseValue;

        control.CoerceValueToBounds(ref value);

        // Get the text representation of Value
        var valueString = value.ToString(control.Culture);

        // Count all decimal places
        var decimalPlaces = control.GetDecimalPlacesCount(valueString);

        if (decimalPlaces > control.DecimalPlaces)
        {
            if (control.IsDecimalPointDynamic)
            {
                // Assigning DecimalPlaces will coerce the number
                control.DecimalPlaces = decimalPlaces;

                // If the specified number of decimal places is still too much
                if (decimalPlaces > control.DecimalPlaces)
                    value = control.TruncateValue(valueString, control.DecimalPlaces);
            }
            else
            {
                // Remove all overflowing decimal places
                value = control.TruncateValue(valueString, decimalPlaces);
            }
        }
        else if (control.IsDecimalPointDynamic)
        {
            control.DecimalPlaces = decimalPlaces;
        }

        // Change formatting based on this flag
        if (control.IsThousandSeparatorVisible)
        {
            if (control.TextBox != null)
                control.TextBox.Text = value.ToString("N", control.Culture);
        }
        else
        {
            if (control.TextBox != null)
                control.TextBox.Text = value.ToString("F", control.Culture);
        }

        return value;
    }

    // Property: MaxValue

    public static readonly DependencyProperty MaxValueProperty =
        DependencyProperty.Register("MaxValue", typeof(decimal), typeof(NumericUpDown), new PropertyMetadata(1000000000m, OnMaxValueChanged, CoerceMaxValue));

    public decimal MaxValue
    {
        get { return (decimal)GetValue(MaxValueProperty); }
        set { SetValue(MaxValueProperty, value); }
    }

    private static void OnMaxValueChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
    {
        var control = (NumericUpDown)element;
        var maxValue = (decimal)e.NewValue;

        // If maxValue steps over MinValue, shift it
        if (maxValue < control.MinValue)
            control.MinValue = maxValue;

        if (maxValue <= control.Value)
            control.Value = maxValue;
    }

    private static object CoerceMaxValue(DependencyObject element, object baseValue)
    {
        var maxValue = (decimal)baseValue;
        return maxValue;
    }

    // Property: MinValue

    public static readonly DependencyProperty MinValueProperty =
        DependencyProperty.Register("MinValue", typeof(decimal), typeof(NumericUpDown), new PropertyMetadata(0m, OnMinValueChanged, CoerceMinValue));

    public decimal MinValue
    {
        get { return (decimal)GetValue(MinValueProperty); }
        set { SetValue(MinValueProperty, value); }
    }

    private static void OnMinValueChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
    {
        var control = (NumericUpDown)element;
        var minValue = (decimal)e.NewValue;

        // If minValue steps over MaxValue, shift it
        if (minValue > control.MaxValue)
            control.MaxValue = minValue;

        if (minValue >= control.Value)
            control.Value = minValue;
    }

    private static object CoerceMinValue(DependencyObject element, object baseValue)
    {
        var minValue = (decimal)baseValue;
        return minValue;
    }

    // Property: DecimalPlaces

    public static readonly DependencyProperty DecimalPlacesProperty
        = DependencyProperty.Register("DecimalPlaces", typeof(int), typeof(NumericUpDown), new PropertyMetadata(0, OnDecimalPlacesChanged, CoerceDecimalPlaces));

    public int DecimalPlaces
    {
        get { return (int)GetValue(DecimalPlacesProperty); }
        set { SetValue(DecimalPlacesProperty, value); }
    }

    private static void OnDecimalPlacesChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
    {
        var control = (NumericUpDown)element;
        var decimalPlaces = (int)e.NewValue;

        control.Culture.NumberFormat.NumberDecimalDigits = decimalPlaces;

        if (control.IsDecimalPointDynamic)
        {
            control.IsDecimalPointDynamic = false;
            control.InvalidateProperty(ValueProperty);
            control.IsDecimalPointDynamic = true;
        }
        else
            control.InvalidateProperty(ValueProperty);
    }

    private static object CoerceDecimalPlaces(DependencyObject element, object baseValue)
    {
        var decimalPlaces = (int)baseValue;
        var control = (NumericUpDown)element;

        if (decimalPlaces < control.MinDecimalPlaces)
            decimalPlaces = control.MinDecimalPlaces;
        else if (decimalPlaces > control.MaxDecimalPlaces)
            decimalPlaces = control.MaxDecimalPlaces;

        return decimalPlaces;
    }

    // Property: MaxDecimalPlaces

    public static readonly DependencyProperty MaxDecimalPlacesProperty =
        DependencyProperty.Register("MaxDecimalPlaces", typeof(int), typeof(NumericUpDown), new PropertyMetadata(28, OnMaxDecimalPlacesChanged, CoerceMaxDecimalPlaces));

    public int MaxDecimalPlaces
    {
        get { return (int)GetValue(MaxDecimalPlacesProperty); }
        set { SetValue(MaxDecimalPlacesProperty, value); }
    }

    private static void OnMaxDecimalPlacesChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
    {
        var control = (NumericUpDown)element;

        control.InvalidateProperty(DecimalPlacesProperty);
    }

    private static object CoerceMaxDecimalPlaces(DependencyObject element, object baseValue)
    {
        var maxDecimalPlaces = (int)baseValue;
        var control = (NumericUpDown)element;

        if (maxDecimalPlaces > 28)
            maxDecimalPlaces = 28;
        else if (maxDecimalPlaces < 0)
            maxDecimalPlaces = 0;
        else if (maxDecimalPlaces < control.MinDecimalPlaces)
            control.MinDecimalPlaces = maxDecimalPlaces;

        return maxDecimalPlaces;
    }

    // Property: MinDecimalPlaces

    public static readonly DependencyProperty MinDecimalPlacesProperty =
        DependencyProperty.Register("MinDecimalPlaces", typeof(int), typeof(NumericUpDown), new PropertyMetadata(0, OnMinDecimalPlacesChanged, CoerceMinDecimalPlaces));

    public int MinDecimalPlaces
    {
        get { return (int)GetValue(MinDecimalPlacesProperty); }
        set { SetValue(MinDecimalPlacesProperty, value); }
    }

    private static void OnMinDecimalPlacesChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
    {
        var control = (NumericUpDown)element;

        control.InvalidateProperty(DecimalPlacesProperty);
    }

    private static object CoerceMinDecimalPlaces(DependencyObject element, object baseValue)
    {
        var minDecimalPlaces = (int)baseValue;
        var control = (NumericUpDown)element;

        if (minDecimalPlaces < 0)
            minDecimalPlaces = 0;
        else if (minDecimalPlaces > 28)
            minDecimalPlaces = 28;
        else if (minDecimalPlaces > control.MaxDecimalPlaces)
            control.MaxDecimalPlaces = minDecimalPlaces;

        return minDecimalPlaces;
    }

    // Property: IsDecimalPointDynamic

    public static readonly DependencyProperty IsDecimalPointDynamicProperty
        = DependencyProperty.Register("IsDecimalPointDynamic", typeof(bool), typeof(NumericUpDown), new PropertyMetadata(false));

    public bool IsDecimalPointDynamic
    {
        get { return (bool)GetValue(IsDecimalPointDynamicProperty); }
        set { SetValue(IsDecimalPointDynamicProperty, value); }
    }

    // Property: IsThousandSeparatorVisible

    public static readonly DependencyProperty IsThousandSeparatorVisibleProperty
        = DependencyProperty.Register("IsThousandSeparatorVisible", typeof(bool), typeof(NumericUpDown), new PropertyMetadata(false, OnIsThousandSeparatorVisibleChanged));

    public bool IsThousandSeparatorVisible
    {
        get { return (bool)GetValue(IsThousandSeparatorVisibleProperty); }
        set { SetValue(IsThousandSeparatorVisibleProperty, value); }
    }

    private static void OnIsThousandSeparatorVisibleChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
        => ((NumericUpDown)element).InvalidateProperty(ValueProperty);

    // Property: MinorDelta

    public static readonly DependencyProperty MinorDeltaProperty =
        DependencyProperty.Register("MinorDelta", typeof(decimal), typeof(NumericUpDown), new PropertyMetadata(1m, OnMinorDeltaChanged, CoerceMinorDelta));

    public decimal MinorDelta
    {
        get { return (decimal)GetValue(MinorDeltaProperty); }
        set { SetValue(MinorDeltaProperty, value); }
    }

    private static void OnMinorDeltaChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
    {
        var minorDelta = (decimal)e.NewValue;
        var control = (NumericUpDown)element;

        if (minorDelta > control.MajorDelta)
            control.MajorDelta = minorDelta;
    }

    private static object CoerceMinorDelta(DependencyObject element, object baseValue)
    {
        var minorDelta = (decimal)baseValue;

        return minorDelta;
    }

    // Property: MajorDelta

    public static readonly DependencyProperty MajorDeltaProperty =
        DependencyProperty.Register("MajorDelta", typeof(decimal), typeof(NumericUpDown), new PropertyMetadata(10m, OnMajorDeltaChanged, CoerceMajorDelta));

    public decimal MajorDelta
    {
        get { return (decimal)GetValue(MajorDeltaProperty); }
        set { SetValue(MajorDeltaProperty, value); }
    }

    private static void OnMajorDeltaChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
    {
        var majorDelta = (decimal)e.NewValue;
        var control = (NumericUpDown)element;

        if (majorDelta < control.MinorDelta)
            control.MinorDelta = majorDelta;
    }

    private static object CoerceMajorDelta(DependencyObject element, object baseValue)
    {
        var majorDelta = (decimal)baseValue;

        return majorDelta;
    }

    // Property: IsAutoSelectionActive

    public static readonly DependencyProperty IsAutoSelectionActiveProperty
        = DependencyProperty.Register("IsAutoSelectionActive", typeof(bool), typeof(NumericUpDown), new PropertyMetadata(false));

    public bool IsAutoSelectionActive
    {
        get { return (bool)GetValue(IsAutoSelectionActiveProperty); }
        set { SetValue(IsAutoSelectionActiveProperty, value); }
    }

    // Property: IsValueWrapAllowed

    public static readonly DependencyProperty IsValueWrapAllowedProperty =
        DependencyProperty.Register("IsValueWrapAllowed", typeof(bool), typeof(NumericUpDown), new PropertyMetadata(false));

    public bool IsValueWrapAllowed
    {
        get { return (bool)GetValue(IsValueWrapAllowedProperty); }
        set { SetValue(IsValueWrapAllowedProperty, value); }
    }

    // Functionality

    private void IncreaseValue(bool minor)
    {
        if (TextBox is null)
            return;

        // Get the value that's currently in the TextBox.Text
        var value = ParseStringToDecimal(TextBox.Text);

        // Coerce the value to min/max
        CoerceValueToBounds(ref value);

        // Only change the value if it has any meaning
        if (value <= MaxValue)
        {
            if (minor)
            {
                if (IsValueWrapAllowed && value + MinorDelta > MaxValue)
                    value = MinValue;
                else
                    value += MinorDelta;
            }
            else
            {
                if (IsValueWrapAllowed && value + MajorDelta > MaxValue)
                {
                    value = MinValue;
                }
                else
                {
                    value += MajorDelta;
                }
            }
        }

        Value = value;
    }

    private void DecreaseValue(bool minor)
    {
        if (TextBox is null)
            return;

        // Get the value that's currently in the TextBox.Text
        var value = ParseStringToDecimal(TextBox.Text);

        // Coerce the value to min/max
        CoerceValueToBounds(ref value);

        // Only change the value if it has any meaning
        if (value >= MinValue)
        {
            if (minor)
            {
                if (IsValueWrapAllowed && value - MinorDelta < MinValue)
                    value = MaxValue;
                else
                    value -= MinorDelta;
            }
            else
            {
                if (IsValueWrapAllowed && value - MajorDelta < MinValue)
                    value = MaxValue;
                else
                    value -= MajorDelta;
            }
        }

        Value = value;
    }

    private void CoerceValueToBounds(ref decimal value)
    {
        if (value < MinValue)
            value = MinValue;
        else if (value > MaxValue)
            value = MaxValue;
    }

    // Backend: Visual Assist

    private void TextBoxOnLostFocus(object sender, RoutedEventArgs routedEventArgs)
    {
        if (TextBox is null)
            return;

        Value = ParseStringToDecimal(TextBox.Text);
    }

    private void ButtonOnPreviewMouseRightButtonDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        => Value = 0;

    private void TextBoxOnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
    {
        if (TextBox is null)
            return;

        if (IsAutoSelectionActive)
            TextBox.SelectAll();
    }

    private void RemoveFocus()
    {
        // Passes focus here and then just deletes it
        Focusable = true;
        Focus();
        Focusable = false;
    }

    private void CancelChanges()
    {
        if (TextBox is null)
            return;

        TextBox.Undo();
    }

    // Data validations and checks

    private static decimal ParseStringToDecimal(string source)
    {
        _ = decimal.TryParse(source, out decimal value);
        return value;
    }

    public int GetDecimalPlacesCount(string valueString)
    {
        int count = 0;
        bool found = false;
        foreach (char c in valueString)
        {
            if (found)
                count++;
            else if (c.ToString(Culture) == Culture.NumberFormat.NumberDecimalSeparator)
                found = true;
        }
        return count;
    }

    private decimal TruncateValue(string valueString, int decimalPlaces)
    {
        var endPoint = valueString.Length - (decimalPlaces - DecimalPlaces);
        var tempValueString = valueString[..endPoint];

        return decimal.Parse(tempValueString, Culture);
    }
}