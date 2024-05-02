using Blog.WpfGui.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace Blog.WpfGui.Views.Pages;

/// <summary>
/// Interaction logic for LandingPage.xaml
/// </summary>
public partial class LandingPage : INavigableView<LandingViewModel>
{
    public LandingViewModel ViewModel { get; }

    public LandingPage(LandingViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }
}
