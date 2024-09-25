using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string? CompanyName { get; set; }
        public string? Location { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }

        public List<ReceiverEmail>? ReceiverEmails { get; set; } 

        public Company()
        {
            ReceiverEmails = new List<ReceiverEmail>();
        }
    }

}
