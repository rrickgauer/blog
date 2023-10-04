using BlogPilot.Services.Service.Interface;
using System.Diagnostics;

namespace BlogPilot.Services.Service.Implementation;

public class WebService : IWebService
{
    private const string EntryUrlTemplate = @"https://blog.ryanrickgauer.com/entries/{0}";

    public bool ViewEntry(int entryId)
    {
        Uri url = new(string.Format(EntryUrlTemplate, entryId));

        return LaunchWebsite(url);
    }

    public bool LaunchWebsite(Uri url)
    {
        Process process = new();

        process.StartInfo.UseShellExecute = true;
        process.StartInfo.FileName = url.AbsoluteUri;

        return process.Start();
    }
}
