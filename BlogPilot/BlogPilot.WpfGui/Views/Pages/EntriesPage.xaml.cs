using BlogPilot.WpfGui.ViewModels.Pages;
using Wpf.Ui.Common.Interfaces;

namespace BlogPilot.WpfGui.Views.Pages;

/// <summary>
/// Interaction logic for EntriesPage.xaml
/// </summary>
public partial class EntriesPage : INavigableView<EntriesViewModel>
{
    public EntriesViewModel ViewModel { get; set; }

    public EntriesPage(EntriesViewModel viewModel)
    {
        ViewModel = viewModel;

        InitializeComponent();
    }
}
