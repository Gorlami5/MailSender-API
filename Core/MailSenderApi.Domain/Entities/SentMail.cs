using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Domain.Entities
{
    public class SentMail : BaseEntity
    {
        public int MailTemplateId { get; set; }
        public int CompanyId { get; set; }
        public string? ToEmail { get; set; }
        public MailTemplate MailTemplate { get; set; }

    }
}
