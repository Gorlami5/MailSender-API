using MailSenderApi.Application.UseCases.Abstraction;
using MailSenderApi.Application.ViewModels.Company;
using MailSenderApi.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MailSenderApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyReadUseCase _companyReadUseCase;
        private readonly ICompanyWriteUseCase _companyWriteUseCase;

        public CompanyController(ICompanyReadUseCase companyReadUseCase, ICompanyWriteUseCase companyWriteUseCase)
        {
            _companyReadUseCase = companyReadUseCase;
            _companyWriteUseCase = companyWriteUseCase;
        }
        [Route("GetAllCompany")]
        [HttpGet]
        public IActionResult GetAllCompany()
        {
            try
            {
                var companies = _companyReadUseCase.GetAllCompany();
                return Ok(companies);
            }
            catch (ReadExcepitons ex)
            {
                return NotFound(ex.Message);
            }
            
        }
        [Route("GetCompany/{id}")]
        [HttpGet]
        public IActionResult GetCompany(int id)
        {
            try
            {
                var company = _companyReadUseCase.GetCompanyById(id);
                return Ok(company);
            }
            catch (ReadExcepitons ex)
            {

                return NotFound(ex.Message);
            }
         

        }
        [Route("CreateCompany")]
        [HttpPost]
        public async Task<IActionResult> CreateCompany(CompanyCreate_VM company)
        {
            try
            {
                await _companyWriteUseCase.CreateCompany(company);
                return Ok();
            }
            catch (WriteExceptions ex)
            {

                return NotFound(ex.Message);
            }
          
        }
    }
}
