namespace Blog.Service.Domain.Model;

public class Entry
{
    public long? Id { get; set; }
    public DateTime? Date { get; set; } = DateTime.Now;
    public string? Title { get; set; }
    public string? FileName { get; set; }
    public long? TopicId { get; set; }
}
