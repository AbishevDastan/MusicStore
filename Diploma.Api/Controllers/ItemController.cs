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
        public async Task<ActionResult<List<ItemDto>>> GetItems()
        {
            var itemsDto = await _itemRepository.GetItems();
            
            return Ok(itemsDto);
        }

        [HttpGet]
        [Route("{itemId}")]
        public async Task<ActionResult<ItemDto>> GetItem(int itemId)
        {
            var itemDto = await _itemRepository.GetItem(itemId);
            if (itemDto == null)
            {
                return NotFound();
            }
  
            return Ok(itemDto);
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

        [HttpGet]
        [Route("featured")]
        public async Task<ActionResult<List<ItemDto>>> GetFeatured()
        {
            var featuredDto = await _itemRepository.GetFeatured();
            
            return Ok(featuredDto);
        }
    }
}
