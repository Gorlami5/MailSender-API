using MailSenderApi.Application.Interfaces;
using MailSenderApi.Application.UseCases.Abstraction;
using MailSenderApi.Application.Validators.EmailSender;
using MailSenderApi.Application.ViewModels.EmailSenderVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MailSenderApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private readonly IEmailSenderUseCase _emailSender;
        public SendEmailController(IEmailSenderUseCase emailSender)
        {
            _emailSender = emailSender;
        }
        [HttpGet]
        [Route("SendEmailByCompanyId")]
        public async Task<IActionResult> SendEmailByCompanyId([FromBody] SendEmailByCompany_VM sendEmailByCompany_VM)
        {
            await _emailSender.SendEmailByCompanyId(sendEmailByCompany_VM.TemplateId, sendEmailByCompany_VM.CompanyId);
            return Ok();
        }
        [HttpGet]
        [Route("SendEmailAddress")]
        public async Task<IActionResult> SendEmailAddress([FromBody] SendEmailByAddress_VM sendEmailAddress_VM)
        {
            await _emailSender.SendEmailByEmail(sendEmailAddress_VM.Email, sendEmailAddress_VM.MailTemplateId);
            return Ok();
        }
        [HttpGet]
        [Route("SendAllEmailsAddress/{id}")]
        public async Task<IActionResult> SendAllEmailsAddress([EmailSendCustomValidator] int id)
        {
            await _emailSender.SendAllEmails(id);
            return Ok();
        }
    }
}
