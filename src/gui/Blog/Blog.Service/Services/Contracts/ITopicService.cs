using Blog.Service.Domain.Enum;
using Blog.Service.Domain.Model;
using Blog.Service.Domain.TableView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Contracts;

public interface ITopicService
{
    public Task<IEnumerable<TopicTableView>> GetUsedTopicsAsync();
}