using AutoMapper;
using Diploma.DataAccess;
using Diploma.Domain;
using Diploma.Domain.Entities;
using Diploma.DTO;
using Microsoft.AspNetCore.Http;
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
        private readonly IMapper _mapper;
        //private readonly IHttpContextAccessor _httpContextAccessor;

        public ItemRepository(DataContext dataContext, IMapper mapper /*IHttpContextAccessor httpContextAccessor*/)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            //_httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<ItemDto>> GetItems()
        {
            var items = await _dataContext.Items
                /*.Where(i => !i.IsRemoved && i.IsVisible)*/
                .ToListAsync();
            var itemsDto = _mapper.Map<List<ItemDto>>(items);

            return itemsDto;
        }

        public async Task<ItemDto> GetItem(int itemId)
        {
            //Item item = null;

            //if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            //{
            //    item = await _dataContext.Items.FirstOrDefaultAsync(i => i.Id == itemId && !i.IsRemoved);
            //}
            //else
            //{
            //     item = await _dataContext.Items.FirstOrDefaultAsync(i => i.Id == itemId && !i.IsRemoved && i.IsVisible);
            //}


            var item = await _dataContext.Items.FirstOrDefaultAsync(i => i.Id == itemId /*&& !i.IsRemoved && i.IsVisible*/);
            var itemDto = _mapper.Map<ItemDto>(item);

            return itemDto;
        }

        public async Task<List<ItemDto>> GetItemsByCategory(string categoryUrl)
        {
            var itemsByCategory = await _dataContext.Items
            .Where(i => i.Category.Url.ToLower().Equals(categoryUrl.ToLower()) /*&& !i.IsRemoved && i.IsVisible*/)
            .ToListAsync();

            var itemsByCategoryDto = _mapper.Map<List<ItemDto>>(itemsByCategory);

            return itemsByCategoryDto;
        }

        public async Task<List<ItemDto>> SearchItem(string searchText)
        {
            var searchItem = await _dataContext.Items
                .Where(i => i.Name.ToLower().Contains(searchText.ToLower())
                ||
                i.Description.ToLower().Contains(searchText.ToLower()) /*&& !i.IsRemoved && i.IsVisible*/)
                .ToListAsync();

            var searchItemDto = _mapper.Map<List<ItemDto>>(searchItem);

            return searchItemDto;
        }

        public async Task<List<ItemDto>> FindItemsBySearchText(string searchText)
        {
            var result = await _dataContext.Items
                .Where(i => i.Name.ToLower().Contains(searchText.ToLower())
                ||
                i.Description.ToLower().Contains(searchText.ToLower()) /*&& !i.IsRemoved && i.IsVisible*/)
                .ToListAsync();

            var resultDto = _mapper.Map<List<ItemDto>>(result);

            return resultDto;
        }

        public async Task<List<string>> GetItemSearchSuggestions(string searchText)
        {
            var items = await FindItemsBySearchText(searchText);

            List<string> result = new List<string>();

            foreach (var item in items)
            {
                if (item.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase))
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
            return new List<string>(result);
        }

        public async Task<List<ItemDto>> GetFeatured()
        {
            var featured = await _dataContext.Items
                .Where(i => i.Featured /*&& !i.IsRemoved && i.IsVisible*/)
                .ToListAsync();

            var featuredDto = _mapper.Map<List<ItemDto>>(featured);

            return featuredDto;
        }


        //Admin Panel
        //public async Task<List<ItemDto>> GetAdminItems()
        //{
        //    var items = await _dataContext.Items
        //        .Where(i => !i.IsRemoved)
        //        .ToListAsync();

        //    var itemsDto = _mapper.Map<List<ItemDto>>(items);

        //    return itemsDto;
        //}

        //public async Task<bool> RemoveItem(int itemId)
        //{
        //    var item = await _dataContext.Items.FindAsync(itemId);

        //    item.IsRemoved = true;

        //    _dataContext.Items.Remove(item);
        //    await _dataContext.SaveChangesAsync();

        //    return true;
        //}

        //public async Task<ItemDto> UpdateItem(Item item)
        //{
        //    var dbItem = await _dataContext.Items.FindAsync(item.Id);

        //    dbItem.Name = item.Name;
        //    dbItem.Description = item.Description;
        //    dbItem.CategoryId = item.CategoryId;
        //    dbItem.Image = item.Image;
        //    dbItem.IsVisible = item.IsVisible;

        //    await _dataContext.SaveChangesAsync();

        //    var itemDto = _mapper.Map<ItemDto>(item);

        //    return itemDto;
        //}

        //public async Task<ItemDto> AddItem(Item item)
        //{
        //    _dataContext.Items.Add(item);
        //    await _dataContext.SaveChangesAsync();

        //    var itemDto = _mapper.Map<ItemDto>(item);
        //    return itemDto;
        //}
    }
}


