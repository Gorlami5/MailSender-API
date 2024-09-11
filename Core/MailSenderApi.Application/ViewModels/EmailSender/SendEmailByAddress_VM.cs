using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.ViewModels.EmailSender
{
    public class SendEmailByAddress_VM
    {
        public string Email { get; set; }
        public int MailTemplateId { get; set; }
    }
}
