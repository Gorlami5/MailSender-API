using MailSenderApi.Application.ViewModels.Company;
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
        Task<int> CreateCompany(CompanyCreate_VM viewModelCompanies);
        Task<int> UpdateCompany(CompanyUpdate_VM viewModelCompany);
        Task<int> DeleteCompanyById(int id);
        Task<int> DeleteCompany(Company company);
        Task<int> CreateCompanies(List<CompanyCreate_VM> viewModelCompanies);
    }
}
