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
        private readonly DataContext _dataContext;

        public ItemController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Item>>>> GetItem()
        {
            var items = await _dataContext.Items.ToListAsync();
            var response = new ServiceResponse<List<Item>>()
            {
                Data = items
            };
            return Ok(response);
        }
    }
}
