using MailSenderApi.Application.UseCases.Abstraction;
using MailSenderApi.Application.ViewModels.MailTemplateVM;
using MailSenderApi.Domain.Entities;
using MailSenderApi.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MailSenderApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailTemplateController : ControllerBase
    {
        private readonly IMailTemplateReadUseCase _mailTemplateReadUseCase;
        private readonly IMailTemplateWriteUseCase _mailTemplateWriteUseCase;
        public MailTemplateController(IMailTemplateReadUseCase mailTemplateReadUseCase,IMailTemplateWriteUseCase mailTemplateWriteUseCase)
        {
                _mailTemplateReadUseCase = mailTemplateReadUseCase;
                _mailTemplateWriteUseCase = mailTemplateWriteUseCase;
        }

        [HttpGet]
        [Route("GetAllMailTemplate")]
        public async Task<IActionResult> GetAllMailTemplate()
        {
            try
            {
                var templates = await _mailTemplateReadUseCase.GetAllMailTemplates();
                return Ok(templates);
            }
            catch (ReadExcepitons ex)
            {
                return NotFound(ex.Message);
            }
        
        }
        [HttpPost]
        [Route("CreateMailTemplatel")]
        public async Task<IActionResult> CreateMailTemplatel(MailTemplateCreate_VM mailTemplate)
        {
            try
            {
                await _mailTemplateWriteUseCase.CreateMailTemplate(mailTemplate);
                return Ok();
            }
            catch (WriteExceptions ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpPost]
        [Route("UpdateMailTemplate")]
        public async Task<IActionResult> UpdateMailTemplate(MailTemplate mailTemplate)
        {
            try
            {
                await _mailTemplateWriteUseCase.UpdateMailTemplate(mailTemplate);
                return Ok();
            }
            catch (WriteExceptions ex)
            {
                return NotFound(ex.Message);
            }

        }
        [HttpDelete]
        [Route("DeleteMailTemplate")]
        public async Task<IActionResult> DeleteMailTemplate(int id)
        {
            try
            {
                await _mailTemplateWriteUseCase.DeleteMailTemplateById(id);
                return Ok();
            }
            catch (WriteExceptions ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
