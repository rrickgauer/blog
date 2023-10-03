using BlogPilot.WpfGui.ViewModels.Pages;
using Wpf.Ui.Common.Interfaces;

namespace BlogPilot.WpfGui.Views.Pages;

/// <summary>
/// Interaction logic for LandingPage.xaml
/// </summary>
public partial class LandingPage : INavigableView<LandingViewModel>
{
    public LandingViewModel ViewModel { get; set; }

    public LandingPage(LandingViewModel viewModel)
    {
        ViewModel = viewModel;

        InitializeComponent();
    }
}
