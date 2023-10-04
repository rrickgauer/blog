using BlogPilot.Services.Service.Interface;
using BlogPilot.WpfGui.Messaging;
using BlogPilot.WpfGui.Other;
using BlogPilot.WpfGui.Views.Controls;
using BlogPilot.WpfGui.Views.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Wpf.Ui.Common.Interfaces;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

namespace BlogPilot.WpfGui.ViewModels.Pages;

public partial class CreateEntryViewModel : ObservableObject, INavigationAware, IMessengerCompliant, IEntryFormSubscriber,
    IRecipient<EntryFormSubmittedMessage>,
    IRecipient<EntryFormCanceledMessage>
{

    #region - Private Members -
    private readonly IEntryService _entryService;
    private readonly INavigation _navigation;
    #endregion

    #region - Generated Properties - 
    
    /// <summary>
    /// EntryFormControl
    /// </summary>
    [ObservableProperty]
    private EntryFormControl? _entryFormControl = null;
    #endregion

    #region - Public Properties - 
    public Guid EntryFormMessageToken => new(@"c1b8299d-965f-44a5-8cec-3320a1ee8b48");
    #endregion

    #region - Constructor -

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="entryService"></param>
    /// <param name="navigationService"></param>
    public CreateEntryViewModel(IEntryService entryService, INavigationService navigationService)
    {
        _entryService = entryService;
        _navigation = navigationService.GetNavigationControl();
    }

    #endregion

    #region - INavigationAware - 

    public void OnNavigatedFrom() {}

    public void OnNavigatedTo()
    {
        ResetForm();
    }

    #endregion

    #region - Messaging -

    /// <summary>
    /// Register the messenger
    /// </summary>
    public void RegisterMessages()
    {
        WeakReferenceMessenger.Default.RegisterAll(this, EntryFormMessageToken);
    }

    /// <summary>
    /// Message handler for EntryFormSubmittedMessage
    /// </summary>
    /// <param name="message"></param>
    public async void Receive(EntryFormSubmittedMessage message)
    {
        await CreateNewEntryAsync();

        _navigation.Navigate(typeof(EntriesPage));
    }

    public void Receive(EntryFormCanceledMessage message)
    {
        _navigation.Navigate(typeof(EntriesPage));
    }

    #endregion

    #region - Private Methods -

    /// <summary>
    /// Reset the form control
    /// </summary>
    private void ResetForm()
    {
        if (EntryFormControl != null)
        {
            EntryFormControl.Content = null;
        }
        
        EntryFormControl = null;
        
        EntryFormControl = GetNewEntryFormControl();
    }

    /// <summary>
    /// Setup a new form control
    /// </summary>
    /// <returns></returns>
    private EntryFormControl GetNewEntryFormControl()
    {
        EntryFormControl control = new(new(Enums.FormInputMode.Create, EntryFormMessageToken));

        control.ViewModel.SetFormInputValues(new()); 

        return control;
    }

    /// <summary>
    /// Create a new entry record
    /// </summary>
    /// <returns></returns>
    private async Task CreateNewEntryAsync()
    {
        var entry = EntryFormControl.ViewModel.GetFormInputValues();

        await _entryService.CreateEntryAsync(entry);
    }


    #endregion
}
