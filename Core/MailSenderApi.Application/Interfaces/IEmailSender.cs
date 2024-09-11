using MailSenderApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(List<string> toEmail, string subject, string body);
        Task SendSingleEmailAsync(string toEmail, string subject, string body);
    }
}
