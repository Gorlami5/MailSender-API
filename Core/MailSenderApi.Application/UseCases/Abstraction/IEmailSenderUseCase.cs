using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.UseCases.Abstraction
{
    public interface IEmailSenderUseCase
    {
        Task SendEmailByCompanyId(int templateId, int companyId);
        Task SendAllEmails(int templateId);
        Task SendEmailByEmail(string email, int mailTemplateId);
    }
}
