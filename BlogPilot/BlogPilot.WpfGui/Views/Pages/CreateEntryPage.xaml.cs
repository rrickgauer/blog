using BlogPilot.WpfGui.ViewModels.Pages;
using Wpf.Ui.Common.Interfaces;

namespace BlogPilot.WpfGui.Views.Pages;

/// <summary>
/// Interaction logic for CreateEntryPage.xaml
/// </summary>
public partial class CreateEntryPage : INavigableView<CreateEntryViewModel>
{
    public CreateEntryViewModel ViewModel { get; set; }

    public CreateEntryPage(CreateEntryViewModel viewModel)
    {
        ViewModel = viewModel;
        
        DataContext = this;

        InitializeComponent();
    }
}
