using MailSenderApi.Application.Dtos;
using MailSenderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.UseCases.Abstraction
{
    public interface ICompanyReadUseCase
    {
        List<CompanyReturnDto> GetAllCompany();
        Task<CompanyReturnDto> GetCompanyById(int id);
        List<CompanyReturnDto> GetAllCompanyByFilter(int id);
        Task<Company> GetCompanyById2(int id);
    }
}
