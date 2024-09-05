using AutoMapper;
using MailSenderApi.Application.Constants;
using MailSenderApi.Application.Dtos;
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
        private readonly IMapper _mapper;
        public CompanyReadUseCase(ICompanyReadRepository companyReadRepository, IMapper mapper)
        {
            _companyReadRepository = companyReadRepository;
            _mapper = mapper;
        }
        public List<CompanyReturnDto> GetAllCompany()
        {
            try
            {
                var companyList = _companyReadRepository.GetAll();
                var mappingCompanyList =  _mapper.Map<List<CompanyReturnDto>>(companyList);
                if (companyList == null)
                {
                    throw new ReadExcepitons(ErrorMessages.NotFound);
                }
                return mappingCompanyList;

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

        public List<CompanyReturnDto> GetAllCompanyByFilter(int id)
        {
            try
            {
                var companyList = _companyReadRepository.GetWhereList(c => c.Id > id);
                if (companyList == null)
                {
                    throw new ReadExcepitons(ErrorMessages.NotFound);
                }
                var returnedDto = _mapper.Map<List<CompanyReturnDto>>(companyList);
                return returnedDto.ToList();

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

        public async Task<CompanyReturnDto> GetCompanyById(int id)
        {
            try
            {
                var company = await _companyReadRepository.GetByIdAsync(id);
               
                if (company == null)
                {
                    throw new ReadExcepitons(ErrorMessages.NotFound);
                }
                var mappingCompany = _mapper.Map<CompanyReturnDto>(company);
                return mappingCompany;
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
