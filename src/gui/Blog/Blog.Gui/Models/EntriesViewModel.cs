using Blog.Service.Domain.Model;
using Blog.Service.Domain.TableView;

namespace Blog.Gui.Models;

public class EntriesViewModel
{
    public List<EntryTableView> Entries { get; set; } = new();
    public List<EntryTopic> UsedTopics { get; set; } = new();
}
