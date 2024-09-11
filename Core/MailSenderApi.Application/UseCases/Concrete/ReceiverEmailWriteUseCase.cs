using MailSenderApi.Application.Constants;
using MailSenderApi.Application.Repository.CompanyRepository;
using MailSenderApi.Application.Repository.ReceiverEmailRepository;
using MailSenderApi.Application.UseCases.Abstraction;
using MailSenderApi.Domain.Entities;
using MailSenderApi.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.UseCases.Concrete
{
    public class ReceiverEmailWriteUseCase : IReceiverEmailWriteUseCase
    {
        private readonly IReceiverEmailWriteRepository _receiverEmailWriteRepository;
        public ReceiverEmailWriteUseCase(IReceiverEmailWriteRepository receiverEmailWriteRepository)
        {
            _receiverEmailWriteRepository = receiverEmailWriteRepository;
        }
        public async Task<int> CreateReceiverEmails(List<ReceiverEmail> receiverEmail)
        {
           
                var returnedValue = await _receiverEmailWriteRepository.AddRangeAsync(receiverEmail);
                if (returnedValue is false)
                {
                    throw new WriteExceptions(ErrorMessages.AddFault);
                }
                var saveAsync = await _receiverEmailWriteRepository.SaveChangesAsync();
                if (saveAsync < 1)
                {
                    throw new WriteExceptions(ErrorMessages.SaveFault);
                }
                return saveAsync;
            
        
        }

        public async Task<int> CreateReceiverEmail(ReceiverEmail receiverEmail)
        {
           
                var returnedValue = await _receiverEmailWriteRepository.AddAsync(receiverEmail);
                if (returnedValue is false)
                {
                    throw new WriteExceptions(ErrorMessages.AddFault);
                }
                var saveAsync = await _receiverEmailWriteRepository.SaveChangesAsync();
                if (saveAsync < 1)
                {
                    throw new WriteExceptions(ErrorMessages.SaveFault);
                }
                return saveAsync;
            
       
        }
        public async Task<int> DeleteReceiverEmail(ReceiverEmail receiverEmail)
        {
           
                var returnedValue = _receiverEmailWriteRepository.Delete(receiverEmail);
                if (returnedValue is false)
                {
                    throw new WriteExceptions(ErrorMessages.AddFault);
                }
                var saveAsync = await _receiverEmailWriteRepository.SaveChangesAsync();
                if (saveAsync < 1)
                {
                    throw new WriteExceptions(ErrorMessages.SaveFault);
                }
                return saveAsync;
            
        
        }

        public async Task<int> DeleteReceiverEmailById(int id)
        {
           
                var returnedValue = _receiverEmailWriteRepository.Delete(id);
                if (returnedValue is false)
                {
                    throw new WriteExceptions(ErrorMessages.AddFault);
                }
                var saveAsync = await _receiverEmailWriteRepository.SaveChangesAsync();
                if (saveAsync < 1)
                {
                    throw new WriteExceptions(ErrorMessages.SaveFault);
                }
                return saveAsync;
            

        }
        public async Task<int> UpdateReceiverEmail(ReceiverEmail receiverEmail)
        {
           
                var returnedValue = _receiverEmailWriteRepository.Update(receiverEmail);
                if (returnedValue is false)
                {
                    throw new WriteExceptions(ErrorMessages.AddFault);
                }
                var saveAsync = await _receiverEmailWriteRepository.SaveChangesAsync();
                if (saveAsync < 1)
                {
                    throw new WriteExceptions(ErrorMessages.SaveFault);
                }
                return saveAsync;
            
        }
    }


}
