using Blog.WpfGui.ViewModels.Pages;
using System.Windows.Controls;
using Wpf.Ui.Controls;

namespace Blog.WpfGui.Views.Pages;

/// <summary>
/// Interaction logic for EntriesPage.xaml
/// </summary>
public partial class EntriesPage : INavigableView<EntriesViewModel>
{
    public EntriesPage(EntriesViewModel viewModel)
    {
        ViewModel = viewModel;

        InitializeComponent();
    }

    public EntriesViewModel ViewModel { get; }
}
