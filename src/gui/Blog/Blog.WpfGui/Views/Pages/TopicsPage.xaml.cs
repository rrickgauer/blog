using Blog.WpfGui.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace Blog.WpfGui.Views.Pages;

/// <summary>
/// Interaction logic for TopicsPage.xaml
/// </summary>
public partial class TopicsPage : INavigableView<TopicsViewModel>
{
    public TopicsViewModel ViewModel { get; }

    public TopicsPage(TopicsViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }
}
