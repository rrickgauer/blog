using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Repository.Commands;

public sealed class EntryCommands
{
    public const string SelectAll = @"
        SELECT
            ve.id AS id,
            ve.date AS date,
            ve.date_formatted AS date_formatted,
            ve.title AS title,
            ve.source_link AS source_link,
            ve.file_name AS file_name,
            ve.topic_id AS topic_id,
            ve.topic_name AS topic_name
        FROM
            View_Entries ve
        ORDER BY
            ve.date DESC;
    ";
}
