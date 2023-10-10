using Microsoft.Extensions.Logging;

namespace CSX.Toolkits.WpfExtensions;

public static class ServicesHost
{
    // Logger

    private static ILogger? _logService = null;
    public static ILogger? LogService => _logService;

    public static void SetLogService(ILogger? logService)
        => _logService = logService;
}