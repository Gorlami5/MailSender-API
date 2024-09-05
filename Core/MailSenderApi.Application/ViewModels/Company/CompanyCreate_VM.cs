﻿using MailSenderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.ViewModels.Company
{
    public class CompanyCreate_VM
    {
        public string? CompanyName { get; set; }
        public string? Location { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public List<ReceiverEmail>? ReceiverEmails { get; set; }
    }
}
