using Blog.Service.Domain.TableView;
using System.Data;

namespace Blog.Service.Mappers.Tables;

public class TopicTableViewMapper : TableMapper<TopicTableView>
{
    public override TopicTableView ToModel(DataRow row)
    {
        TopicTableView result = new()
        {
            TopicId = row.Field<long?>(GetColumnName(nameof(TopicTableView.TopicId))),
            Name    = row.Field<string?>(GetColumnName(nameof(TopicTableView.Name))),
            Count   = row.Field<long?>(GetColumnName(nameof(TopicTableView.Count))),
        };

        return result;
    }
}