using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWS_Simple_Email_Service_With_Dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private readonly IMailService _mailService;
        public MailsController(IMailService mailService)
        {
            this._mailService = mailService;
        }
        [HttpPost]
        public async Task<IActionResult> SendMail(MailRequest request)
        {
            await _mailService.SendEmailAsync(request);
            return Ok();
        }
    }
}
