using Blog.Gui.Models;
using Blog.Service.Domain.Model;
using Blog.Service.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Gui.Controllers;

[Controller]
[Route("")]
public class HomeController : Controller
{
    private readonly IEntryService _entryService;

    public HomeController(IEntryService entryService)
    {
        _entryService = entryService;
    }

    [HttpGet]
    public async Task<IActionResult> TestPage()
    {
        var entryViews = await _entryService.GetAllEntriesAsync();

        EntriesViewModel viewModel = new()
        {
            Entries = entryViews.ToList(),
            UsedTopics = entryViews.Select(v => (EntryTopic)v).ToList(),
        };


        return View("Index", viewModel);
    }
}
