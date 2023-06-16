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
            var items = await _dataContext.Items
                        .ToListAsync();
            return items;
        }

        public async Task<Item> GetItem(int itemId)
        {
            var item = await _dataContext.Items
                .FirstOrDefaultAsync(i => i.Id == itemId);

            return item;
        }

        public async Task<List<Item>> GetItemsByCategory(string categoryUrl)
        {
            var itemsByCategory = await _dataContext.Items
            .Where(i => i.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
            .ToListAsync();

            return itemsByCategory;
        }

        public async Task<List<Item>> SearchItem(string searchText)
        {
            var result = await _dataContext.Items
                .Where(i => i.Name.ToLower().Contains(searchText.ToLower())
                || 
                i.Description.ToLower().Contains(searchText.ToLower()))
                .ToListAsync();

            return result;
        }

        public async Task<List<Item>> FindItemsBySearchText(string searchText)
        {
            var result = await _dataContext.Items
                .Where(i => i.Name.ToLower().Contains(searchText.ToLower())
                ||
                i.Description.ToLower().Contains(searchText.ToLower()))
                .ToListAsync();

            return result;
        }
        
        public async Task<List<string>> GetItemSearchSuggestions(string searchText)
        {
            var items = await FindItemsBySearchText(searchText);

            List<string> result = new List<string>();

            foreach (var item in items)
            { 
                if(item.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(item.Name);
                }

                if (item.Description != null)
                {
                    var punctuation = item.Description.Where(char.IsPunctuation)
                        .Distinct().ToArray();
                    var words = item.Description.Split()
                        .Select(i => i.Trim(punctuation));

                    foreach (var word in words) 
                    {
                        if (word.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                            && !result.Contains(word))
                        {
                            result.Add(word);
                        }
                    }
                }
            }
            return new List<string> (result);

        }

        public async Task<List<Item>> GetFeatured()
        {
            var featured = await _dataContext.Items
                .Where(i => i.Featured)
                .ToListAsync();

            return featured;
        }
    }
}
        
    
