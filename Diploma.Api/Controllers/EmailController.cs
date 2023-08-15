using Diploma.BusinessLogic.Repositories.EmailRepository;
using Diploma.DTO.Email;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailRepository _emailRepository;

        public EmailController(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailDto request)
        {
            _emailRepository.SendEmail(request);
            return Ok();
        }
    }
}
