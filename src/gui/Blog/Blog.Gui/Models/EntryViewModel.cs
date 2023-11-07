using Blog.Service.Domain.TableView;

namespace Blog.Gui.Models;

public class EntryViewModel
{
    public EntryTableView? Entry { get; set; }
    public string? Content { get; set; }
}
