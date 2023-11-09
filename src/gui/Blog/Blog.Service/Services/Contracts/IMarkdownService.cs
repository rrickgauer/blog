using Blog.Service.Domain.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Contracts;

public interface IMarkdownService
{
    public string GetEntryHtml(string entryFileName);
}
