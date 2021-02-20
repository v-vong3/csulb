using Company.BankApp.DataAccess;
using Company.BankApp.DataAccess.Abstractions;
using Company.BankApp.DomainModels;
using Company.BankApp.Managers;
using Company.BankApp.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.BankApp.Apis.Controllers
{
    // Lecture: Check the BankUsersController for notes.  The same notes applies for this
    // as well.
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {

        // Lecture: Typically you either with to use the ASP.NET Core's DI container
        // to inject this dependency or better yet move this to the business layer.
        private readonly IBankDAO _bankDAO = new InMemoryBankDAO();


        [HttpOptions]
        public IActionResult PreflightRoute()
        {
            return NoContent();
        }


        [HttpGet]
        public IActionResult GetBankAccounts(string bankAppUserId)
        {
            BankAccountService service = new BankAccountService(_bankDAO);
            BankAccountManager manager = new BankAccountManager(service);

            try
            {
                var accounts = manager.GetUserBankAccounts(bankAppUserId);


                return Ok(accounts);
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

        }


        [HttpPost]
        public IActionResult CreateBankAccount(BankAccount bankAccount)
        {
            BankAccountService service = new BankAccountService(_bankDAO);
            BankAccountManager manager = new BankAccountManager(service);


            var createResult = manager.CreateAccount(bankAccount);

            if (createResult)
            {
                return Ok();
            }

            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}
