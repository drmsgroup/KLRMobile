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
            new User { Id = Guid.NewGuid().ToString(), EmailAddress = "test@tester.com", Name = "Test Guy"},
        };

        public Task<User> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}