using Blog.Service.Domain.TableView;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Blog.WpfGui.Messenger;

public class ViewMessages
{
    public sealed class TestMessage(int id) : ValueChangedMessage<int>(id) { }

    public sealed class EntryFormSavedMessage(EntryTableView entry) : ValueChangedMessage<EntryTableView>(entry) { }

    public sealed class TopicFormSavedMessage(TopicTableView topic) : ValueChangedMessage<TopicTableView>(topic) { }
}
