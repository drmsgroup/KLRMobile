using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KLRMobile.Models;
using Xamarin.Forms;

namespace KLRMobile.Services
{
    public class TitleLienMockDataStore : IDataStore<TitleLienResultItem>
    {
        readonly List<TitleLienResultItem> items;

        public TitleLienMockDataStore()
        {
            items = new List<TitleLienResultItem>() {
                new TitleLienResultItem { Id = 10000, DebtorLast = "Smith", DebtorFirst = "John", LienHolder ="John, Smith", TitleNumber="1234567890", VINNumber="12345678901234567", Description="this is a description", DateFiled=DateTime.Parse("10/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), FileNumber="20", SecurityType="Test", SecurityId="1234567890", HasImage = "image-unavailable" },
                new TitleLienResultItem { Id = 10001, DebtorLast = "Smith", DebtorFirst = "John", LienHolder ="John, Smith", TitleNumber="1234567890", VINNumber="12345678901234567", Description="this is a description", DateFiled=DateTime.Parse("10/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), FileNumber="20", SecurityType="Test", SecurityId="1234567890", HasImage = "image-available" },
                new TitleLienResultItem { Id = 10002, DebtorLast = "Smith", DebtorFirst = "John", LienHolder ="John, Smith", TitleNumber="1234567890", VINNumber="12345678901234567", Description="this is a description", DateFiled=DateTime.Parse("10/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), FileNumber="20", SecurityType="Test", SecurityId="1234567890", HasImage = "image-available" },
                new TitleLienResultItem { Id = 10003, DebtorLast = "Smith", DebtorFirst = "John", LienHolder ="John, Smith", TitleNumber="1234567890", VINNumber="12345678901234567", Description="this is a description", DateFiled=DateTime.Parse("10/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), FileNumber="20", SecurityType="Test", SecurityId="1234567890", HasImage = "image-unavailable" },
                new TitleLienResultItem { Id = 10004, DebtorLast = "Smith", DebtorFirst = "John", LienHolder ="John, Smith", TitleNumber="1234567890", VINNumber="12345678901234567", Description="this is a description", DateFiled=DateTime.Parse("10/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), FileNumber="20", SecurityType="Test", SecurityId="1234567890", HasImage = "image-available" },
                new TitleLienResultItem { Id = 10005, DebtorLast = "Smith", DebtorFirst = "John", LienHolder ="John, Smith", TitleNumber="1234567890", VINNumber="12345678901234567", Description="this is a description", DateFiled=DateTime.Parse("10/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), FileNumber="20", SecurityType="Test", SecurityId="1234567890", HasImage = "image-available" },
                new TitleLienResultItem { Id = 10006, DebtorLast = "Smith", DebtorFirst = "John", LienHolder ="John, Smith", TitleNumber="1234567890", VINNumber="12345678901234567", Description="this is a description", DateFiled=DateTime.Parse("10/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), FileNumber="20", SecurityType="Test", SecurityId="1234567890", HasImage = "image-unavailable" },
                new TitleLienResultItem { Id = 10007, DebtorLast = "Smith", DebtorFirst = "John", LienHolder ="John, Smith", TitleNumber="1234567890", VINNumber="12345678901234567", Description="this is a description", DateFiled=DateTime.Parse("10/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), FileNumber="20", SecurityType="Test", SecurityId="1234567890", HasImage = "image-available" },
                new TitleLienResultItem { Id = 10008, DebtorLast = "Smith", DebtorFirst = "John", LienHolder ="John, Smith", TitleNumber="1234567890", VINNumber="12345678901234567", Description="this is a description", DateFiled=DateTime.Parse("10/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), FileNumber="20", SecurityType="Test", SecurityId="1234567890", HasImage = "image-unavailable" },
                new TitleLienResultItem { Id = 10009, DebtorLast = "Smith", DebtorFirst = "John", LienHolder ="John, Smith", TitleNumber="1234567890", VINNumber="12345678901234567", Description="this is a description", DateFiled=DateTime.Parse("10/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), FileNumber="20", SecurityType="Test", SecurityId="1234567890", HasImage = "image-available" },
                new TitleLienResultItem { Id = 10010, DebtorLast = "Smith", DebtorFirst = "John", LienHolder ="John, Smith", TitleNumber="1234567890", VINNumber="12345678901234567", Description="this is a description", DateFiled=DateTime.Parse("10/12/2019"), LastUpdated=DateTime.Parse("10/12/2019"), FileNumber="20", SecurityType="Test", SecurityId="1234567890", HasImage = "image-available" }
            };
        }

        public async Task<TitleLienResultItem> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<TitleLienResultItem>> GetItemsPagedAsync(PagingParameterModel model)
        {
            //defaulting to 10 for now
            var pagedItems = items.Skip((model.PageNumber - 1) * 10).Take(10).ToList();
            return await Task.FromResult(pagedItems);
        }

        public async Task<IEnumerable<TitleLienResultItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}