using Company.BankApp.DataAccess.Abstractions;
using Company.BankApp.DomainModels;
using Company.DataAccess;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Company.BankApp.Apis.Controllers
{
    // Lecture: Check the BankUsersController for notes.  The same notes applies for this
    // as well.
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        private readonly IBankDAO _bankDAO = new InMemoryBankDAO();


        [HttpOptions]
        public IActionResult PreflightRoute()
        {
            return NoContent();
        }


        [HttpGet]
        public IActionResult GetBankAccounts(string bankUserId)
        {
            return Ok(_bankDAO.GetBankAccountsBy(bankUserId));
        }


        [HttpPost]
        public IActionResult CreateBankAccount(BankAccount bankAccount)
        {
            return Ok(_bankDAO.AddBankAccount(bankAccount));
        }
    }
}
