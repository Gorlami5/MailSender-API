using MailSenderApi.Application.ViewModels.ReceiverEmailVM;
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
        Task<int> CreateReceiverEmail(ReceiverEmailCreate_VM receiverEmail);
        Task<int> UpdateReceiverEmail(ReceiverEmailUpdate_VM receiverEmail);
        Task<int> DeleteReceiverEmailById(int id);
        Task<int> DeleteReceiverEmail(ReceiverEmail receiverEmail);
        Task<int> CreateReceiverEmails(List<ReceiverEmailCreate_VM> receiverEmail);
    }
}
