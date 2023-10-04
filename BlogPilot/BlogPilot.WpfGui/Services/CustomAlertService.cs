using Wpf.Ui.Common;
using Wpf.Ui.Mvvm.Contracts;

namespace BlogPilot.WpfGui.Services;

public class CustomAlertService
{
    private readonly ISnackbarService _snackbarService;

    public CustomAlertService(ISnackbarService snackbarService)
    {
        _snackbarService = snackbarService;
    }

    /// <summary>
    /// Show successful alert
    /// </summary>
    /// <param name="message"></param>
    public void Successful(string message)
    {
        _snackbarService.Show("Success", message, SymbolRegular.Checkmark32, ControlAppearance.Success);
    }

    public void Error(string message, string title = "Error")
    {
        _snackbarService.Show(title, message, SymbolRegular.ErrorCircle24, ControlAppearance.Danger);
    }
}
