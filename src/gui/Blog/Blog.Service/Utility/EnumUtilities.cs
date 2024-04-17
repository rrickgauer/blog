using Blog.Service.Domain.Enums;
using Blog.Service.Domain.Model;
using System.ComponentModel;
using System.Reflection;

namespace Blog.Service.Utility;

public static class EnumUtilities
{

    public static EntryTopic GetEntryTopicByReference(TopicReference topicReference)
    {
        return GetEntryTopicByReference((uint)topicReference);
    }

    public static EntryTopic GetEntryTopicByReference(uint topicReference)
    {
        var valueName = Enum.GetName(typeof(TopicReference), topicReference);
        var topicName = typeof(TopicReference).GetField(valueName!)?.GetCustomAttribute<DescriptionAttribute>()?.Description ?? valueName;

        EntryTopic result = new()
        {
            Id = topicReference,
            Name = topicName,
        };

        return result;
    }



}
