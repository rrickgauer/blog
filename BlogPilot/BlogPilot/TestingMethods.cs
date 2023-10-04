using BlogPilot.Services.Domain.Attributes;
using BlogPilot.Services.Domain.Model;
using BlogPilot.Services.Domain.TableViews;
using BlogPilot.Services.Utilities;

namespace BlogPilot;

public static class TestingMethods
{
    public static void TestCopyToModelAttribute()
    {


        EntryTableView entryView = new()
        {
            Id = 45,
            Title = "Test title",
            TopicId = 3,
            Date = DateTime.Now,
            SourceLink = new(@"https://marketplace.visualstudio.com/items?itemName=Equinusocio.vsc-material-theme"),
            TopicName = "This is the topic name",
        };

        var entryModel = (Entry)entryView;

        var topicModel = (Topic)entryView;


        string fffff = "sup my bro";
    }


    public static void TestEnumDescription()
    {
        
    }

}


