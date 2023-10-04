using BlogPilot.WpfGui.ViewModels.Controls;
using System.Windows.Controls;
using Wpf.Ui.Common.Interfaces;

namespace BlogPilot.WpfGui.Views.Controls;

/// <summary>
/// Interaction logic for EntryFormControl.xaml
/// </summary>
public partial class EntryFormControl : UserControl, INavigableView<EntryFormViewModel>
{
    public EntryFormViewModel ViewModel { get; set; }

    public EntryFormControl(EntryFormViewModel viewModel)
    {
        ViewModel = viewModel;

        DataContext = this;

        InitializeComponent();
    }
}
