using MailSenderApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.Repository.EmailExample
{
    public interface IEmailExampleReadRepository : IReadRepository<Email>
    {
    }
}
