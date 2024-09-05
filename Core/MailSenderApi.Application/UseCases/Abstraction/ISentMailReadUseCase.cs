using MailSenderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.UseCases.Abstraction
{
    public interface ISentMailReadUseCase
    {
        Task<List<SentMail>> GetAllSentMail();
        Task<List<SentMail>> GetSentMailsListByCompanyId(int companyId);
    }
}
