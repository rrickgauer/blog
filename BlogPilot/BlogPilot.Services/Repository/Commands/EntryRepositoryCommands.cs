using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPilot.Services.Repository.Commands;

public static class EntryRepositoryCommands
{
    public const string SelectAll = @"
        SELECT
            *
        FROM
            View_Entries v
        ORDER BY
            v.date DESC;";
}
