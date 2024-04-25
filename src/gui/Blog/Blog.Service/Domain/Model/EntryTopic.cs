using Blog.Service.Domain.Enums;
using System.ComponentModel;
using System.Reflection;

namespace Blog.Service.Domain.Model;

public class EntryTopic
{
    public uint? Id { get; set; }
    public string? Name { get; set; }

    public static List<EntryTopic> GetAll()
    {
        var enums = Enum.GetValues<TopicReference>();

        var topics = enums.Select(e => ToModel(e)).ToList();

        return topics;
    }

    private static EntryTopic ToModel(TopicReference topicEnum)
    {
        var enumName = Enum.GetName(topicEnum)!;
        var field = typeof(TopicReference).GetField(enumName)!;

        EntryTopic result = new()
        {
            Id = (uint)topicEnum,
            Name = field.GetCustomAttribute<DescriptionAttribute>()?.Description ?? enumName,
        };

        return result;  
    }

    public static implicit operator TopicReference(EntryTopic topic)
    {
        if (!topic.Id.HasValue)
        {
            throw new ArgumentException($"${nameof(Id)} is null");
        }

        return (TopicReference)topic.Id.Value;
    }
}


