namespace CSX.Toolkits.WpfExtensions.ThemeEngine;

public class PropertyUpdatedEventArgs<T>
{
    public string? PropertyName { get; set; } = default;
    public T? OldValue { get; set; } = default;
    public T? NewValue { get; set; } = default;
}