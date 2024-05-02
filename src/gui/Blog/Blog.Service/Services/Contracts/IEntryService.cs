﻿using Blog.Service.Domain.Model;
using Blog.Service.Domain.TableView;

namespace Blog.Service.Services.Contracts;

public interface IEntryService
{
    public Task<List<EntryTableView>> GetAllEntriesAsync();
    public Task<EntryTableView?> GetEntryAsync(uint entryId);
    public Task<EntryTableView?> GetEntryAsync(int entryId);
    public Task<EntryTableView?> SaveEntryAsync(Entry entry);

    public Task<int> DeleteEntryAsync(uint entryId);
    public Task<int> DeleteEntryAsync(int entryId);
}
