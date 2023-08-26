using Diploma.BusinessLogic.AuthenticationHandlers.UserContext;
using Diploma.BusinessLogic.Repositories.DeliveryRepository;
using Diploma.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Diploma.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IUserContext _userContext;

        public DeliveryController(IDeliveryRepository deliveryRepository, IUserContext userContext)
        {
            _deliveryRepository = deliveryRepository;
            _userContext = userContext;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<DeliveryInformation>> GetDeliveryInfo(int id)
        {
            var deliveryInfo = await _deliveryRepository.GetDeliveryInfo(id);

            if (deliveryInfo == null)
            {
                return NotFound();
            }
            return Ok(deliveryInfo);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrUpdateDeliveryInfo(DeliveryInformation deliveryInfo)
        {
            var userId = _userContext.GetUserId();
            deliveryInfo.UserId = userId;

            await _deliveryRepository.AddOrUpdateDeliveryInfo(deliveryInfo);

            return Ok();
        }
    }
}
