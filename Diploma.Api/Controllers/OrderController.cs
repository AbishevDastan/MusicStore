using Diploma.BusinessLogic.Repositories.OrderRepository;
using Diploma.DTO.Order;
using Diploma.DTO.Orders;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Route("{orderId}")]
        public async Task<ActionResult<OrderDetails>> GetOrderDetails(int orderId)
        {
            var orderDetails = await _orderRepository.GetOrderDetails(orderId);

            if (orderDetails == null)
            {
                return NotFound();
            }

            return Ok(orderDetails);
        }

        [HttpPost]
        public async Task<bool> PlaceOrder()
        {
            return await _orderRepository.PlaceOrder();
        }

        //[HttpDelete]
        //[Route("{orderId}")]
        //public async Task<bool> CancelOrder(int orderId)
        //{
        //    return await _orderRepository.CancelOrder(orderId);
        //}

        [HttpPut]
        [Route("{orderId}")]
        public async Task<bool> CancelOrder(int orderId)
        {
            return await _orderRepository.CancelOrder(orderId);
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

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("admin/{orderId}")]
        public async Task<ActionResult<OrderDetails>> GetOrderDetailsForAdmin(int orderId)
        {
            var orderDetails = await _orderRepository.GetOrderDetailsForAdmin(orderId);
            if (orderDetails == null)
            {
                return NotFound();
            }
            return Ok(orderDetails);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("admin/{orderId}/approve")]
        public async Task<ActionResult> ApproveOrder(int orderId)
        {
            var result = await _orderRepository.ApproveOrder(orderId);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("admin/count")]
        public async Task<ActionResult<int>> GetOrdersCount()
        {
            return Ok(await _orderRepository.GetOrdersCount());
        }
    }
}
