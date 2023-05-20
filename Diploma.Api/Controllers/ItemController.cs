using Diploma.BusinessLogic.Repositories.ItemRepository;
using Diploma.DataAccess;
using Diploma.Domain;
using Diploma.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<ServiceResponse<List<Item>>>> GetItems()
        {
            var result = await _itemRepository.GetItems();
            return Ok(result);
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
