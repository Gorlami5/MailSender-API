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
            try
            {
                var companyList = GetAll();
                if (companyList == null)
                {
                    throw new Exception("Company does not found");
                }
                return companyList.ToList();

            }
            catch (Exception)
            {

                throw;
            }
           
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
            try
            {
                var companyList = GetWhereList(c => c.Id > id);
                if(companyList == null)
                {
                    throw new Exception("Company does not found");
                }
                return companyList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        public async Task<Company> GetCompanyByPhoneNumber(string phoneNumber)
        {
            try
            {
                var company = await GetSingle(c => c.PhoneNumber == phoneNumber);
                if(company == null)
                {
                    throw new Exception("Company does not found");
                }
                return company;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
