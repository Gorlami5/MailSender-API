using MailSenderApi.Application.Constants;
using MailSenderApi.Application.Repository.ReceiverEmailRepository;
using MailSenderApi.Application.UseCases.Abstraction;
using MailSenderApi.Domain.Entities;
using MailSenderApi.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.UseCases.Concrete
{
    public class ReceiverEmailReadUseCase : IReceiverEmailReadUseCase
    {
        private readonly IReceiverEmailReadRepository _receiverEmailReadRepository;
        public ReceiverEmailReadUseCase(IReceiverEmailReadRepository receiverEmailReadRepository)
        {
           _receiverEmailReadRepository = receiverEmailReadRepository;         
        }
        public async Task<List<ReceiverEmail>> GetAllReceiverEmails()
        {
            try
            {
                var receiverEmails = _receiverEmailReadRepository.GetAll(false);
                if(receiverEmails == null)
                {
                    throw new ReadExcepitons(ErrorMessages.NotFound);
                }
                return await receiverEmails.ToListAsync();
                
            }
            catch (ReadExcepitons)
            {

                throw;
            }
            catch (Exception)
            {

                throw new Exception(ErrorMessages.UnexpectedFault);
            }

        }

        public async Task<List<ReceiverEmail>> GetAllReceiverEmailsByCompanyId(int id)
        {
            
            
            try
            {
                var GetAllReceiverEmails = _receiverEmailReadRepository.GetWhereList(e => e.CompanyId == id);
                if (GetAllReceiverEmails == null)
                {
                    throw new ReadExcepitons(ErrorMessages.NotFound);
                }
                return await GetAllReceiverEmails.ToListAsync();

            }
            catch (ReadExcepitons)
            {

                throw;
            }
            catch (Exception)
            {

                throw new Exception(ErrorMessages.UnexpectedFault);
            }
        }

        public async Task<ReceiverEmail> GetReceiverEmail(int id)
        {
            try
            {
                var email = await _receiverEmailReadRepository.GetByIdAsync(id);
                if (email == null)
                {
                    throw new ReadExcepitons(ErrorMessages.NotFound);
                }
                return email;

            }
            catch (ReadExcepitons)
            {

                throw;
            }
            catch (Exception)
            {

                throw new Exception(ErrorMessages.UnexpectedFault);
            }
            
           
        }

        public async Task<ReceiverEmail> GetReceiverEmailByEmail(string email)
        {
            try
            {
                var receiverEmail = await _receiverEmailReadRepository.GetSingle(e => e.Email.Equals(email));
                if (receiverEmail == null)
                {
                    throw new ReadExcepitons(ErrorMessages.NotFound);
                }
                return receiverEmail;

            }
            catch (ReadExcepitons)
            {

                throw;
            }
            catch (Exception)
            {

                throw new Exception(ErrorMessages.UnexpectedFault);
            }
           
           
        }
    }
}
