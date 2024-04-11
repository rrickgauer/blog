using Blog.Gui.Models;
using Blog.Service.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Blog.Gui.Controllers;

[Controller]
[Route("")]
public class HomeController : Controller
{
    private readonly IEntryService _entryService;
    private readonly ITopicService _topicService;
    private readonly IMarkdownService _markdownService;

    public HomeController(IEntryService entryService, ITopicService topicService, IMarkdownService markdownService)
    {
        _entryService = entryService;
        _topicService = topicService;
        _markdownService = markdownService;
    }


    /// <summary>
    /// GET: /
    /// GET: /entries
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [HttpGet("entries")]
    public async Task<IActionResult> ShowAllEntriesAsync()
    {
        var entryViews = await _entryService.GetAllEntriesAsync();
        var usedTopics = await _topicService.GetUsedTopicsAsync();

        EntriesViewModel viewModel = new()
        {
            Entries = entryViews.ToList(),
            UsedTopics = usedTopics.ToList(),
        };

        return View("Index", viewModel);
    }


    /// <summary>
    /// GET: /entries/:entryId
    /// </summary>
    /// <param name="entryId"></param>
    /// <returns></returns>
    [HttpGet("entries/{entryId}")]
    public async Task<IActionResult> ShowEntryAsync([FromRoute] uint entryId)
    {
        var entry = await _entryService.GetEntryAsync(entryId);

        if (entry == null)
        {
            return NotFound();
        }

        var markdown = _markdownService.GetEntryHtml(entry.FileName!);

        EntryViewModel viewModel = new()
        {
            Entry = entry,
            Content = markdown,
        };

        return View("Entry", viewModel);
    }
}
