using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;

namespace CSX.Toolkits.WpfExtensions.Contexts.QueryDialogContext;

internal partial class QueryDialogContextLogic : ObservableObject
{
    [ObservableProperty]
    private HorizontalAlignment _buttonsPanelAlignment = HorizontalAlignment.Right;
}