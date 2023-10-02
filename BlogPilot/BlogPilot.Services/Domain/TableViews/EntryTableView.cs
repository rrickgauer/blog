using BlogPilot.Services.Domain.Attributes;
using BlogPilot.Services.Domain.Model;
using BlogPilot.Services.Utilities;

namespace BlogPilot.Services.Domain.TableViews;

public class EntryTableView : ITableView, ITableViewModel<EntryTableView, Entry>, ITableViewModel<EntryTableView, Topic>
{
    #region - BaseTableView -
    //public override string ViewName => "View_Used_Topics";
    public string ViewName => "View_Used_Topics";
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
    public Uri? SourceLink { get; set; }

    [SqlColumn("page_link")]
    public string? PageLink { get; set; }

    [CopyToModel(typeof(Entry))]
    [CopyToModel(typeof(Topic), nameof(Topic.Id))]
    [SqlColumn("topic_id")]
    public uint? TopicId { get; set; }

    [CopyToModel(typeof(Topic), nameof(Topic.Name))]
    [SqlColumn("topic_name")]
    public string? TopicName { get; set; }


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
