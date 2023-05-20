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
            var itemDTOs = _mapper.Map<List<ItemDTO>>(items);

            return Ok(itemDTOs);
        }

        [HttpGet]
        [Route("{itemId}")]
        public async Task<ActionResult<ServiceResponse<Item>>> GetItem(int itemId)
        {
            var result = await _itemRepository.GetItem(itemId);
            return Ok(result);
        }

        [HttpGet]
        [Route("category/{categoryUrl}")]
        public async Task<ActionResult<ServiceResponse<List<Item>>>> GetItemsByCategory(string categoryUrl)
        { 
            var result = await _itemRepository.GetItemsByCategory(categoryUrl);
            return Ok(result);
        }
    }
}
