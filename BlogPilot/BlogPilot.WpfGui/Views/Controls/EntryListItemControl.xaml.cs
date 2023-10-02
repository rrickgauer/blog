using BlogPilot.WpfGui.ViewModels.Controls;
using System.Windows.Controls;
using Wpf.Ui.Common.Interfaces;

namespace BlogPilot.WpfGui.Views.Controls;

/// <summary>
/// Interaction logic for EntryListItemControl.xaml
/// </summary>
public partial class EntryListItemControl : UserControl, INavigableView<EntryListItemViewModel>
{
    public EntryListItemViewModel ViewModel { get; set; }   

    public EntryListItemControl(EntryListItemViewModel viewModel)
    {
        ViewModel = viewModel;

        InitializeComponent();
    }
}
