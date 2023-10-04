using BlogPilot.Services.Domain.Model;
using BlogPilot.Services.Service.Interface;
using BlogPilot.WpfGui.Messaging;
using BlogPilot.WpfGui.Other;
using BlogPilot.WpfGui.ViewModels.Controls;
using BlogPilot.WpfGui.Views.Controls;
using BlogPilot.WpfGui.Views.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows;
using Wpf.Ui.Common.Interfaces;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Mvvm.Contracts;

namespace BlogPilot.WpfGui.ViewModels.Pages;

public partial class EditEntryViewModel : ObservableObject, INavigationAware, IMessengerCompliant, IEntryFormSubscriber,
    IRecipient<EntryFormSubmittedMessage>,
    IRecipient<EntryFormCanceledMessage>,
    IRecipient<EditEntryMessage>
{

    #region - Private Members -

    private readonly IEntryService _entryService;
    private readonly INavigation _navigation;
    private readonly IWebService _webService;

    private int _currentEntryId = int.MinValue;

    #endregion

    #region - Generated Properties - 

    /// <summary>
    /// EntryFormControl
    /// </summary>
    [ObservableProperty]
    private EntryFormControl? _entryFormControl = null;

    #endregion


    #region - Public Properties -

    // IEntryFormSubscriber
    public Guid EntryFormMessageToken => new(@"3c22f53a-bc6f-4272-afbe-bde404d6e1ae");

    #endregion


    public EditEntryViewModel(IEntryService entryService, INavigationService navigationService, IWebService webService)
    {
        _entryService = entryService;
        _navigation = navigationService.GetNavigationControl();
        _webService = webService;
    }


    #region - INavigationAware - 

    public void OnNavigatedFrom()
    {

    }

    public async void OnNavigatedTo()
    {
        await ResetForm();
    }

    #endregion

    #region - Messaging -

    /// <summary>
    /// IMessengerCompliant
    /// </summary>
    public void RegisterMessages()
    {
        WeakReferenceMessenger.Default.RegisterAll(this, EntryFormMessageToken);
        WeakReferenceMessenger.Default.Register<EditEntryMessage>(this);
    }

    public async void Receive(EntryFormSubmittedMessage message)
    {
        await SaveEntryChangesAsync();
    }

    public void Receive(EditEntryMessage message)
    {
        _currentEntryId = message.Value;
    }

    public void Receive(EntryFormCanceledMessage message)
    {
        NavigateToEntriesPage();
    }

    #endregion


    #region - Commands -

    [RelayCommand]
    private async Task DeleteAsync()
    {
        bool deleted = await DeleteEntryAsync();

        if (deleted)
        {
            NavigateToEntriesPage();
        }
    }

    [RelayCommand]
    private void View()
    {
        _webService.ViewEntry(_currentEntryId);
    }


    #endregion




    #region - Private Methods -

    private async Task ResetForm()
    {
        if (EntryFormControl != null)
        {
            EntryFormControl.Content = null;
        }

        EntryFormControl = null;

        EntryFormControl = await GetNewEntryFormControl();
    }

    private async Task<EntryFormControl> GetNewEntryFormControl()
    {
        EntryFormViewModel viewModel = new(Enums.FormInputMode.Edit, EntryFormMessageToken);

        var entry = await GetEntry(_currentEntryId);

        viewModel.SetFormInputValues(entry);

        EntryFormControl control = new(viewModel);

        return control;
    }

    private async Task<Entry> GetEntry(int entryId)
    {
        var entry = await _entryService.GetEntryAsync(entryId);

        if (entry == null)
        {
            throw new ArgumentException($"Could not find entry with id: {entryId}");
        }

        return (Entry)entry;
    }


    private async Task SaveEntryChangesAsync()
    {
        var updatedEntry = EntryFormControl?.ViewModel.GetFormInputValues();

        if (updatedEntry == null)
        {
            return;
        }

        await _entryService.SaveEntryAsync(updatedEntry);

        NavigateToEntriesPage();
    }

    private void NavigateToEntriesPage()
    {
        _navigation.Navigate(typeof(EntriesPage));
    }

    private async Task<bool> DeleteEntryAsync()
    {
        if (!ConfirmDelete())
        {
            return false;
        }

        await _entryService.DeleteEntryAsync(_currentEntryId);

        return true;
    }

    private bool ConfirmDelete()
    {
        var response = MessageBox.Show("Are you sure you want to delete this entry?", "Delete entry", MessageBoxButton.YesNoCancel);

        switch (response)
        {
            case MessageBoxResult.Yes:
            case MessageBoxResult.OK:
                return true;
            default:
                return false;
        }
    }



    #endregion
}
