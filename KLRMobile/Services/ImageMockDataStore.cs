using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using KLRMobile.Models;

namespace KLRMobile.Services
{
    public class ImageMockDataStore : IDataStore<Image>
    {
        readonly List<Image> items;
        public ImageMockDataStore() => items = new List<Image>()
        {
            new Image { Id = 10000, imageStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("KLRMobile.Assets.mortgage.pdf"), InstrumentId = 10000 }
        };

        public async Task<IEnumerable<Image>> GetItemsPagedAsync(PagingParameterModel model)
        {
            //defaulting to 10 for now
            var pagedItems = items.Skip((model.PageNumber - 1) * 10).Take(10).ToList();
            return await Task.FromResult(pagedItems);
        }

        public async Task<Image> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Image>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}