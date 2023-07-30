using Diploma.BusinessLogic.Repositories.OrderRepository;
using Diploma.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
        public async Task<ActionResult<List<OrderOverview>>> GetOrdersForUser()
        {
            var result = await _orderRepository.GetOrdersForUser();
            return Ok(result);
        }

        //Admin Panel

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("admin")]
        public async Task<ActionResult> GetOrdersForAdmin()
        {
            var orders = await _orderRepository.GetAllOrders();
            return Ok(orders);
        }
    }
}
