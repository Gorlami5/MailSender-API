using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Domain.Entities
{
    public class MailTemplate : BaseEntity
    {
        public string? Topic { get; set; }
        public string? Body { get; set; }
        //formatting property will be added for CV or etc.
        public List<SentMail> SentMails { get; set; }
        public MailTemplate()
        {
            SentMails = new List<SentMail>();
        }
    }
}
