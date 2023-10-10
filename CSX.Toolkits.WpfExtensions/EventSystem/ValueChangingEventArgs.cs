using System;

namespace CSX.Toolkits.WpfExtensions.EventSystem;

public class ValueChangingEventArgs<T> : EventArgs
{
    public ValueChangingEventArgs()
    { }

    public ValueChangingEventArgs(string propertyName, T oldValue, T newValue)
    {
        PropertyName = propertyName;
        OldValue = oldValue;
        NewValue = newValue;
    }

    public string? PropertyName { get; set; } = default;
    public bool Cancel { get; set; } = false;
    public T? OldValue { get; set; } = default;
    public T? NewValue { get; set; } = default;
}