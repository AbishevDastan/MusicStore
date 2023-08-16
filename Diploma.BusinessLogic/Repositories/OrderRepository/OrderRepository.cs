﻿using AutoMapper;
using Diploma.BusinessLogic.AuthenticationHandlers.UserContext;
using Diploma.BusinessLogic.Repositories.CartRepository;
using Diploma.BusinessLogic.Repositories.EmailRepository;
using Diploma.BusinessLogic.Repositories.ItemRepository;
using Diploma.BusinessLogic.Repositories.UserRepository;
using Diploma.DataAccess;
using Diploma.Domain.Entities;
using Diploma.DTO.Email;
using Diploma.DTO.Order;
using Diploma.DTO.Orders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Diploma.BusinessLogic.Repositories.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;
        private readonly ICartRepository _cartRepository;
        private readonly IUserContext _userContext;
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IEmailRepository _emailRepository;

        public OrderRepository(
            DataContext dataContext,
            ICartRepository cartRepository,
            IUserContext userContext,
            IItemRepository itemRepository,
            IMapper mapper,
            IUserRepository userRepository,
            IEmailRepository emailRepository)
        {
            _dataContext = dataContext;
            _cartRepository = cartRepository;
            _userContext = userContext;
            _itemRepository = itemRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _emailRepository = emailRepository;
        }

        public async Task<OrderDetails> GetOrderDetails(int orderId)
        {
            var order = await _dataContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item)
                .OrderByDescending(o => o.OrderDate)
                .FirstOrDefaultAsync(o => o.UserId == _userContext.GetUserId() && o.Id == orderId);

            return new OrderDetails
            {
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Status = order.Status,
                Items = order.OrderItems.Select(item => new ItemDetailsInOrder
                {
                    ItemId = item.Item.Id,
                    ImageUrl = item.Item.ImageUrl,
                    Quantity = item.Quantity,
                    Name = item.Item.Name,
                    TotalPrice = item.TotalPrice
                }).ToList()
            };
        }

        public async Task<List<OrderOverview>> GetOrdersForUser()
        {
            var orders = await _dataContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item)
                .Where(o => o.UserId == _userContext.GetUserId())
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            var orderOverviewList = new List<OrderOverview>();
            foreach (var order in orders)
            {
                var orderOverview = new OrderOverview
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    TotalPrice = order.TotalPrice,
                    Item = order.OrderItems.Any() ?
                    $"{order.OrderItems.First().Item.Name} and" +
                    $" {order.OrderItems.Count - 1} more..." :
                    order.OrderItems.First().Item.Name,
                    Status = order.Status
                };
                orderOverviewList.Add(orderOverview);
            }
            return orderOverviewList;
        }

        public async Task<bool> PlaceOrder()
        {
            decimal total = 0;
            var orderItems = new List<OrderItem>();

            var cartItems = await _cartRepository.GetCartItemsFromDatabase();
            foreach (var cartItem in cartItems)
            {
                var item = await _dataContext.Items.FindAsync(cartItem.ItemId);
                if (item == null || item.QuantityInStock < cartItem.Quantity)
                {
                    return false;
                }
                total += cartItem.Price * cartItem.Quantity;
                //item.SoldQuantity += cartItem.Quantity;
                //_dataContext.Items.Update(item);

                orderItems.Add(new OrderItem
                {
                    ItemId = cartItem.ItemId,
                    Quantity = cartItem.Quantity,
                    TotalPrice = cartItem.Price * cartItem.Quantity
                });
                item.QuantityInStock -= cartItem.Quantity;
                await _cartRepository.RemoveCartItemsFromDatabase(cartItem.ItemId);
            }

            var order = new Order
            {
                UserId = _userContext.GetUserId(),
                OrderDate = DateTime.Now,
                TotalPrice = total,
                OrderItems = orderItems,
                Status = OrderStatus.Pending
            };

            _dataContext.Orders.Add(order);
            await _dataContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CancelOrder(int orderId)
        {
            var order = await _dataContext.Orders.FindAsync(orderId);
            if (order.Status == OrderStatus.Canceled && order.Status == OrderStatus.Approved)
            {
                return false;
            }

            if (order.Status == OrderStatus.Pending)
            {
                order.Status = OrderStatus.Canceled;
                _dataContext.Orders.Update(order);
                await _dataContext.SaveChangesAsync();

                return true;
            }
            return false;
        }

        //public async Task<bool> DeleteOrder(int orderId)
        //{
        //    var order = await _dataContext.Orders.FindAsync(orderId);
        //    if (order.Status == OrderStatus.Pending)
        //    {
        //        _dataContext.Orders.Remove(order);
        //        await _dataContext.SaveChangesAsync();

        //        return true;
        //    }
        //    return false;
        //}

        //Admin Panel
        public async Task<List<OrderOverview>> GetAllOrders()
        {
            var orders = await _dataContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            var orderOverviewList = new List<OrderOverview>();
            foreach (var order in orders)
            {
                var orderOverview = new OrderOverview
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    TotalPrice = order.TotalPrice,
                    Item = order.OrderItems.Any() ?
                        $"{order.OrderItems.First().Item.Name} and" +
                        $" {order.OrderItems.Count - 1} more..." :
                        order.OrderItems.First().Item.Name,
                    Status = order.Status
                };
                orderOverviewList.Add(orderOverview);
            }

            return orderOverviewList;
        }

        public async Task<OrderDetails> GetOrderDetailsForAdmin(int orderId)
        {
            var order = await _dataContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Item)
                .OrderByDescending(o => o.OrderDate)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
            {
                return null;
            }

            var orderDetails = new OrderDetails
            {
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Items = order.OrderItems?.Select(item => new ItemDetailsInOrder
                {
                    ItemId = item.Item.Id,
                    ImageUrl = item.Item.ImageUrl,
                    Quantity = item.Quantity,
                    Name = item.Item.Name,
                    TotalPrice = item.TotalPrice
                }).ToList() ?? new List<ItemDetailsInOrder>()
            };

            return orderDetails;
        }

        public async Task ApproveOrder(int orderId)
        {
            var order = await _dataContext.Orders
                .Include(x => x.OrderItems)
                .FirstOrDefaultAsync(x => x.Id == orderId);

            if (order == null)
            {
                throw new NullReferenceException("The order is not found");
            }

            if (order.Status == OrderStatus.Approved)
            {
                return;
            }

            order.Status = OrderStatus.Approved;

            foreach (var orderItem in order.OrderItems)
            {
                var item = await _dataContext.Items.FindAsync(orderItem.ItemId);
                item.SoldQuantity += orderItem.Quantity;
                await _itemRepository.UpdateItemForOrder(item);
            }
            await _dataContext.SaveChangesAsync();

            var user = await _userRepository.GetUser(order.UserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            else
            {
                var email = new EmailDto()
                {
                    To = user.Email,
                    Subject = "Order Approved",
                    Body = $"Your order with ID {order.Id} has been approved. Thank you for shopping with us!"
                };
                _emailRepository.SendEmail(email);
            }
        }

        public async Task<int> GetOrdersCount()
        {
            return await _dataContext.Orders.CountAsync();
        }
    }
}
