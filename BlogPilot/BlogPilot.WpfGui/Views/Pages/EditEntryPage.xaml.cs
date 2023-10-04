using BlogPilot.WpfGui.ViewModels.Pages;
using Wpf.Ui.Common.Interfaces;

namespace BlogPilot.WpfGui.Views.Pages;

/// <summary>
/// Interaction logic for EditEntryPage.xaml
/// </summary>
public partial class EditEntryPage : INavigableView<EditEntryViewModel>
{
    public EditEntryViewModel ViewModel { get; set; }

    public EditEntryPage(EditEntryViewModel viewModel)
    {
        ViewModel = viewModel;

        InitializeComponent();
    }
}
