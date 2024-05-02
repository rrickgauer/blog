using Blog.Service.Domain.Configs;
using Blog.WpfGui.ViewModels.Base;
using Blog.WpfGui.Views.Pages;
using System.Diagnostics;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace Blog.WpfGui.ViewModels.Pages;

public partial class LandingViewModel : ViewModel
{
    private readonly INavigationView _navigation;
    private readonly IConfigs _configs;

    public LandingViewModel(INavigationService navigationService, IConfigs configs)
    {
        _navigation = navigationService.GetNavigationControl();
        _configs = configs;
    }


    #region - Commands -
    
    [RelayCommand]
    private void EntriesPage()
    {
        _navigation.Navigate(typeof(EntriesPage));
    }

    [RelayCommand]
    private void TopicsPage()
    {
        _navigation.Navigate(typeof(TopicsPage));
    }

    [RelayCommand]
    private void BlogSite()
    {
        ProcessStartInfo startInfo = new(_configs.GuiHttpAddress.AbsoluteUri)
        {
            UseShellExecute = true,
        };

        Process.Start(startInfo);
    }

    [RelayCommand]
    private void Documents()
    {
        ProcessStartInfo startInfo = new(_configs.EntryFilesPath)
        {
            UseShellExecute = true,
        };

        Process.Start(startInfo);
    }

    [RelayCommand]
    private void Repository()
    {
        ProcessStartInfo startInfo = new(@"https://github.com/rrickgauer/blog")
        {
            UseShellExecute = true,
        };

        Process.Start(startInfo);
    }

    #endregion

}
