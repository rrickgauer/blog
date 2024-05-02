using Blog.WpfGui.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace Blog.WpfGui.Views.Pages;

/// <summary>
/// Interaction logic for TopicFormPage.xaml
/// </summary>
public partial class TopicFormPage : INavigableView<TopicFormViewModel>
{
    public TopicFormViewModel ViewModel { get; }

    public TopicFormPage(TopicFormViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
        
    }
}
