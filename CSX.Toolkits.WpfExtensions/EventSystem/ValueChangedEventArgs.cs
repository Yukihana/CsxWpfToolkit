using System;

namespace CSX.Toolkits.WpfExtensions.EventSystem;

public class ValueChangedEventArgs<T> : EventArgs
{
    public ValueChangedEventArgs()
    { }

    public ValueChangedEventArgs(string propertyName, T oldValue, T newValue)
    {
        PropertyName = propertyName;
        OldValue = oldValue;
        NewValue = newValue;
    }

    public string? PropertyName { get; set; } = default;
    public T? OldValue { get; set; } = default;
    public T? NewValue { get; set; } = default;
}