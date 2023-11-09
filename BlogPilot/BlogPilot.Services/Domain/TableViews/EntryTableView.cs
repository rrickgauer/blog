using BlogPilot.Services.Domain.Attributes;
using BlogPilot.Services.Domain.Model;
using BlogPilot.Services.Utilities;

namespace BlogPilot.Services.Domain.TableViews;

public class EntryTableView : ITableView, ITableViewModel<EntryTableView, Entry>, ITableViewModel<EntryTableView, Topic>
{
    #region - BaseTableView -
    public string ViewName => "View_Entries";
    #endregion

    [CopyToModel(typeof(Entry))]
    [SqlColumn("id")]
    public int? Id { get; set; }

    [CopyToModel(typeof(Entry))]
    [SqlColumn("date")]
    public DateTime? Date { get; set; }

    [SqlColumn("date_formatted")]
    public string? DateText { get; set; }

    [CopyToModel(typeof(Entry))]
    [SqlColumn("title")]
    public string? Title { get; set; }

    [CopyToModel(typeof(Entry), nameof(Entry.Link))]
    [SqlColumn("source_link")]
    public string? SourceLink { get; set; }

    [SqlColumn("file_name")]
    [CopyToModel(typeof(Entry), nameof(Entry.FileName))]
    public string? FileName { get; set; }

    [CopyToModel(typeof(Entry))]
    [CopyToModel(typeof(Topic), nameof(Topic.Id))]
    [SqlColumn("topic_id")]
    public uint? TopicId { get; set; }

    [CopyToModel(typeof(Topic), nameof(Topic.Name))]
    [SqlColumn("topic_name")]
    public string? TopicName { get; set; }


    public string DisplayId => $"#{Id}";


    #region - ITableViewModel -

    public static explicit operator Entry(EntryTableView other)
    {
        return TableViewUtilities.CopyTableViewProperties<EntryTableView, Entry>(other);
    }

    public static explicit operator Topic(EntryTableView other)
    {
        return TableViewUtilities.CopyTableViewProperties<EntryTableView, Topic>(other);
    }

    #endregion
}
