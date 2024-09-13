using AutoMapper;
using MailSenderApi.Application.Constants;
using MailSenderApi.Application.Dtos;
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

namespace MailSenderApi.Application.UseCases.Concrete
{
    public class CompanyReadUseCase : ICompanyReadUseCase
    {
        private readonly ICompanyReadRepository _companyReadRepository;
        private readonly IMapper _mapper;
        public CompanyReadUseCase(ICompanyReadRepository companyReadRepository, IMapper mapper)
        {
            _companyReadRepository = companyReadRepository;
            _mapper = mapper;
        }
        public List<CompanyReturnDto> GetAllCompany()
        {
           
                var companyList = _companyReadRepository.GetAll();
                var mappingCompanyList =  _mapper.Map<List<CompanyReturnDto>>(companyList);
                if (companyList == null)
                {
                    throw new ReadExcepitons(ErrorMessages.NotFound);
                }
                return mappingCompanyList;
           
        }

        public List<CompanyReturnDto> GetAllCompanyByFilter(int id)
        {          
                var companyList = _companyReadRepository.GetWhereList(c => c.Id > id);
                if (companyList == null)
                {
                    throw new ReadExcepitons(ErrorMessages.NotFound);
                }
                var returnedDto = _mapper.Map<List<CompanyReturnDto>>(companyList);
                return returnedDto.ToList();    
        }

        public async Task<CompanyReturnDto> GetCompanyById(int id)
        {
            
                var company = await _companyReadRepository.GetByIdAsync(id);
               
                if (company == null)
                {
                    throw new ReadExcepitons(ErrorMessages.NotFound);
                }
                var mappingCompany = _mapper.Map<CompanyReturnDto>(company);
                return mappingCompany;  
        }
        public async Task<Company> GetCompanyById2(int id)
        {

            var company = await _companyReadRepository.GetCompanyByIdAsync(id);

            if (company == null)
            {
                throw new ReadExcepitons(ErrorMessages.NotFound);
            }
            return company;
        }
    }
}
