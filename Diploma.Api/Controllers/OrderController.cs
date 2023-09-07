using Diploma.BusinessLogic.Repositories.OrderRepository;
using Diploma.Domain.Entities;
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
        [Route("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _orderRepository.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet]
        [Route("{deliveryInfoId}/is-linked")]
        public async Task<bool> IsDeliveryInfoLinkedToOrders(int deliveryInfoId)
        {
            return await _orderRepository.IsDeliveryInfoLinkedToOrders(deliveryInfoId);
        }

        [HttpGet]
        [Route("{orderId}/details")]
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
        [Route("{deliveryInfoId}")]
        public async Task<bool> PlaceOrder(int deliveryInfoId)
        {
            return await _orderRepository.PlaceOrder(deliveryInfoId);
        }

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
        [Route("admin/{orderId}/details")]
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
        public async Task ApproveOrder(int orderId)
        {
            await _orderRepository.ApproveOrder(orderId);
        }

        [HttpPost]
        [Route("admin/{orderId}/set-to-shipped")]
        public async Task SetStatusToShipped(int orderId)
        {
            await _orderRepository.SetStatusToShipped(orderId);
        }

        [HttpPost]
        [Route("admin/{orderId}/set-to-delivered")]
        public async Task SetStatusToDelivered(int orderId)
        {
            await _orderRepository.SetStatusToDelivered(orderId);
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
