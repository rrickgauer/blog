using Blog.Service.Domain.Configs;
using Blog.Service.Domain.Contracts;
using Blog.Service.Domain.CustomAttributes;
using Blog.Service.Domain.Model;
using System.Diagnostics;

namespace Blog.Service.Domain.TableView;

public class EntryTableView : ITableView<EntryTableView, Entry>, ITableView<EntryTableView, EntryTopic>
{

    [SqlColumn("id")]
    [CopyToProperty<Entry>(nameof(Entry.Id))]
    public int? EntryId { get; set; }

    [SqlColumn("date")]
    [CopyToProperty<Entry>(nameof(Entry.Date))]
    public DateTime? Date { get; set; } = DateTime.Now;

    [SqlColumn("title")]
    [CopyToProperty<Entry>(nameof(Entry.Title))]
    public string? Title { get; set; }

    [SqlColumn("file_name")]
    [CopyToProperty<Entry>(nameof(Entry.FileName))]
    public string? FileName { get; set; }

    [SqlColumn("topic_id")]
    [CopyToProperty<Entry>(nameof(Entry.TopicId))]
    [CopyToProperty<EntryTopic>(nameof(EntryTopic.Id))]
    public uint? TopicId { get; set; }

    [SqlColumn("topic_name")]
    [CopyToProperty<EntryTopic>(nameof(EntryTopic.Name))]
    public string? TopicName { get; set; }

    public string WpfUiCardHeaderText => $"{Title} #{EntryId}";

    public DateOnly? WpfDateDisplayText
    {
        get
        {
            if (!Date.HasValue)
            {
                return null;
            }

            return DateOnly.FromDateTime(Date.Value);
        }
    }

    public void ViewPublication(IConfigs configs)
    {
        string url = GetPublicUrl(configs);
        OpenFile(url);
    }

    public string GetPublicUrl(IConfigs configs)
    {
        ArgumentNullException.ThrowIfNull(EntryId);
        return $"{configs.GuiHttpAddress.AbsoluteUri}entries/{EntryId}";
    }


    public void ViewMarkdownFile(IConfigs configs)
    {
        FileInfo markdownFile = GetMarkdownFileInfo(configs);

        OpenFile(markdownFile.FullName);
    }

    public FileInfo GetMarkdownFileInfo(IConfigs configs)
    {
        ArgumentNullException.ThrowIfNull(FileName);

        FileInfo markdownFile = new(Path.Combine(configs.EntryFilesPath, FileName));

        return markdownFile;
    }

    private static void OpenFile(string filename)
    {
        ProcessStartInfo startInfo = new(filename)
        {
            UseShellExecute = true,
        };

        Process.Start(startInfo);
    }


    #region - ITableView -

    public static explicit operator Entry(EntryTableView other)
    {
        return other.CastToModel<EntryTableView, Entry>();
    }

    public static explicit operator EntryTopic(EntryTableView other)
    {
        return other.CastToModel<EntryTableView, EntryTopic>();
    }

    #endregion


}
