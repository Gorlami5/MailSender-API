using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Domain.Entities
{
    public class ReceiverEmail : BaseEntity
    {
        public int CompanyId { get; set; }
        public string? Email { get; set; }
        public bool IsSendedToday { get; set; } = false;
        public MailTypeStatus SendStatus { get; set; }
        public Company Company { get; set; }

    }
    public enum MailTypeStatus
    {
        IT = 1,
        Info = 2,
        Owner = 3,
        Engineer = 4,

    }
}
