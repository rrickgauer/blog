using Blog.Service.Domain.TableView;
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

    private void Row_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if (((FrameworkElement)sender).DataContext is EntryTableView entry)
        {
            ViewModel.OnEntryDoubleClicked(entry);
        }   
    }
}
