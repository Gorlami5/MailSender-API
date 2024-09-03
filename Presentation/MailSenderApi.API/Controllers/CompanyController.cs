using MailSenderApi.Application.UseCases.Abstraction;
using MailSenderApi.Application.ViewModels.Company;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var companies = _companyReadUseCase.GetAllCompany();
            return Ok(companies);
        }
        [Route("GetCompany/{id}")]
        [HttpGet]
        public IActionResult GetCompany(int id)
        {
            var company = _companyReadUseCase.GetCompanyById(id);
            return Ok(company);

        }
        [Route("CreateCompany")]
        [HttpPost]
        public IActionResult CreateCompany(CompanyCreate_VM company)
        {
            if(ModelState.IsValid)
            {

            }
            return Ok();
        }
    }
}
