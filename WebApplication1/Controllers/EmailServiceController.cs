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
            // Here you would add your email sending logic
            // For demonstration, we'll just return a success response
            _emailServiceRepository.SendEmail(request);
            return Ok(new { Message = "Email sent successfully", Request = request });
        }
    }
}
