using MailSenderApi.Application.Repository;
using MailSenderApi.Application.Repository.SentMailRepository;
using MailSenderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Persistance.Repository.SentMailRepository
{
    public class SentMailWriteRepository : WriteRepository<SentMail>,ISentMailWriteRepository
    {
        private readonly APIDbContext _context;
        public SentMailWriteRepository(APIDbContext apiDbContext) : base(apiDbContext)
        {
            _context = apiDbContext;
        }
    }
}
