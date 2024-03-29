﻿using BlogPilot.Services.Domain.TableViews;
using System.Data;

namespace BlogPilot.Services.Mapping.ModelMapping;

public class EntryTableViewModelMapper : ModelMapper<EntryTableView>
{
    
    public override EntryTableView ToModel(DataRow dataRow)
    {
        EntryTableView entry = new()
        {
            Id         = (int?)GetSqlColumn<uint?>(dataRow, nameof(EntryTableView.Id)),
            Title      = GetSqlColumn<string?>(dataRow, nameof(EntryTableView.Title)),
            //SourceLink = GetSqlColumn<string?>(dataRow, nameof(EntryTableView.SourceLink)),
            FileName = GetSqlColumn<string?>(dataRow, nameof(EntryTableView.FileName)),
            Date       = GetSqlColumn<DateTime?>(dataRow, nameof(EntryTableView.Date)),
            DateText   = GetSqlColumn<string?>(dataRow, nameof(EntryTableView.DateText)),
            TopicId    = Convert.ToUInt32(GetSqlColumn<object?>(dataRow, nameof(EntryTableView.TopicId))),
            TopicName  = GetSqlColumn<string?>(dataRow, nameof(EntryTableView.TopicName)),
        };

        return entry;
    }
}
