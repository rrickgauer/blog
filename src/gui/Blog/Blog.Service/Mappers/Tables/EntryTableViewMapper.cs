using Blog.Service.Domain.TableView;
using System.Data;

namespace Blog.Service.Mappers.Tables;

public class EntryTableViewMapper : TableMapper<EntryTableView>
{
    public override EntryTableView ToModel(DataRow row)
    {
        EntryTableView result = new()
        {
            EntryId   = Convert.ToInt32(row.Field<object?>(GetColumnName(nameof(EntryTableView.EntryId)))),
            Date      = row.Field<DateTime?>(GetColumnName(nameof(EntryTableView.Date))),
            Title     = row.Field<string?>(GetColumnName(nameof(EntryTableView.Title))),
            TopicId   = row.Field<uint?>(GetColumnName(nameof(EntryTableView.TopicId))),
            TopicName = row.Field<string?>(GetColumnName(nameof(EntryTableView.TopicName))),
            FileName  = row.Field<string?>(GetColumnName(nameof(EntryTableView.FileName))),
        };

        return result;
    }
}
