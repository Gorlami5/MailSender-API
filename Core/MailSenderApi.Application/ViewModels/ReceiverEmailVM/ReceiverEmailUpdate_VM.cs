using MailSenderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.ViewModels.ReceiverEmailVM
{
    public class ReceiverEmailUpdate_VM
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public MailTypeStatus SendStatus { get; set; }
    }
}
