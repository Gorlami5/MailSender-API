using MailSenderApi.Application.UseCases.Abstraction;
using MailSenderApi.Application.ViewModels.ReceiverEmailVM;
using MailSenderApi.Domain.Entities;
using MailSenderApi.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MailSenderApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiverEmailController : ControllerBase
    {
        private readonly IReceiverEmailReadUseCase _receiverEmailReadUseCase;
        private readonly IReceiverEmailWriteUseCase _receiverEmailWriteUseCase;
        public ReceiverEmailController(IReceiverEmailReadUseCase receiverEmailReadUseCase, IReceiverEmailWriteUseCase receiverEmailWriteUseCase)
        {
            _receiverEmailReadUseCase = receiverEmailReadUseCase;
            _receiverEmailWriteUseCase = receiverEmailWriteUseCase;
        }

        [HttpGet]
        [Route("GetAllReceiverEmail")]
        public IActionResult GetAllReceiverEmail()
        {
            try
            {
                 _receiverEmailReadUseCase.GetAllReceiverEmails();
                return Ok();
            }
            catch (ReadExcepitons ex)
            {

               return NotFound(ex.Message);
            }
            
        }
        [HttpGet]
        [Route("GetReceiverEmailById/{id}")]
        public async Task<IActionResult> GetReceiverEmailById(int id)
        {
            try
            {
                await _receiverEmailReadUseCase.GetReceiverEmail(id);
                return Ok();
            }
            catch (ReadExcepitons ex)
            {

                return NotFound(ex.Message);
            }

        }
        [HttpPost]
        [Route("CreateReceiverEmails")] 
        public async Task<IActionResult> CreateReceiverEmails(ReceiverEmailCreate_VM receiverEmail)
        {
            try
            {
                await _receiverEmailWriteUseCase.CreateReceiverEmail(receiverEmail);
                return Ok();

            }
            catch (WriteExceptions ex)
            {

                return NotFound(ex.Message);
            }
        
        }
        [HttpPost]
        [Route("UpdateReceiverEmails")]
        public async Task<IActionResult> UpdateReceiverEmails(ReceiverEmailUpdate_VM receiverEmail)
        {
            try
            {
                await _receiverEmailWriteUseCase.UpdateReceiverEmail(receiverEmail);
                return Ok();
            }
            catch (WriteExceptions ex)
            {

                return NotFound(ex.Message);
            }

        }
        [HttpDelete]
        [Route("DeleteReceiverEmails")]
        public async Task<IActionResult> DeleteReceiverEmails(int id)
        {
            try
            {
                await _receiverEmailWriteUseCase.DeleteReceiverEmailById(id);
                return Ok();

            }
            catch (WriteExceptions ex)
            {

                return NotFound(ex.Message);
            }

        }
    }
}
