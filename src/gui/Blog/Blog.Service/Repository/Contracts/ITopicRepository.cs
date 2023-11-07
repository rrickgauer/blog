using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Repository.Contracts;

public interface ITopicRepository
{
    public Task<DataTable> SelectAllUsedAsync();
}
