using BlogPilot.Services.Domain.Attributes;

namespace BlogPilot.Services.Domain.Model;

public class Topic
{
    [SqlColumn("id")]
    public int? Id { get; set; }

    [SqlColumn("name")]
    public string? Name { get; set; }
}
