﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.Dtos
{
    public class CompanyReturnDto
    {
        public string? CompanyName { get; set; }
        public string? Location { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
