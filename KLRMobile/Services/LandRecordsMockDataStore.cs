using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KLRMobile.Models;

namespace KLRMobile.Services
{
    public class LandRecordsMockDataStore : IDataStore<LRMRResultItem>
    {
        readonly List<LRMRResultItem> items;
        readonly List<Entity> entities;

        public LandRecordsMockDataStore() {
            //these entities will need to be flattened in the API
            entities = new List<Entity> {
                new Entity { FirstName = "First", LastName = "Last", Id = Guid.NewGuid().ToString(), InstrumentId = 10000 },
                new Entity { FirstName = "First2", LastName = "Last2", Id = Guid.NewGuid().ToString(), InstrumentId = 10001 },
                new Entity { FirstName = "First3", LastName = "Last3", Id = Guid.NewGuid().ToString(), InstrumentId = 10002 },
                new Entity { FirstName = "First4", LastName = "Last4", Id = Guid.NewGuid().ToString(), InstrumentId = 10003 }
            };

            items = new List<LRMRResultItem> {
                new LRMRResultItem { Id = 10000, FirstParty = "Smith, Bob", SecondParty="Smith, Jack", BookNumber="30", BookName="LAND", InstrumentType="DEED", PageNumber="20", DateFiled=DateTime.Parse("8/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red" },
                new LRMRResultItem { Id = 10001, FirstParty = "Smith, Bob", SecondParty="Smith, John", BookNumber="40", BookName="LAND", InstrumentType="DEED", PageNumber="30", DateFiled=DateTime.Parse("7/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red" },
                new LRMRResultItem { Id = 10002, FirstParty = "Smith, Bob", SecondParty="Smith, Beth", BookNumber="50", BookName="LAND", InstrumentType="DEED", PageNumber="40", DateFiled=DateTime.Parse("6/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red" },
                new LRMRResultItem { Id = 10003, FirstParty = "LongLastNameExample, LongFirstName", SecondParty="LongLastNameExample, LongFirstName", BookName="LAND", InstrumentType="DEED", BookNumber="70", PageNumber="60", DateFiled=DateTime.Parse("4/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red" },
                new LRMRResultItem { Id = 10004, FirstParty = "Smith, Bob", SecondParty="Smith, Jack", BookNumber="30", BookName="LAND", InstrumentType="DEED", PageNumber="20", DateFiled=DateTime.Parse("8/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red" },
                new LRMRResultItem { Id = 10005, FirstParty = "Smith, Bob", SecondParty="Smith, John", BookNumber="40", BookName="LAND", InstrumentType="DEED", PageNumber="30", DateFiled=DateTime.Parse("7/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red" },
                new LRMRResultItem { Id = 10006, FirstParty = "Smith, Bob", SecondParty="Smith, Beth", BookNumber="50", BookName="LAND", InstrumentType="DEED", PageNumber="40", DateFiled=DateTime.Parse("6/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red" },
                new LRMRResultItem { Id = 10007, FirstParty = "LongLastNameExample, LongFirstName", SecondParty="LongLastNameExample, LongFirstName", BookName="LAND", InstrumentType="DEED", BookNumber="70", PageNumber="60", DateFiled=DateTime.Parse("4/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red" },
                new LRMRResultItem { Id = 10008, FirstParty = "Smith, Bob", SecondParty="Smith, Jack", BookNumber="30", BookName="LAND", InstrumentType="DEED", PageNumber="20", DateFiled=DateTime.Parse("8/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red" },
                new LRMRResultItem { Id = 10009, FirstParty = "Smith, Bob", SecondParty="Smith, John", BookNumber="40", BookName="LAND", InstrumentType="DEED", PageNumber="30", DateFiled=DateTime.Parse("7/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red" },
                new LRMRResultItem { Id = 10010, FirstParty = "Smith, Bob", SecondParty="Smith, Beth", BookNumber="50", BookName="LAND", InstrumentType="DEED", PageNumber="40", DateFiled=DateTime.Parse("6/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red" },
                new LRMRResultItem { Id = 10011, FirstParty = "Smith, Bob", SecondParty="Smith, LongFirstName", BookName="LAND", InstrumentType="DEED", BookNumber="70", PageNumber="60", DateFiled=DateTime.Parse("4/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red" },
                new LRMRResultItem { Id = 10011, FirstParty = "Smith, Bob", SecondParty="Smith, LongFirstName", BookName="LAND", InstrumentType="DEED", BookNumber="70", PageNumber="60", DateFiled=DateTime.Parse("4/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red" }
            };
        }

        public async Task<IEnumerable<LRMRResultItem>> GetItemsPagedAsync(PagingParameterModel model)
        {
            //defaulting to 10 for now
            var pagedItems = items.Skip((model.PageNumber - 1) * 10).Take(10).ToList();
            return await Task.FromResult(pagedItems);
        }

        public async Task<LRMRResultItem> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<LRMRResultItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}