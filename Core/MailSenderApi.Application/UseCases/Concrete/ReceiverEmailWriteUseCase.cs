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
        public async Task<int> CreateCompanies(List<ReceiverEmail> receiverEmail)
        {
            try
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
            catch (WriteExceptions)
            {
                throw;
            }
            catch (Exception)
            {
                throw new Exception(ErrorMessages.UnexpectedFault);
            }
        }

        public async Task<int> CreateCompany(ReceiverEmail receiverEmail)
        {
            try
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
            catch (WriteExceptions)
            {
                throw;
            }
            catch (Exception)
            {
                throw new Exception(ErrorMessages.UnexpectedFault);
            }
        }
        public async Task<int> DeleteCompany(ReceiverEmail receiverEmail)
        {
            try
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
            catch (WriteExceptions)
            {
                throw;
            }
            catch (Exception)
            {
                throw new Exception(ErrorMessages.UnexpectedFault);
            }
        }

        public async Task<int> DeleteCompanyById(int id)
        {
            try
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
            catch (WriteExceptions)
            {
                throw;
            }
            catch (Exception)
            {
                throw new Exception(ErrorMessages.UnexpectedFault);
            }
        }
        public async Task<int> UpdateCompany(ReceiverEmail receiverEmail)
        {
            try
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
            catch (WriteExceptions)
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
