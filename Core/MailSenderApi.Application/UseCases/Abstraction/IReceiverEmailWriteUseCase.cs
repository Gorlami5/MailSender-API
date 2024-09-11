using MailSenderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.UseCases.Abstraction
{
    public interface IReceiverEmailWriteUseCase
    {
        Task<int> CreateReceiverEmail(ReceiverEmail receiverEmail);
        Task<int> UpdateReceiverEmail(ReceiverEmail receiverEmail);
        Task<int> DeleteReceiverEmailById(int id);
        Task<int> DeleteReceiverEmail(ReceiverEmail receiverEmail);
        Task<int> CreateReceiverEmails(List<ReceiverEmail> receiverEmail);
    }
}
