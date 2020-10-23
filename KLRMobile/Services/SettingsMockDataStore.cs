using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KLRMobile.Models;

namespace KLRMobile.Services
{
    public class SettingsMockDataStore : IDataStore<County>
    {
        readonly List<County> items;
        public SettingsMockDataStore() => items = new List<County>()
        {
            new County { Id = Guid.NewGuid().ToString(), ConnectionString = "1234567890", Name = "Graves"},
            new County { Id = Guid.NewGuid().ToString(), ConnectionString = "1234567890", Name = "Marshall"},
            new County { Id = Guid.NewGuid().ToString(), ConnectionString = "1234567890", Name = "McCracken"},
            new County { Id = Guid.NewGuid().ToString(), ConnectionString = "1234567890", Name = "Calloway"}
        };

        public Task<County> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<County>> GetItemsPagedAsync(PagingParameterModel model)
        {
            //defaulting to 10 for now
            var pagedItems = items.Skip((model.PageNumber - 1) * 10).Take(10).ToList();
            return await Task.FromResult(pagedItems);
        }

        public async Task<IEnumerable<County>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}