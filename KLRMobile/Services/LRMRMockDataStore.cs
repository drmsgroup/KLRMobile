using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KLRMobile.Models;

namespace KLRMobile.Services
{
    public class LRMRMockDataStore : IDataStore<LRMRResultItem>
    {
        readonly List<LRMRResultItem> items;

        public LRMRMockDataStore() => items = new List<LRMRResultItem>()
        {
            new LRMRResultItem { Id = Guid.NewGuid().ToString(), FirstParty = "Smith, Smith", SecondParty="John, Smith", BookNumber="20", BookName="MARRIAGE", InstrumentType="MARRIAGE LICENSE", PageNumber="10", DateFiled=DateTime.Parse("10/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red" },
            new LRMRResultItem { Id = Guid.NewGuid().ToString(), FirstParty = "Johnson, Bob", SecondParty="Johnson, Jack", BookNumber="30", BookName="LAND", InstrumentType="DEED", PageNumber="20", DateFiled=DateTime.Parse("8/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red" },
            new LRMRResultItem { Id = Guid.NewGuid().ToString(), FirstParty = "Abrams, JJ", SecondParty="Abrams, John", BookNumber="40", BookName="LAND", InstrumentType="DEED", PageNumber="30", DateFiled=DateTime.Parse("7/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red" },
            new LRMRResultItem { Id = Guid.NewGuid().ToString(), FirstParty = "Dillon, Eddie", SecondParty="Dillon, Beth", BookNumber="50", BookName="LAND", InstrumentType="DEED", PageNumber="40", DateFiled=DateTime.Parse("6/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red" },
            new LRMRResultItem { Id = Guid.NewGuid().ToString(), FirstParty = "Gurrola, Ben", SecondParty="Gurrola, Capulan",BookNumber="60", BookName="MARRIAGE", InstrumentType="MARRIAGE LICENSE", PageNumber="50", DateFiled=DateTime.Parse("5/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red" },
            new LRMRResultItem { Id = Guid.NewGuid().ToString(), FirstParty = "Vance, Richard", SecondParty="Vance, Betty", BookNumber="70", BookName="MARRIAGE", InstrumentType="MARRIAGE LICENSE", PageNumber="60", DateFiled=DateTime.Parse("4/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red" },
            new LRMRResultItem { Id = Guid.NewGuid().ToString(), FirstParty = "LongLastNameExample, LongFirstName", SecondParty="LongLastNameExample, LongFirstName", BookName="LAND", InstrumentType="DEED", BookNumber="70", PageNumber="60", DateFiled=DateTime.Parse("4/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red" }
        };

        public async Task<LRMRResultItem> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<LRMRResultItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}