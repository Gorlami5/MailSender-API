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

        public List<Company> GetAllCompany()
        {
            var companyList = GetAll();
            return companyList.ToList();
        }

        public async Task<Company> GetCompanyById(int id)
        {
            try
            {
                var company = await GetByIdAsync(id);
                if (company == null)
                {
                    throw new Exception("Company does not found");
                }
                return company;
            }
            catch (Exception ex )
            {
               
                throw;
            }
           
            
            
        }
        public List<Company> GetAllCompanyByFilter(int id)
        {
            var companyList = GetWhereList(c => c.Id > id);
            return companyList.ToList();
        }
    }
}
