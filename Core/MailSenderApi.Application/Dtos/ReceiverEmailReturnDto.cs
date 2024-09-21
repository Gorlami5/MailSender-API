using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.Dtos
{
    public class ReceiverEmailReturnDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string? Email { get; set; }
        public bool IsSendedToday { get; set; }
    }
}
