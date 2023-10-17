namespace CSX.Toolkits.WpfExtensions.ThemeEngine;

/// <summary>
/// Theme visual component identifiers.
/// Enum slots to improve performance over string identifiers.
/// </summary>
public enum ThemeSlots
{
    // Control

    ControlBackgroundNormal,
    ControlBackgroundFocused,
    ControlBackgroundPressed,
    ControlBackgroundEmphasis,
    ControlBackgroundDisabled,

    ControlAuxiliaryNormal,
    ControlAuxiliaryFocused,
    ControlAuxiliaryPressed,
    ControlAuxiliaryEmphasis,
    ControlAuxiliaryDisabled,

    ControlBorderNormal,
    ControlBorderFocused,
    ControlBorderPressed,
    ControlBorderEmphasis,
    ControlBorderDisabled,

    ControlForegroundNormal,
    ControlForegroundFocused,
    ControlForegroundPressed,
    ControlForegroundEmphasis,
    ControlForegroundDisabled,

    ControlTextNormal,
    ControlTextFocused,
    ControlTextPressed,
    ControlTextEmphasis,
    ControlTextDisabled,

    // Panel

    PanelBackgroundDistinct,
    PanelBackground,
    PanelBackgroundVague,
    PanelBackgroundDisabled,

    // Workspace

    WorkspaceBackground,
    WorkspaceBackgroundDisabled,
    WorkspaceBackgroundReadonly,

    // Backdrop

    BackdropBackground,
}