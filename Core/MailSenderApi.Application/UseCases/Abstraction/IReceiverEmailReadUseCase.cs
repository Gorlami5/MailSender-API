using MailSenderApi.Application.Dtos;
using MailSenderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.UseCases.Abstraction
{
    public interface IReceiverEmailReadUseCase
    {
       List<ReceiverEmailReturnDto> GetAllReceiverEmails();
        Task<ReceiverEmailReturnDto> GetReceiverEmail(int id);
        Task<ReceiverEmailReturnDto> GetReceiverEmailByEmail(string email);
        List<ReceiverEmailReturnDto> GetAllReceiverEmailsByCompanyId(int id);
    }
}
