﻿using MailSenderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.Repository.ReceiverEmailRepository
{
    public interface IReceiverEmailWriteRepository : IWriteRepository<ReceiverEmail>
    {
    }
}
