using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MailSenderApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        public CompanyController()
        {
            
        }
        [HttpGet]
        public IActionResult GetAllCompany() 
        {
            return Ok();
        }
    }
}
