using Blog.Gui.Models;
using Blog.Service.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Gui.Controllers;

[Controller]
[Route("")]
public class HomeController : Controller
{
    private readonly IEntryService _entryService;
    private readonly ITopicService _topicService;

    public HomeController(IEntryService entryService, ITopicService topicService)
    {
        _entryService = entryService;
        _topicService = topicService;
    }

    [HttpGet]
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
}
