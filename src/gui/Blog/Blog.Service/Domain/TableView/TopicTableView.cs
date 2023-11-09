using Blog.Service.Domain.Contracts;
using Blog.Service.Domain.CustomAttributes;
using Blog.Service.Domain.Model;

namespace Blog.Service.Domain.TableView;

public class TopicTableView : ITableView<TopicTableView, EntryTopic>
{
    [SqlColumn("id")]
    [CopyToProperty<EntryTopic>(nameof(EntryTopic.Id))]
    public uint? TopicId { get; set; }

    [SqlColumn("name")]
    [CopyToProperty<EntryTopic>(nameof(EntryTopic.Name))]
    public string? Name { get; set; }

    [SqlColumn("count")]
    public long? Count { get; set; }


    #region - ITableView -

    public static explicit operator EntryTopic(TopicTableView other)
    {
        return ((ITableView<TopicTableView, EntryTopic>)other).CastToModel();
    }

    #endregion
}
