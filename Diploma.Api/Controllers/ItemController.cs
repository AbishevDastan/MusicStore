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
        //[Route("/GetItems")]
        public async Task<ActionResult<ServiceResponse<List<Item>>>> GetItems()
        {
            var result = await _itemRepository.GetItems();
            return Ok(result);
        }
    }
}
