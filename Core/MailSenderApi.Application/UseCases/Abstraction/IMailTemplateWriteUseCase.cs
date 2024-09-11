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
        Task CreateMailTemplate(MailTemplate mailTemplate);
        Task UpdateMailTemplate(MailTemplate mailTemplate);
        Task DeleteMailTemplateById(int id);
        Task DeleteMailTemplate(MailTemplate mailTemplate);
    }
}
