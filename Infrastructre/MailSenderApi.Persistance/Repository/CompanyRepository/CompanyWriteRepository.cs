using MailSenderApi.Application.Repository.CompanyRepository;
using MailSenderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Persistance.Repository.CompanyRepository
{
    public class CompanyWriteRepository : WriteRepository<Company>, ICompanyWriteRepository
    {
        private readonly APIDbContext _context;
        public CompanyWriteRepository(APIDbContext apiDbContext) : base(apiDbContext)
        {
            _context = apiDbContext;
        }      
    }
}
