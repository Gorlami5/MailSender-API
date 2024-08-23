using MailSenderApi.Application.Repository.EmailExample;
using MailSenderApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Persistance.Repository.EmailExample
{
    public class EmailExampleWriteRepository : WriteRepository<Email>,IEmailExampleWriteRepository
    {
        private readonly APIDbContext _context;
        public EmailExampleWriteRepository(APIDbContext apiDbContext) : base(apiDbContext)
        {
            _context = apiDbContext;
        }
    }
}
