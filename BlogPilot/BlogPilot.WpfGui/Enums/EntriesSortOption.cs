using System.ComponentModel;

namespace BlogPilot.WpfGui.Enums;

public enum EntriesSortOption
{
    [Description("Date created")]
    CreatedOn,

    [Description("Title")]
    Title,
}
