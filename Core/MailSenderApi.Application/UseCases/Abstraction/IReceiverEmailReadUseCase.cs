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
        Task<List<ReceiverEmail>> GetAllReceiverEmails();
        Task<ReceiverEmail> GetReceiverEmail(int id);
        Task<ReceiverEmail> GetReceiverEmailByEmail(string email);
        Task<List<ReceiverEmail>> GetAllReceiverEmailsByCompanyId(int id);
    }
}
