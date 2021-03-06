﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KLRMobile.Models;

namespace KLRMobile.Services
{
    public class MarriageLicenseMockDataStore : IDataStore<LRMRResultItem>
    {
        readonly List<LRMRResultItem> items;
        readonly List<Entity> entities;

        public MarriageLicenseMockDataStore() { 
            // these entities will need to be flattened in the API
            entities = new List<Entity> {
                new Entity { FirstName = "First", LastName = "Last", Id = Guid.NewGuid().ToString(), InstrumentId = 10000 },
                new Entity { FirstName = "First2", LastName = "Last2", Id = Guid.NewGuid().ToString(), InstrumentId = 10001 },
                new Entity { FirstName = "First3", LastName = "Last3", Id = Guid.NewGuid().ToString(), InstrumentId = 10002 },
                new Entity { FirstName = "First4", LastName = "Last4", Id = Guid.NewGuid().ToString(), InstrumentId = 10003 }
            };
            // idea here is to have a FirstParty and SecondParty with all the names you need separated by \r\n
            items = new List<LRMRResultItem> {
                new LRMRResultItem { Entities = entities, Id = 10000, FirstParty = "Smith, Smith \r\n Smith, Bob", SecondParty="John, Smith \r\n Smith, Suzanne", BookNumber="20", BookName="MARRIAGE", InstrumentType="MARRIAGE LICENSE", PageNumber="10", DateFiled=DateTime.Parse("10/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red", HasImage = "image-unavailable" },
                new LRMRResultItem { Entities = entities, Id = 10001, FirstParty = "Smith, Ben", SecondParty="Smith, Smith",BookNumber="60", BookName="MARRIAGE", InstrumentType="MARRIAGE LICENSE", PageNumber="50", DateFiled=DateTime.Parse("5/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red", HasImage = "image-available" },
                new LRMRResultItem { Entities = entities, Id = 10002, FirstParty = "Smith, Richard", SecondParty="Smith, Betty", BookNumber="70", BookName="MARRIAGE", InstrumentType="MARRIAGE LICENSE", PageNumber="60", DateFiled=DateTime.Parse("4/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red", HasImage = "image-available" },
                new LRMRResultItem { Entities = entities, Id = 10003, FirstParty = "Smith, Smith \r\n Smith, Bob", SecondParty="John, Smith \r\n Smith, Suzanne", BookNumber="20", BookName="MARRIAGE", InstrumentType="MARRIAGE LICENSE", PageNumber="10", DateFiled=DateTime.Parse("10/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red", HasImage = "image-available" },
                new LRMRResultItem { Entities = entities, Id = 10004, FirstParty = "Smith, Ben", SecondParty="Gurrola, Smith",BookNumber="60", BookName="MARRIAGE", InstrumentType="MARRIAGE LICENSE", PageNumber="50", DateFiled=DateTime.Parse("5/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red", HasImage = "image-unavailable" },
                new LRMRResultItem { Entities = entities, Id = 10005, FirstParty = "Smith, Richard", SecondParty="Smith, Betty", BookNumber="70", BookName="MARRIAGE", InstrumentType="MARRIAGE LICENSE", PageNumber="60", DateFiled=DateTime.Parse("4/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red", HasImage = "image-unavailable" },
                new LRMRResultItem { Entities = entities, Id = 10006, FirstParty = "Smith, Smith \r\n Smith, Bob", SecondParty="John, Smith \r\n Smith, Suzanne", BookNumber="20", BookName="MARRIAGE", InstrumentType="MARRIAGE LICENSE", PageNumber="10", DateFiled=DateTime.Parse("10/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red", HasImage = "image-available" },
                new LRMRResultItem { Entities = entities, Id = 10007, FirstParty = "Smith, Ben", SecondParty="Gurrola, Smith",BookNumber="60", BookName="MARRIAGE", InstrumentType="MARRIAGE LICENSE", PageNumber="50", DateFiled=DateTime.Parse("5/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red", HasImage = "image-unavailable" },
                new LRMRResultItem { Entities = entities, Id = 10008, FirstParty = "Smith, Richard", SecondParty="Vance, Smith", BookNumber="70", BookName="MARRIAGE", InstrumentType="MARRIAGE LICENSE", PageNumber="60", DateFiled=DateTime.Parse("4/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red", HasImage = "image-available" },
                new LRMRResultItem { Entities = entities, Id = 10009, FirstParty = "Smith, Smith \r\n Smith, Bob", SecondParty="John, Smith \r\n Smith, Suzanne", BookNumber="20", BookName="MARRIAGE", InstrumentType="MARRIAGE LICENSE", PageNumber="10", DateFiled=DateTime.Parse("10/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red", HasImage = "image-available" },
                new LRMRResultItem { Entities = entities, Id = 10010, FirstParty = "Smith, Ben", SecondParty="Gurrola, Smith",BookNumber="60", BookName="MARRIAGE", InstrumentType="MARRIAGE LICENSE", PageNumber="50", DateFiled=DateTime.Parse("5/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red", HasImage = "image-unavailable" },
                new LRMRResultItem { Entities = entities, Id = 10011, FirstParty = "Vance, Richard", SecondParty="Vance, Betty", BookNumber="70", BookName="MARRIAGE", InstrumentType="MARRIAGE LICENSE", PageNumber="60", DateFiled=DateTime.Parse("4/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), UpdatedBy="red", Description="test", IndexedBy="red", HasImage = "image-available" }
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