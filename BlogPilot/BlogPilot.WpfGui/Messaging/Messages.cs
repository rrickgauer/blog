using CommunityToolkit.Mvvm.Messaging.Messages;

namespace BlogPilot.WpfGui.Messaging;

public sealed class EntryFormSubmittedMessage : ValueChangedMessage<EventArgs>
{
    public EntryFormSubmittedMessage(EventArgs e) : base(e) { }
}

public sealed class EntryFormCanceledMessage : ValueChangedMessage<EventArgs>
{
    public EntryFormCanceledMessage(EventArgs e) : base(e) { }
}


public sealed class EntryListItemEditMessage : ValueChangedMessage<int>
{
    public EntryListItemEditMessage(int entryId) : base(entryId) { }
}

public sealed class EntryListItemDeletedMessage : ValueChangedMessage<int>
{
    public EntryListItemDeletedMessage(int entryId) : base(entryId) { }
}


public sealed class EditEntryMessage : ValueChangedMessage<int>
{
    public EditEntryMessage(int entryId) : base(entryId) { }
}

