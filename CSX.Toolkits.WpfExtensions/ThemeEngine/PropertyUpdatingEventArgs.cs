namespace CSX.Toolkits.WpfExtensions.ThemeEngine;

public class PropertyUpdatingEventArgs<T>
{
    public bool Cancel { get; set; } = false;
    public string? PropertyName { get; set; } = default;
    public T? OldValue { get; set; } = default;
    public T? NewValue { get; set; } = default;
}