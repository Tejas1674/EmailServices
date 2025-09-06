using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model.Dto;
using WebApplication1.Repositry.Contract;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailServiceController : ControllerBase
    {
        private readonly IEmailServiceRepository _emailServiceRepository;

        public EmailServiceController(IEmailServiceRepository emailServiceRepository)
        {
            _emailServiceRepository = emailServiceRepository;
        }
        [HttpPost("send")]
        public IActionResult SendEmail([FromBody] EmailservicesDto request)
        {
            _emailServiceRepository.SendEmail(request);
            return Ok(new { Message = "Email sent successfully", Request = request });
        }
    }
}
