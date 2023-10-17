using System;
using System.Runtime.InteropServices;

namespace CSX.Toolkits.WpfExtensions.Interop;

public static partial class ThemeInterop
{
    private const uint SPI_GETPENVISUALSTYLE = 0x0014;

    [LibraryImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool SystemParametersInfo(uint uiAction, uint uiParam, out uint pvParam, uint fWinIni);

    public static bool IsDarkModeEnabled()
    {
        if (SystemParametersInfo(SPI_GETPENVISUALSTYLE, 0, out uint value, 0))
        {
            // Dark mode is enabled if the value is 1.
            return value == 1;
        }

        // If the function call fails, you can handle the error accordingly.
        throw new InvalidOperationException("Failed to detect system theme.");
    }
}