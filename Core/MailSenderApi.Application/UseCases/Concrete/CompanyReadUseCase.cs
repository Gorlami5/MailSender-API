using MailSenderApi.Application.Constants;
using MailSenderApi.Application.Repository.CompanyRepository;
using MailSenderApi.Application.UseCases.Abstraction;
using MailSenderApi.Domain.Entities;
using MailSenderApi.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.UseCases.Concrete
{
    public class CompanyReadUseCase : ICompanyReadUseCase
    {
        private readonly ICompanyReadRepository _companyReadRepository;
        public CompanyReadUseCase(ICompanyReadRepository companyReadRepository)
        {
            _companyReadRepository = companyReadRepository;
        }
        public List<Company> GetAllCompany()
        {
            try
            {
                var companyList = _companyReadRepository.GetAll();
                if (companyList == null)
                {
                    throw new ReadExcepitons(ErrorMessages.NotFound);
                }
                return companyList.ToList();

            }
            catch (ReadExcepitons)
            {

                throw;
            }
            catch (Exception)
            {

                throw new Exception(ErrorMessages.UnexpectedFault);
            }
        }

        public List<Company> GetAllCompanyByFilter(int id)
        {
            try
            {
                var companyList = _companyReadRepository.GetWhereList(c => c.Id > id);
                if (companyList == null)
                {
                    throw new ReadExcepitons(ErrorMessages.NotFound);
                }
                return companyList.ToList();

            }
            catch (ReadExcepitons)
            {

                throw;
            }
            catch (Exception)
            {

                throw new Exception(ErrorMessages.UnexpectedFault);
            }
        }

        public async Task<Company> GetCompanyById(int id)
        {
            try
            {
                var company = await _companyReadRepository.GetByIdAsync(id);
                if (company == null)
                {
                    throw new ReadExcepitons(ErrorMessages.NotFound);
                }
                return company;
            }
            catch (ReadExcepitons)
            {

                throw;
            }
            catch (Exception)
            {

                throw new Exception(ErrorMessages.UnexpectedFault);
            }
        }
    }
}
