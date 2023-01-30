using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using podsticarijum_backend.Application;
using podsticarijum_backend.DTO;

namespace podsticarijum_backend.Api.Controllers
{
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IPodsticarijumMailService _mailService;
        public MailController(IPodsticarijumMailService mailService)
        {
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        }

        [HttpPost("email")]
        public async Task<ActionResult> SendEmail(MailDto emailDto)
        {
            try
            {
                var expertMail = emailDto.ExpertMail ?? string.Empty;
                var body = emailDto.Body ?? string.Empty;
                var userMailAddress = emailDto.UserMailAddress ?? string.Empty;
                var appPackageName = emailDto.AppPackageName ?? string.Empty;

                body = body + $"\n Email poslat od strane {emailDto.UserMailAddress}";

                _mailService.Subject = userMailAddress;
                _mailService.AppPackageName = emailDto.AppPackageName;
                _mailService.Body = body;

                ArgumentNullException.ThrowIfNull(_mailService.AppPackageName);
                ArgumentNullException.ThrowIfNull(_mailService.Subject);
                ArgumentNullException.ThrowIfNull(body);
                ArgumentNullException.ThrowIfNull(userMailAddress);

                await _mailService.sendEmail(expertMail);
                return Ok();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return BadRequest("There was an error");
            }
        }
    }
}
