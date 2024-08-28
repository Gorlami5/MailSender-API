using MailSenderApi.Application.Repository;
using MailSenderApi.Application.Repository.MailTemplateRepository;
using MailSenderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Persistance.Repository.MailTemplateRepository
{
    public class MailTemplateWriteRepository : WriteRepository<MailTemplate>,IMailTemplateWriteRepository
    {
        private readonly APIDbContext _context;
        public MailTemplateWriteRepository(APIDbContext apiDbContext) : base(apiDbContext)
        {
            _context = apiDbContext;
        }
    }
}
