using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Repository.Commands;

public sealed class TopicCommands
{
    public const string SelectAllUsed = @"
        SELECT
            *
        FROM
            View_Used_Topics v
        ORDER BY
            v.name ASC;";
}
