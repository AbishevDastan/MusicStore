using AutoMapper;
using Diploma.BusinessLogic.Repositories.ItemRepository;
using Diploma.DataAccess;
using Diploma.Domain;
using Diploma.Domain.Entities;
using Diploma.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemController(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Item>>> GetItems()
        {
            var items = await _itemRepository.GetItems();
            var itemsDTO = _mapper.Map<List<ItemDTO>>(items);

            return Ok(itemsDTO);
        }

        [HttpGet]
        [Route("{itemId}")]
        public async Task<ActionResult<Item>> GetItem(int itemId)
        {
            var item = await _itemRepository.GetItem(itemId);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                var itemDTO = _mapper.Map<ItemDTO>(item);
                return Ok(itemDTO);
            }
        }

        [HttpGet]
        [Route("category/{categoryUrl}")]
        public async Task<ActionResult<List<Item>>> GetItemsByCategory(string categoryUrl)
        { 
            var itemsByCategory = await _itemRepository.GetItemsByCategory(categoryUrl);
            var itemsByCategoryDTO = _mapper.Map<List<ItemDTO>>(itemsByCategory);
            
            return Ok(itemsByCategoryDTO);
        }

        [HttpGet]
        [Route("search/{searchText}")]
        public async Task<ActionResult<List<Item>>> SearchItem(string searchText)
        {
            var search = await _itemRepository.SearchItem(searchText);
            var searchItemDTO = _mapper.Map<List<ItemDTO>>(search);

            return Ok(searchItemDTO);
        }

        [HttpGet]
        [Route("searchsuggestions/{searchText}")]
        public async Task<ActionResult<List<Item>>> GetItemSearchSuggestions(string searchText)
        {
            var search = await _itemRepository.GetItemSearchSuggestions(searchText);

            return Ok(search);
        }
    }
}
