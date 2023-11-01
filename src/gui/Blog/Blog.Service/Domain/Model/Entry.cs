namespace Blog.Service.Domain.Model;

public class Entry
{
    public int? Id { get; set; }
    public DateTime? Date { get; set; }
    public string? Title { get; set; }
    public string? Link { get; set; }
    public string? FileName { get; set; }
    public uint? TopicId { get; set; }
}
