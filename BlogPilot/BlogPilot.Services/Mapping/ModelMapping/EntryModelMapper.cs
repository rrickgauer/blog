using BlogPilot.Services.Domain.Model;
using System.Data;

namespace BlogPilot.Services.Mapping.ModelMapping;

public class EntryModelMapper : ModelMapper<Entry>
{
    public override Entry ToModel(DataRow dataRow)
    {
        Entry entry = new()
        {
            Id       = GetSqlColumn<uint?>(dataRow, nameof(Entry.Id)),
            Title    = GetSqlColumn<string?>(dataRow, nameof(Entry.Title)),
            Link     = new(new(GetSqlColumn<string?>(dataRow, nameof(Entry.Link)))),
            FileName = GetSqlColumn<string?>(dataRow, nameof(Entry.FileName)),
            TopicId  = GetSqlColumn<uint?>(dataRow, nameof(Entry.TopicId)),
            Date     = GetSqlColumn<DateTime?>(dataRow, nameof(Entry.Date)),
        };

        return entry;
    }
}
