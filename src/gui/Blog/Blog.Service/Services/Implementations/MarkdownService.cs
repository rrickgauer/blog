using Blog.Service.Domain.Configs;
using Blog.Service.Services.Contracts;
using Markdig;

namespace Blog.Service.Services.Implementations;

public class MarkdownService : IMarkdownService
{
    private readonly IConfigs _configs;

    private static readonly MarkdownPipeline _markdownPipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();

    private string EntriesFolder => _configs.EntryFilesPath;

    public MarkdownService(IConfigs configs)
    {
        _configs = configs;
    }


    public string GetEntryHtml(string entryFileName)
    {
        var entryFile = GetEntryAbsolutePath(entryFileName);
        var fileContent = File.ReadAllText(entryFile.FullName);

        var result = Markdown.ToHtml(fileContent, _markdownPipeline);

        return result;
    }

    private FileInfo GetEntryAbsolutePath(string entryFileName) 
    { 
        var pathText = Path.Combine(EntriesFolder, entryFileName);

        FileInfo result = new(pathText);

        if (!result.Exists)
        {
            throw new FileNotFoundException(pathText);
        }

        return result;
    }
}
