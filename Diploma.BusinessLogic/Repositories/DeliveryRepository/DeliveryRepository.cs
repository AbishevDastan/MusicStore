﻿using Diploma.BusinessLogic.AuthenticationHandlers.UserContext;
using Diploma.BusinessLogic.Repositories.OrderRepository;
using Diploma.DataAccess;
using Diploma.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Diploma.BusinessLogic.Repositories.DeliveryRepository
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly DataContext _dataContext;
        private readonly IUserContext _userContext;
        private readonly IOrderRepository _orderRepository;

        public DeliveryRepository(DataContext dataContext, IUserContext userContext, IOrderRepository orderRepository)
        {
            _dataContext = dataContext;
            _userContext = userContext;
            _orderRepository = orderRepository;
        }

        public async Task<List<DeliveryInformation>> GetDeliveryInfos()
        {
            var userId = _userContext.GetUserId();

            return await _dataContext.DeliveryInformations
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<DeliveryInformation> GetDeliveryInfo(int id)
        {
            var userId = _userContext.GetUserId();

            return await _dataContext.DeliveryInformations
                .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == id);
        }

        public async Task<DeliveryInformation> GetDeliveryInfoForAdmin(int id)
        {
            return await _dataContext.DeliveryInformations
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> AddOrUpdateDeliveryInfo(DeliveryInformation deliveryInfo)
        {
            var userId = _userContext.GetUserId();
            var existingDeliveryInfo = await _dataContext.DeliveryInformations.FirstOrDefaultAsync(x => x.UserId == userId && x.Id == deliveryInfo.Id);

            if (existingDeliveryInfo != null)
            {
                existingDeliveryInfo.Id = deliveryInfo.Id;
                existingDeliveryInfo.UserId = userId;
                existingDeliveryInfo.FirstName = deliveryInfo.FirstName;
                existingDeliveryInfo.LastName = deliveryInfo.LastName;
                existingDeliveryInfo.PhoneNumber = deliveryInfo.PhoneNumber;
                existingDeliveryInfo.Street = deliveryInfo.Street;
                existingDeliveryInfo.City = deliveryInfo.City;
                existingDeliveryInfo.State = deliveryInfo.State;
                existingDeliveryInfo.Country = deliveryInfo.Country;
                existingDeliveryInfo.ZipCode = deliveryInfo.ZipCode;
            }
            else
            {
                var newDeliveryInfo = new DeliveryInformation
                {
                    Id = deliveryInfo.Id,
                    UserId = userId,
                    FirstName = deliveryInfo.FirstName,
                    LastName = deliveryInfo.LastName,
                    PhoneNumber = deliveryInfo.PhoneNumber,
                    Street = deliveryInfo.Street,
                    City = deliveryInfo.City,
                    State = deliveryInfo.State,
                    Country = deliveryInfo.Country,
                    ZipCode = deliveryInfo.ZipCode
                };

                _dataContext.DeliveryInformations.Add(newDeliveryInfo);
            }

            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDeliveryInfo(int deliveryInfoId)
        {
            var deliveryInfo = await _dataContext.DeliveryInformations.FirstOrDefaultAsync(x => x.Id == deliveryInfoId);

            if (deliveryInfo != null)
            {
                _dataContext.DeliveryInformations.Remove(deliveryInfo);
                _dataContext.SaveChanges();

                return true;
            }
            else
            {
                throw new ApplicationException("The delivery information not found.");
            }
        }

        public async Task<int> GetDeliveryInfosCount()
        {
            return await _dataContext.DeliveryInformations
                .Where(x => x.UserId == _userContext.GetUserId())
                .CountAsync();
        }
    }
}
