using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.ViewModels.EmailSender
{
    public class SendEmailByCompany_VM
    {
        public int TemplateId { get; set; }
        public int CompanyId { get; set; }
    }
}
