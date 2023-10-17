using CSX.Toolkits.WpfExtensions.ThemeEngine.DefaultThemes;

namespace CSX.Toolkits.WpfExtensions.ThemeEngine;

public static partial class ThemeController
{
    static ThemeController()
    {
        _provider = GetStartupProvider();
        InitializeProvider();
    }

    private static IThemeProvider GetStartupProvider()
    {
        // check if user specified provider is available from settings.

        // Otherwise determine based on system theme.
        /*
        return ThemeInterop.IsDarkModeEnabled()
            ? new DefaultDarkThemeProvider()
            : new DefaultLightThemeProvider();
        */

        return new DefaultLightThemeProvider();
    }

    // Setup provider (Also called from the provider setter)

    private static void InitializeProvider()
    {
        ResetProviderErrors();
        AssignComponents();
        PostDebugStats();
    }

    private static void AssignComponents()
    {
        ControlComponents.AssignColors(GetColor);
        ControlComponents.AssignBrushes(GetBrush);
        //AssignPanelTheme();
        //AssignWorkspaceTheme();
        //AssignChromeTheme();
        //AssignMenuTheme();
        //AssignTooltipTheme();
        //AssignMiscTheme();
    }
}