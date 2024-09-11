using MailSenderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.UseCases.Abstraction
{
    public interface ISentMailWriteUseCase
    {
        Task<int> CreateSentMail(SentMail sentMail);
        Task<int> DeleteSentMailById(int id);
        Task<int> CreateSentMails(List<SentMail> sentMails);
    }
}
