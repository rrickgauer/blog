using BlogPilot.Services.Domain.Attributes;
using BlogPilot.Services.Domain.Model;
using BlogPilot.Services.Utilities;

namespace BlogPilot.Services.Domain.TableViews;

public class TopicTableView : ITableView, ITableViewModel<TopicTableView, Topic>
{
    #region - BaseTableView -
    //public override string ViewName => "View_Used_Topics";
    public string ViewName => "View_Used_Topics";
    #endregion

    [CopyToModel(typeof(Topic))]
    [SqlColumn("id")]
    public uint? Id { get; set; }

    [CopyToModel(typeof(Topic))]
    [SqlColumn("name")]
    public string? Name { get; set; }

    [SqlColumn("count")]
    public int? Count { get; set; } = 0;

    #region - ITableViewModel -

    public static explicit operator Topic(TopicTableView other)
    {
        return TableViewUtilities.CopyTableViewProperties<TopicTableView, Topic>(other);
    }

    #endregion
}
