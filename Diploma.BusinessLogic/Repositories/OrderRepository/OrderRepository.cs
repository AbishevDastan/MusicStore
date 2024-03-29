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
using Microsoft.EntityFrameworkCore;

namespace Diploma.BusinessLogic.Repositories.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;
        private readonly ICartRepository _cartRepository;
        private readonly IUserContext _userContext;
        private readonly IItemRepository _itemRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEmailRepository _emailRepository;

        public OrderRepository(
            DataContext dataContext,
            ICartRepository cartRepository,
            IUserContext userContext,
            IItemRepository itemRepository,
            IUserRepository userRepository,
            IEmailRepository emailRepository)
        {
            _dataContext = dataContext;
            _cartRepository = cartRepository;
            _userContext = userContext;
            _itemRepository = itemRepository;
            _userRepository = userRepository;
            _emailRepository = emailRepository;
        }

        public async Task<Order?> GetOrder(int? orderId)
        {
            return await _dataContext.Orders.FirstOrDefaultAsync(x => x.Id == orderId);
        }

        public async Task<bool> IsDeliveryInfoLinkedToOrders(int deliveryInfoId)
        {
            bool isLinked = await _dataContext.Orders.AnyAsync(x => x.DeliveryInformationId == deliveryInfoId);
            if (isLinked == true)
            {
                return true;
            }
            else
            {
                return false;
            }
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
                    Status = order.Status
                };
                orderOverviewList.Add(orderOverview);
            }
            return orderOverviewList;
        }

        public async Task<bool> PlaceOrder(int deliveryInfoId)
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
                Status = OrderStatus.Pending,
                DeliveryInformationId = deliveryInfoId,
            };

            _dataContext.Orders.Add(order);
            await _dataContext.SaveChangesAsync();

            var user = await GetCurrentUser(order.UserId);
            var email = new EmailDto()
            {
                To = user.Email,
                Subject = $"Order Confirmation - Order ID: {order.Id}",
                Body = $@"
                    <!DOCTYPE html>
                    <html lang=""en"">
                    <head>
                        <meta charset=""UTF-8"">
                        <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                        <title>Order Confirmation</title>
                    </head>
                    <body>
                        <div style=""font-family: Arial, sans-serif;"">
                            <h1>Order Confirmation</h1>
                            <p>Dear Customer,</p>
        
                            <p>Thank you for placing an order with the Music Store! The order has been received and is being processed.</p>
        
                            <p>Order Details:</p>
                            <ul>
                                <li>Order ID: {order.Id}</li>
                                <li>Order Date: {order.OrderDate}</li>
                                <li>Total Price: {order.TotalPrice}</li>
                            </ul>
        
                            <p>If you have any questions or need assistance, please feel free to contact our customer support team at musicstore7510@outlook.com or +1 234 567 890.</br></br>Thank you for choosing MusicStore!</p>
                            <p>Best regards,</br>The Music Store Team</p>""
                        </div>
                    </body>
                    </html>"
            };
            _emailRepository.SendEmail(email);
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
                throw new NullReferenceException("The order not found");
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

            var user = await GetCurrentUser(order.UserId);

            var email = new EmailDto()
            {
                To = user.Email,
                Subject = "Order Approved",
                Body = $@"
                    <!DOCTYPE html>
                    <html lang=""en"">
                    <head>
                        <meta charset=""UTF-8"">
                        <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                        <title>Order Approval</title>
                    </head>
                    <body>
                        <div style=""font-family: Arial, sans-serif;"">
                            <p>Dear Customer,</p>
        
                            <p>Your order with ID {order.Id} has been approved. Thank you for shopping with us!</p>
        
                            <p>Best regards,</br>The Music Store Team</p>""
                        </div>
                    </body>
                    </html>"
            };
            _emailRepository.SendEmail(email);
        }


        public async Task SetStatusToDelivered(int orderId)
        {
            var order = await _dataContext.Orders
               .FirstOrDefaultAsync(x => x.Id == orderId);

            if (order == null)
            {
                throw new NullReferenceException("The order not found");
            }
            else
            {
                order.Status = OrderStatus.Delivered;
                await _dataContext.SaveChangesAsync();
                var user = await GetCurrentUser(order.UserId);

                var email = new EmailDto()
                {
                    To = user.Email,
                    Subject = "Order Delivered",
                    Body = $@"
                    <!DOCTYPE html>
                    <html lang=""en"">
                    <head>
                        <meta charset=""UTF-8"">
                        <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
                        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                        <title>Order Delivery</title>
                    </head>
                    <body>
                        <div style=""font-family: Arial, sans-serif;"">
                            <p>Dear Customer,</p>
        
                            <p>Your order with ID {order.Id} has been delivered successfully. Thank you for shopping with us!</p>
        
                            <p>Best regards,</br>The Music Store Team</p>""
                        </div>
                    </body>
                    </html>"
                };
                _emailRepository.SendEmail(email);

            }
        }

        public async Task SetStatusToShipped(int orderId)
        {
            var order = await _dataContext.Orders
                .FirstOrDefaultAsync(x => x.Id == orderId);

            if (order == null)
            {
                throw new NullReferenceException("The order not found");
            }
            else
            {
                order.Status = OrderStatus.Shipped;
                await _dataContext.SaveChangesAsync();
                var user = await GetCurrentUser(order.UserId);

                var email = new EmailDto()
                {
                    To = user.Email,
                    Subject = "Order Shipment",
                    Body = $@"
                    <!DOCTYPE html>
                    <html lang=""en"">
                    <head>
                         <meta charset=""UTF-8"">
                         <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
                         <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                         <title>Order Shipment</title>
                    </head>
                    <body>
                        <div style=""font-family: Arial, sans-serif;"">
                             <p>Dear Customer,</p>
        
                             <p>Your order with ID {order.Id} has been shipped. Thank you for shopping with us!</p>
        
                             <p>Best regards,</br>The Music Store Team</p>""
                        </div>
                    </body>
                    </html>"
                };
                _emailRepository.SendEmail(email);
            }
        }

        public async Task<int> GetOrdersCount()
        {
            return await _dataContext.Orders.CountAsync();
        }

        public async Task<User> GetCurrentUser(int userId)
        {
            var user = await _userRepository.GetCurrentUserWithId(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            else
            {
                return user;
            }
        }
    }
}