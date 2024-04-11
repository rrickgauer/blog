using Blog.WpfGui.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace Blog.WpfGui.Views.Pages;

/// <summary>
/// Interaction logic for EntriesPage.xaml
/// </summary>
public partial class EntriesPage : INavigableView<EntriesViewModel>
{
    public EntriesViewModel ViewModel { get; }

    public EntriesPage(EntriesViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;
        InitializeComponent();
    }
}
