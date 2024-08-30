using MailSenderApi.Application.Constants;
using MailSenderApi.Application.Repository.CompanyRepository;
using MailSenderApi.Application.UseCases.Abstraction;
using MailSenderApi.Domain.Entities;
using MailSenderApi.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MailSenderApi.Application.UseCases.Concrete
{
    public class CompanyWriteUseCase : ICompanyWriteUseCase
    {
        private readonly ICompanyWriteRepository _companyWriteRepository;

        public CompanyWriteUseCase(ICompanyWriteRepository companyWriteRepository)
        {
            _companyWriteRepository = companyWriteRepository;
        }
        public async Task<int> CreateCompanies(List<Company> companies)
        {
            try
            {
                var returnedValue = await _companyWriteRepository.AddRangeAsync(companies);
                if (returnedValue is false)
                {
                    throw new WriteExceptions(ErrorMessages.AddFault);
                }
                var saveAsync = await _companyWriteRepository.SaveChangesAsync();
                if (saveAsync < 1)
                {
                    throw new WriteExceptions(ErrorMessages.SaveFault);
                }
                return saveAsync;
            }
            catch (WriteExceptions)
            {
                throw;
            }
            catch (Exception)
            {
                throw new Exception(ErrorMessages.UnexpectedFault);
            }
        }

        public async Task<int> CreateCompany(Company company)
        {
            try
            {
                var returnedValue = await _companyWriteRepository.AddAsync(company);
                if (returnedValue is false)
                {
                    throw new WriteExceptions(ErrorMessages.AddFault);
                }
                var saveAsync = await _companyWriteRepository.SaveChangesAsync();
                if (saveAsync < 1)
                {
                    throw new WriteExceptions(ErrorMessages.SaveFault);
                }
                return saveAsync;
            }
            catch (WriteExceptions)
            {

                throw;
            }
            catch (Exception)
            {

                throw new Exception(ErrorMessages.UnexpectedFault);
            }


        }
        public async Task<int> DeleteCompany(Company company)
        {
            try
            {
                var returnedValue = _companyWriteRepository.Delete(company);
                if (returnedValue is false)
                {
                    throw new WriteExceptions(ErrorMessages.DeleteFault);
                }
                var saveAsync = await _companyWriteRepository.SaveChangesAsync();
                if (saveAsync < 1)
                {
                    throw new WriteExceptions(ErrorMessages.SaveFault);
                }
                return saveAsync;
            }
            catch (WriteExceptions)
            {

                throw;
            }
            catch (Exception)
            {

                throw new Exception(ErrorMessages.UnexpectedFault);
            }
        }
        public async Task<int> DeleteCompanyById(int id)
        {
            try
            {
                var returnedValue = _companyWriteRepository.Delete(id);
                if (returnedValue is false)
                {
                    throw new WriteExceptions(ErrorMessages.DeleteFault);
                }
                var saveAsync = await _companyWriteRepository.SaveChangesAsync();
                if (saveAsync < 1)
                {
                    throw new WriteExceptions(ErrorMessages.SaveFault);
                }
                return saveAsync;
            }
            catch (WriteExceptions)
            {

                throw;
            }
            catch (Exception)
            {

                throw new Exception(ErrorMessages.UnexpectedFault);
            }
        }
        public async Task<int> UpdateCompany(Company company)
        {
            try
            {
                var returnedValue = _companyWriteRepository.Update(company);
                if (returnedValue is false)
                {
                    throw new WriteExceptions(ErrorMessages.UpdateFault);
                }
                var saveAsync = await _companyWriteRepository.SaveChangesAsync();
                if (saveAsync < 1)
                {
                    throw new WriteExceptions(ErrorMessages.SaveFault);
                }
                return saveAsync;
            }
            catch (WriteExceptions)
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



