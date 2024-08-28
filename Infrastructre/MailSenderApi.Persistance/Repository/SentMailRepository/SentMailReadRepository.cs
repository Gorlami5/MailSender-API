using MailSenderApi.Application.Repository.SentMailRepository;
using MailSenderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Persistance.Repository.SentMailRepository
{
    public class SentMailReadRepository : ReadRepository<SentMail>,ISentMailReadRepository
    {
        private readonly APIDbContext _context;
        public SentMailReadRepository(APIDbContext apiDbContext) : base(apiDbContext)
        {
            _context = apiDbContext;
        }
    }
}
