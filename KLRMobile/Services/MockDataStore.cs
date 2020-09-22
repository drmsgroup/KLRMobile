using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KLRMobile.Models;

namespace KLRMobile.Services
{
    public class MockDataStore : IDataStore<ResultItem>
    {
        readonly List<ResultItem> items;

        public MockDataStore() => items = new List<ResultItem>()
            {
                new ResultItem { Id = Guid.NewGuid().ToString(), FirstParty = "Smith, Smith", SecondParty="John, Smith", BookNumber="20", PageNumber="10", DateFiled=DateTime.Parse("10/12/2019") },
                new ResultItem { Id = Guid.NewGuid().ToString(), FirstParty = "Johnson, Bob", SecondParty="Johnson, Jack", BookNumber="30", PageNumber="20", DateFiled=DateTime.Parse("8/12/2019") },
                new ResultItem { Id = Guid.NewGuid().ToString(), FirstParty = "Abrams, JJ", SecondParty="Abrams, John", BookNumber="40", PageNumber="30", DateFiled=DateTime.Parse("7/12/2019") },
                new ResultItem { Id = Guid.NewGuid().ToString(), FirstParty = "Dillon, Eddie", SecondParty="Dillon, Beth", BookNumber="50", PageNumber="40", DateFiled=DateTime.Parse("6/12/2019") },
                new ResultItem { Id = Guid.NewGuid().ToString(), FirstParty = "Gurrola, Ben", SecondParty="Gurrola, Capulan",BookNumber="60", PageNumber="50", DateFiled=DateTime.Parse("5/12/2019") },
                new ResultItem { Id = Guid.NewGuid().ToString(), FirstParty = "Vance, Richard", SecondParty="Vance, Betty", BookNumber="70", PageNumber="60", DateFiled=DateTime.Parse("4/12/2019") },
                new ResultItem { Id = Guid.NewGuid().ToString(), FirstParty = "LongLastNameExample, LongFirstName", SecondParty="LongLastNameExample, LongFirstName", BookNumber="70", PageNumber="60", DateFiled=DateTime.Parse("4/12/2019") }
            };

        public async Task<bool> AddItemAsync(ResultItem item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ResultItem item)
        {
            var oldItem = items.Where((ResultItem arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ResultItem arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ResultItem> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ResultItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}