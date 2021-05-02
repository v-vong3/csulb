using Microsoft.AspNetCore.Mvc;
using Company.BankApp.DomainModels;

namespace Company.BankApp.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost]
        public bool Login([FromBody] string username, [FromBody] string password)
        {
            return false;
        }

        [HttpPost]
        public bool Login(LoginDTO loginDTO)
        {
            / Validate username & password or Auth Token

            // Retrieve user account and user permissions

            // Set user for system

		
            return false
        }
	
    }
}
