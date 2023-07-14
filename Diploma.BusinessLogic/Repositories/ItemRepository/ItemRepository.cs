using AutoMapper;
using Diploma.DataAccess;
using Diploma.Domain.Entities;
using Diploma.DTO;
using Microsoft.EntityFrameworkCore;

namespace Diploma.BusinessLogic.Repositories.ItemRepository
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public ItemRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<List<ItemDto>> GetItems()
        {
            var items = await _dataContext.Items.ToListAsync();
            var itemsDto = _mapper.Map<List<ItemDto>>(items);

            return itemsDto;
        }

        public async Task<ItemDto> GetItem(int itemId)
        {
            var item = await _dataContext.Items.FindAsync(itemId);
            var itemDto = _mapper.Map<ItemDto>(item);

            return itemDto;
        }

        public async Task<List<ItemDto>> GetItemsByCategory(string categoryUrl)
        {
            var itemsByCategory = await _dataContext.Items
            .Where(i => i.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
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

        //Admin Panel
        public async Task<List<ItemDto>> GetAdminItems()
        {
            var items = await _dataContext.Items.ToListAsync();
            var itemsDto = _mapper.Map<List<ItemDto>>(items);

            return itemsDto;
        }

        public async Task<ItemDto> CreateItem(ItemDto itemDto)
        {
            var item = new Item
            {
                Name = itemDto.Name,
                Description = itemDto.Description,
                ImageUrl = itemDto.ImageUrl,
                Price = itemDto.Price,
                CategoryId = itemDto.CategoryId
            };

            _dataContext.Items.Add(item);
            await _dataContext.SaveChangesAsync();

            itemDto = _mapper.Map<ItemDto>(item);

            return itemDto;
        }

        public async Task<bool> DeleteItem(int itemId)
        {
            var item = await _dataContext.Items.FindAsync(itemId);
            if (item == null)
            {
                return false;
            }
            _dataContext.Items.Remove(item);
            await _dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<ItemDto?> UpdateItem(int itemId, ItemDto itemDto)
        {
            var item = await _dataContext.Items.FindAsync(itemId);

            if (item != null)
            {
                item.Name = itemDto.Name;
                item.Description = itemDto.Description;
                item.CategoryId = itemDto.CategoryId;
                item.ImageUrl = itemDto.ImageUrl;

                await _dataContext.SaveChangesAsync();
            }
            itemDto = _mapper.Map<ItemDto>(item);

            return itemDto;
        }
    }
}


