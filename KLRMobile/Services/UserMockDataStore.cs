using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KLRMobile.Models;

namespace KLRMobile.Services
{
    public class UserMockDataStore : IDataStore<User>
    {
        readonly List<User> items;
        public UserMockDataStore() => items = new List<User>()
        {
            new User { Id = Guid.NewGuid().ToString(), EmailAddress = "test@tester.com", Name = "Test Guy", Password="123456"},
        };

        public Task<User> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetItemsPagedAsync(PagingParameterModel model)
        {
            //defaulting to 10 for now
            var pagedItems = items.Skip((model.PageNumber - 1) * 10).Take(10).ToList();
            return await Task.FromResult(pagedItems);
        }

        public async Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}