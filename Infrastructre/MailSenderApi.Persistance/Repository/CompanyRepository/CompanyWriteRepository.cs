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
        public async Task<int> CreateCompany(Company company)
        {
            try
            {
                var returnedValue = await AddAsync(company);
                if (returnedValue is false)
                {
                    throw new Exception("Added process unsuccesfully");
                }
                var saveAsync = await _context.SaveChangesAsync();
                if(saveAsync < 1)
                {
                    throw new Exception("Added process unsuccesfully");
                }
                return saveAsync;
            }
            catch (Exception)
            {

                throw;
            }
          

        }
        public async Task<int> UpdateCompany(Company company)
        {
            try
            {
                var returnedValue = Update(company);
                if (returnedValue is false)
                {
                    throw new Exception("Added process unsuccesfully");
                }
                var saveAsync = await _context.SaveChangesAsync();
                if (saveAsync < 1)
                {
                    throw new Exception("Added process unsuccesfully");
                }
                return saveAsync;
            }
            catch (Exception)
            {
                throw;
            }
                      
        }

        public async Task<int> DeleteCompanyById(int id)
        {
            try
            {
                var returnedValue = Delete(id);
                if (returnedValue is false)
                {
                    throw new Exception("Added process unsuccesfully");
                }
                var saveAsync = await _context.SaveChangesAsync();
                if (saveAsync < 1)
                {
                    throw new Exception("Added process unsuccesfully");
                }
                return saveAsync;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public async Task<int> DeleteCompany(Company company)
        {
            try
            {
                var returnedValue = Delete(company);
                if (returnedValue is false)
                {
                    throw new Exception("Added process unsuccesfully");
                }
                var saveAsync = await _context.SaveChangesAsync();
                if (saveAsync < 1)
                {
                    throw new Exception("Added process unsuccesfully");
                }
                return saveAsync;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<int> CreateCompanies(List<Company> companies)
        {
            try
            {
                var returnedValue = await AddRangeAsync(companies);
                if (returnedValue is false)
                {
                    throw new Exception("Added process unsuccesfully");
                }
                var saveAsync = await _context.SaveChangesAsync();
                if (saveAsync < 1)
                {
                    throw new Exception("Added process unsuccesfully");
                }
                return saveAsync;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
