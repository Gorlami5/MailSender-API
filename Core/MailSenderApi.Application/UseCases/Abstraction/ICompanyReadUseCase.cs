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
        List<Company> GetAllCompany();
        Task<Company> GetCompanyById(int id);
        List<Company> GetAllCompanyByFilter(int id);
    }
}
