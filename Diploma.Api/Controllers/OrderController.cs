using Diploma.BusinessLogic.Repositories.OrderRepository;
using Diploma.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task<bool> PlaceOrder()
        {
            return await _orderRepository.PlaceOrder();
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderOverview>>> GetUserOrders()
        {
            var result = await _orderRepository.GetUserOrders();
            return Ok(result);
        }
    }
}
