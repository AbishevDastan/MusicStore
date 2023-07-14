using AutoMapper;
using Diploma.BusinessLogic.Repositories.ItemRepository;
using Diploma.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<List<ItemDto>> GetItems()
        {
            return await _itemRepository.GetItems();
        }

        [HttpGet]
        [Route("{itemId}")]
        public async Task<ItemDto?> GetItem(int id)
        {
            return await _itemRepository.GetItem(id);
        }

        [HttpGet]
        [Route("category/{categoryUrl}")]
        public async Task<ActionResult<List<ItemDto>>> GetItemsByCategory(string categoryUrl)
        {
            var itemsByCategoryDto = await _itemRepository.GetItemsByCategory(categoryUrl);

            return Ok(itemsByCategoryDto);
        }

        [HttpGet]
        [Route("search/{searchText}")]
        public async Task<ActionResult<List<ItemDto>>> SearchItem(string searchText)
        {
            var searchItemDto = await _itemRepository.SearchItem(searchText);

            return Ok(searchItemDto);
        }

        [HttpGet]
        [Route("searchsuggestions/{searchText}")]
        public async Task<ActionResult<List<ItemDto>>> GetItemSearchSuggestions(string searchText)
        {
            var search = await _itemRepository.GetItemSearchSuggestions(searchText);

            return Ok(search);
        }

        //Admin Panel
        [HttpGet]
        [Route("admin")]
        [Authorize(Roles = "Admin")]
        public async Task<List<ItemDto>> GetAdminItems()
        {
            return await _itemRepository.GetAdminItems();
        }

        [HttpPost]
        [Route("admin")]
        [Authorize(Roles = "Admin")]
        public async Task<ItemDto?> CreateItem(ItemDto itemDto)
        {
            return await _itemRepository.CreateItem(itemDto);
        }

        [HttpDelete]
        [Route("admin/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> RemoveItem(int itemId)
        {
            return await _itemRepository.DeleteItem(itemId);
        }

        [HttpPut]
        [Route("admin")]
        [Authorize(Roles = "Admin")]
        public async Task<ItemDto?> UpdateItem(int id, ItemDto itemDto)
        {
            return await _itemRepository.UpdateItem(id, itemDto);
        }
    }
}
