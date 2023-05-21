using Diploma.DataAccess;
using Diploma.Domain;
using Diploma.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.BusinessLogic.Repositories.ItemRepository
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext _dataContext;

        public ItemRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Item>> GetItems()
        {
            //var response = new ServiceResponse<List<Item>>
            //{
            //    Data = await _dataContext.Items
            //        .Include(p => p.Variants)
            //        .ToListAsync()
            //};
            var items = await _dataContext.Items
                        .Include(i => i.Variants)
                        .ToListAsync();
            return items;
            //return response;
        }

        public async Task<Item> GetItem(int itemId)
        {
            var item = await _dataContext.Items
                .Include(i => i.Variants)
                .ThenInclude(v => v.ItemType)
                .FirstOrDefaultAsync(i => i.Id == itemId);

            return item;
        }

        public async Task<List<Item>> GetItemsByCategory(string categoryUrl)
        {
            var itemsByCategory = await _dataContext.Items
            .Where(i => i.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
            .Include(i => i.Variants)
            .ToListAsync();

            return itemsByCategory;
        }
    }
}
        
    
