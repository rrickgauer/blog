using BlogPilot.Services.Domain.Attributes;

namespace BlogPilot.Services.Domain.Model;

public class Entry
{

    [SqlColumn("id")]
    public int? Id { get; set; }

    [SqlColumn("title")]
    public string? Title { get; set; }

    [SqlColumn("link")]
    public Uri? Link { get; set; }

    [SqlColumn("file_name")]
    public string? FileName { get; set; }

    [SqlColumn("topic_id")]
    public int? TopicId { get; set; }

    [SqlColumn("date")]
    public DateTime? Date { get; set; } = DateTime.Now;
}
