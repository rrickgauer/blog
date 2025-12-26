using Blog.Service.Domain.Contracts;
using Blog.Service.Domain.CustomAttributes;
using Blog.Service.Domain.Model;

namespace Blog.Service.Domain.TableView;

public class TopicTableView : ITableView<TopicTableView, EntryTopic>
{
    [SqlColumn("topic_id")]
    [CopyToProperty<EntryTopic>(nameof(EntryTopic.Id))]
    public long? TopicId { get; set; }

    [SqlColumn("topic_name")]
    [CopyToProperty<EntryTopic>(nameof(EntryTopic.Name))]
    public string? Name { get; set; }

    [SqlColumn("count_entries")]
    public long? Count { get; set; }


    #region - ITableView -

    public static explicit operator EntryTopic(TopicTableView other)
    {
        return other.CastToModel();
    }

    #endregion
}
