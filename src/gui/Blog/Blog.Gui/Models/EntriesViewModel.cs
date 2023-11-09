using Blog.Service.Domain.Model;
using Blog.Service.Domain.TableView;

namespace Blog.Gui.Models;

public class EntriesViewModel
{
    public List<EntryTableView> Entries { get; set; } = new();
    public List<TopicTableView> UsedTopics { get; set; } = new();
}
