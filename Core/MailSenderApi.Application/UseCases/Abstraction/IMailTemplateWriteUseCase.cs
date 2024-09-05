using MailSenderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.UseCases.Abstraction
{
    public interface IMailTemplateWriteUseCase
    {
        Task<int> CreateMailTemplate(MailTemplate mailTemplate);
        Task<int> UpdateMailTemplate(MailTemplate mailTemplate);
        Task<int> DeleteMailTemplateById(int id);
        Task<int> DeleteMailTemplate(MailTemplate mailTemplate);
    }
}
