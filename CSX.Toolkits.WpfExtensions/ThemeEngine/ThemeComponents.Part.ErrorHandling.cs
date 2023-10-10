using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CSX.Toolkits.WpfExtensions.ThemeEngine;

public static partial class ThemeComponents
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
        if (Logging.LogService is ILogger logger)
            logger.LogWarning("Failed to get the {slot} color slot from provider {type}.", slot, Provider.GetType());
        else
            Debug.WriteLine($"Failed to get the {slot} color slot from provider {Provider.GetType()}.");
    }

    private static void WarnBrushMissing(ThemeSlots slot)
    {
        AddError();
        if (Logging.LogService is ILogger logger)
            logger.LogWarning("Failed to get the {slot} color slot from provider {type}.", slot, Provider.GetType());
        else
            Debug.WriteLine($"Failed to get the {slot} brush slot from provider {Provider.GetType()}.");
    }

    private static void WarnKeyMissing(string keyName)
    {
        AddError();
        if (Logging.LogService is ILogger logger)
            logger.LogWarning("No such theme key field designation: {keyName}", keyName);
        else
            Debug.WriteLine($"No such theme key field designation: {keyName}.");
    }
}