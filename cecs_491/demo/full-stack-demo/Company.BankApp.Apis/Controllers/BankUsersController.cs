using Company.BankApp.DataAccess.Abstractions;
using Company.BankApp.DomainModels;
using Company.DataAccess;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Company.APIs.Users.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class BankUsersController : ControllerBase
    {
        // Lecture: Typically you either with to use the ASP.NET Core's DI container
        // to inject this dependency or better yet move this to the business layer.
        private readonly IBankDAO _bankDAO = new InMemoryBankDAO();


        // Lecture: Not really needed if using the ASP.NET Core's CORS library
        [HttpOptions]
        public IActionResult PreflightRoute()
        {
            return NoContent();
        }


        [HttpGet]
        public IActionResult GetBankUsers()
        {
            return Gatekeeper(() => { return Ok(_bankDAO.GetBankUsers()); });
        }


        [HttpPost]
        public IActionResult CreateBankUser(BankUser bankUser)
        {
            return Gatekeeper(() => { return Ok(_bankDAO.AddBankUser(bankUser)); });
        }

        // Lecture: This is a easy way to avoid redundant code within each action method.
        // Consolidate your code to be used within all/most action methods will increase
        // maintainability and code readability. Look how simple each action method becomes.
        private IActionResult Gatekeeper(Func<IActionResult> actionMethodDelegate)
        {
            // Lecture: The try-catch block is a last line of defense for your server-side code.
            // If any exception occurs this should stop it from leaking to the user.
            // However, it does not protect completely. Users going to invalid URLs, will need
            // to be handle at the middleware or URL routing level.
            try
            {
                // Lecture: This is an example of using higher-order functions.
                // Func<TOut> is a syntactic sugar for create a C# delegate.
                // Delegates are simply a variable that represents a method signature.
                // Use of this pattern improves extensibility at the cost of some readability,
                // especially from developers that do not understand what a delegate is.
                // Also note that if you need to pass different number of parameters into 
                // Func<TOut> that it will complicate this method considerably.
                return actionMethodDelegate.Invoke();
            }
            catch
            {
                // Lecture: Recommended that a custom error view is sent to the user
                // instead of simple text.
                return Content("Error");
            }
        }


    }
}
