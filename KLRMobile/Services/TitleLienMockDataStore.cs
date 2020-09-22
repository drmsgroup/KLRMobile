using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KLRMobile.Models;

namespace KLRMobile.Services
{
    public class TitleLienMockDataStore : IDataStore<TitleLienResultItem>
    {
        readonly List<TitleLienResultItem> items;
        public TitleLienMockDataStore() => items = new List<TitleLienResultItem>()
        {
            new TitleLienResultItem { Id = Guid.NewGuid().ToString(), Debtor = "Smith, Smith", LienHolder ="John, Smith", VINNumber="12345678901234567", Description="this is a description", DateFiled=DateTime.Parse("10/12/2019"), FileNumber="20", Released=DateTime.Parse("10/12/2020")  },
        };
        public async Task<TitleLienResultItem> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<TitleLienResultItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}