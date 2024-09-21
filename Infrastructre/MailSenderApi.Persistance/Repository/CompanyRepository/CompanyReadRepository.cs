using MailSenderApi.Application.Repository.CompanyRepository;
using MailSenderApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Persistance.Repository.CompanyRepository
{
    public class CompanyReadRepository : ReadRepository<Company>,ICompanyReadRepository
    {
        private readonly APIDbContext _context;
        public CompanyReadRepository(APIDbContext apiDbContext) : base(apiDbContext)
        {
            _context = apiDbContext;
        }

        public async Task<Company> GetCompanyByIdAsync(int companyId)
        {
            var company = await _context.Companies.Include(c => c.ReceiverEmails).FirstOrDefaultAsync();
            return company;
        }
    }
}
