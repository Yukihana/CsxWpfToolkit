using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CSX.Toolkits.WpfExtensions.ThemeEngine;

public static partial class ThemeController
{
    private static ulong _totalErrorCount = 0;
    private static ulong _providerErrorCount = 0;

    private static void PostDebugStats()
        => Debug.WriteLine($"Provider errors: {_providerErrorCount}. Total errors: {_totalErrorCount}.");

    private static void AddError()
    {
        _providerErrorCount++;
        _totalErrorCount++;
    }

    private static void ResetProviderErrors()
        => _providerErrorCount = 0;

    // Warnings
    private static void WarnColorMissing(ThemeSlots slot)
    {
        AddError();
        if (ServicesHost.LogService is ILogger logger)
            logger.LogWarning("Failed to get the {slot} color slot from provider {type}.", slot, Provider.GetType());
        else
            Debug.WriteLine($"Failed to get the {slot} color slot from provider {Provider.GetType()}.");
    }

    private static void WarnBrushMissing(ThemeSlots slot)
    {
        AddError();
        if (ServicesHost.LogService is ILogger logger)
            logger.LogWarning("Failed to get the {slot} color slot from provider {type}.", slot, Provider.GetType());
        else
            Debug.WriteLine($"Failed to get the {slot} brush slot from provider {Provider.GetType()}.");
    }

    private static void WarnColorUpdateFailed(ThemeSlots slot)
    {
        AddError();
        if (ServicesHost.LogService is ILogger logger)
            logger.LogWarning("Failed to update the color for the slot: {slot}.", slot);
        else
            Debug.WriteLine($"Failed to update the color for the slot: {slot}");
    }

    private static void WarnBrushUpdateFailed(ThemeSlots slot)
    {
        AddError();
        if (ServicesHost.LogService is ILogger logger)
            logger.LogWarning("Failed to update the brush for the slot: {slot}.", slot);
        else
            Debug.WriteLine($"Failed to update the brush for the slot: {slot}.");
    }
}