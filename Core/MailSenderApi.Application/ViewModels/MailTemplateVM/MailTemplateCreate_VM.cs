using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.ViewModels.MailTemplateVM
{
    public class MailTemplateCreate_VM
    {
        public string? Topic { get; set; }
        public string? Body { get; set; }
    }
}
