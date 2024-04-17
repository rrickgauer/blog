using Blog.WpfGui.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace Blog.WpfGui.Views.Pages;

/// <summary>
/// Interaction logic for EntryFormPage.xaml
/// </summary>
public partial class EntryFormPage : INavigableView<EntryFormViewModel>
{
    public EntryFormViewModel ViewModel { get; }

    public EntryFormPage(EntryFormViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }
}
