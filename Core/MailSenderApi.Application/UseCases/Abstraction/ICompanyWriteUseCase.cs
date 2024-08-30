using MailSenderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.UseCases.Abstraction
{
    public interface ICompanyWriteUseCase
    {
        Task<int> CreateCompany(Company company);
        Task<int> UpdateCompany(Company company);
        Task<int> DeleteCompanyById(int id);
        Task<int> DeleteCompany(Company company);
        Task<int> CreateCompanies(List<Company> companies);
    }
}
