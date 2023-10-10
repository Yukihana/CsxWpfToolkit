using CSX.Toolkits.WpfExtensions.ThemeEngine.DefaultTheme;
using System.Windows;

namespace CSX.Toolkits.WpfExtensions.ThemeEngine;

public static partial class ThemeComponents
{
    // Dictionary

    private static readonly ThemeComponentsDictionary _resourceDictionary = new();
    public static ResourceDictionary ResourceDictionary => _resourceDictionary;

    // Provider

    private static IThemeProvider _provider = new DefaultThemeProvider();
    private static IThemeProvider Provider => _provider;

    // Init

    static ThemeComponents()
    {
        Application.Current.Resources.MergedDictionaries.Add(ResourceDictionary);
        InitializeProvider();
    }

    // Setup

    private static void InitializeProvider()
    {
        ResetProviderErrors();
        AssignComponents();
        PostDebugStats();
    }

    private static void AssignComponents()
    {
        AssignControlTheme();
        //AssignPanelTheme();
        //AssignWorkspaceTheme();
        //AssignChromeTheme();
        //AssignMenuTheme();
        //AssignTooltipTheme();
        //AssignMiscTheme();
    }
}