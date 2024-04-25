using CommunityToolkit.Mvvm.Messaging;
using Wpf.Ui.Controls;

namespace Blog.WpfGui.ViewModels.Base;

public abstract partial class NavigableViewModel : ObservableObject, INavigationAware
{
    protected virtual Guid MessengerToken { get; } = Guid.NewGuid();

    protected virtual void InitMessenger()
    {
        WeakReferenceMessenger.Default.RegisterAll(this, MessengerToken);
    }


    // INavigationAware
    public virtual void OnNavigatedFrom()
    {
        
    }

    public virtual void OnNavigatedTo()
    {
        
    }


}