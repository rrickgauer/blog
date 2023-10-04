using BlogPilot.Services.Domain.Attributes;

namespace BlogPilot.Services.Domain.Model;

public class Entry : IUpdateable
{

    [SqlColumn("id")]
    public int? Id { get; set; }

    [SqlColumn("title")]
    public string? Title { get; set; }

    [SqlColumn("link")]
    public string? Link { get; set; }

    [SqlColumn("file_name")]
    public string? FileName { get; set; }

    [SqlColumn("topic_id")]
    public uint? TopicId { get; set; }

    [SqlColumn("date")]
    public DateTime? Date { get; set; } = DateTime.Now;


    public bool UpdatePropertiesValid()
    {
        if (Id == null) 
        { 
            return false; 
        }
        else if (string.IsNullOrEmpty(Title))
        {
            return false;
        }
        else if (TopicId == null)
        {
            return false;
        }
        else if (Link == null)
        {
            return false;
        }
        
        return true;

    }
}
