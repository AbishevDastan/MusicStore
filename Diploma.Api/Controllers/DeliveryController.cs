using Diploma.BusinessLogic.AuthenticationHandlers.UserContext;
using Diploma.BusinessLogic.Repositories.DeliveryRepository;
using Diploma.Domain.Entities;
using Diploma.DTO.DeliveryInfo;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<List<DeliveryInformation>>> GetDeliveryInfos()
        {
            var deliveryInfos = await _deliveryRepository.GetDeliveryInfos();
            if (deliveryInfos == null)
            {
                return NotFound();
            }
            return Ok(deliveryInfos);
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

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("admin/{id}")]
        public async Task<ActionResult<DeliveryInformation>> GetDeliveryInfoForAdmin(int id)
        {
            var deliveryInfo = await _deliveryRepository.GetDeliveryInfoForAdmin(id);

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

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteDeliveryInfo(int id)
        {
            return Ok(await _deliveryRepository.DeleteDeliveryInfo(id));
        }

        [HttpPost("link-to-order")]
        public async Task<ActionResult> LinkDeliveryInfoToOrder(LinkDeliveryInfoToOrderDto dto)
        {
            await _deliveryRepository.LinkDeliveryInfoToOrder(dto.DeliveryInfoId, dto.OrderId);
            return Ok();
        }

        [HttpGet]
        [Route("count")]
        public async Task<int> GetDeliveryInfosCount()
        {
            return await _deliveryRepository.GetDeliveryInfosCount();
        }
    }
}
