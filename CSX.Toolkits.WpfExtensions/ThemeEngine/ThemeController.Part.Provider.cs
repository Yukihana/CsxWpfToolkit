using System;

namespace CSX.Toolkits.WpfExtensions.ThemeEngine;

public static partial class ThemeController
{
    private static IThemeProvider _provider;
    private static IThemeProvider Provider => _provider;

    public static event EventHandler<PropertyUpdatingEventArgs<IThemeProvider>>? ProviderChanging;

    public static event EventHandler<PropertyUpdatedEventArgs<IThemeProvider>>? ProviderChanged;

    public static void SetProvider(IThemeProvider provider)
    {
        var old = _provider;

        // Allow cancelling
        PropertyUpdatingEventArgs<IThemeProvider> changing = new()
        {
            PropertyName = nameof(Provider),
            OldValue = old,
            NewValue = provider,
        };
        ProviderChanging?.Invoke(null, changing);
        if (changing.Cancel)
            return;

        // The actual change
        DetachProvider();
        _provider = provider;
        AttachProvider();

        // Set up resources from the new provider
        InitializeProvider();

        // Trigger completed event
        PropertyUpdatedEventArgs<IThemeProvider> changed = new()
        {
            PropertyName = nameof(Provider),
            OldValue = old,
            NewValue = provider,
        };
        ProviderChanged?.Invoke(null, changed);
    }

    // Attach, Detach

    private static void AttachProvider()
    {
        _provider.OnAttaching();
        _provider.ColorUpdatedCallback = OnRequestColorUpdate;
        _provider.BrushUpdatedCallback = OnRequestBrushUpdate;
        _provider.OnAttached();
    }

    private static void DetachProvider()
    {
        _provider.OnDetaching();
        _provider.ColorUpdatedCallback = null;
        _provider.BrushUpdatedCallback = null;
        _provider.OnDetached();
    }
}