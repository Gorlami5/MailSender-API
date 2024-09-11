using AutoMapper;
using MailSenderApi.Application.Constants;
using MailSenderApi.Application.Repository.CompanyRepository;
using MailSenderApi.Application.UseCases.Abstraction;
using MailSenderApi.Application.ViewModels.Company;
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
        private readonly IMapper _mapper;

        public CompanyWriteUseCase(ICompanyWriteRepository companyWriteRepository, IMapper mapper)
        {
            _companyWriteRepository = companyWriteRepository;
            _mapper = mapper;
        }
        public async Task<int> CreateCompanies(List<CompanyCreate_VM> viewModelCompanies)
        {
           
                var companies = _mapper.Map<List<Company>>(viewModelCompanies);
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

        public async Task<int> CreateCompany(CompanyCreate_VM viewModelCompanies)
        {
           
                var company = _mapper.Map<Company>(viewModelCompanies);
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
        public async Task<int> DeleteCompany(Company company)
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
        public async Task<int> DeleteCompanyById(int id)
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
        public async Task<int> UpdateCompany(CompanyUpdate_VM viewModelCompany)
        {
            
                var company = _mapper.Map<Company>(viewModelCompany);
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

    }
}



