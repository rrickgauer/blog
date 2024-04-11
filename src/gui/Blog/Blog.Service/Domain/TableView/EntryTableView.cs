using Blog.Service.Domain.Contracts;
using Blog.Service.Domain.CustomAttributes;
using Blog.Service.Domain.Model;
using Blog.Service.Utility;

namespace Blog.Service.Domain.TableView;

public class EntryTableView : ITableView<EntryTableView, Entry>, ITableView<EntryTableView, EntryTopic>
{

    [SqlColumn("id")]
    [CopyToProperty<Entry>(nameof(Entry.Id))]
    public int? EntryId { get; set; }

    [SqlColumn("date")]
    [CopyToProperty<Entry>(nameof(Entry.Date))]
    public DateTime? Date { get; set; }

    [SqlColumn("title")]
    [CopyToProperty<Entry>(nameof(Entry.Title))]
    public string? Title { get; set; }

    [SqlColumn("source_link")]
    [CopyToProperty<Entry>(nameof(Entry.Link))]
    public string? Link { get; set; }

    [SqlColumn("file_name")]
    [CopyToProperty<Entry>(nameof(Entry.FileName))]
    public string? FileName { get; set; }

    [SqlColumn("topic_id")]
    [CopyToProperty<Entry>(nameof(Entry.TopicId))]
    [CopyToProperty<EntryTopic>(nameof(EntryTopic.Id))]
    public uint? TopicId { get; set; }

    [SqlColumn("topic_name")]
    [CopyToProperty<EntryTopic>(nameof(EntryTopic.Name))]
    public string? TopicName { get; set; }

    public string WpfUiCardHeaderText => $"{Title} #{EntryId}";


    

    #region - ITableView -

    public static explicit operator Entry(EntryTableView other)
    {
        return ((ITableView<EntryTableView, Entry>)other).CastToModel();
    }

    public static explicit operator EntryTopic(EntryTableView other)
    {
        return ((ITableView<EntryTableView, EntryTopic>)other).CastToModel();
    }

    #endregion


}
