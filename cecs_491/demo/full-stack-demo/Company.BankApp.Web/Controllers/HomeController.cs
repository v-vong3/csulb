using Company.BankApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Company.BankApp.Web.Controllers
{
    // Lecture: The standard naming convention for controllers will
    // lead to your ASP.NET Core's URL routes to be mapped automatically.
    // The URL route will follow the [hostname]/[controllerPrefix]/[actionMethodName]
    // convention.  e.g. localhost:5000/home/index
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Lecture: 
            // This log entry will appear in the console, but can be
            // routed to any other destination
            _logger.LogInformation(nameof(this.Index));

            return View();
        }


        // Lecture: This is an example of providing an endpoint
        // for your front-end code to call to get dynamic content.
        // The content can be anything such as raw HTML,JSON, XML, 
        // JavaScript, etc. Remember, just because you can send
        // anything to the front-end does not mean you should. 
        // There are vulnerabilities to consider when sending 
        // raw HTML and JavaScript.  Thus, it is typically safer
        // to just send data.
        public IActionResult Data2()
        {
            return Content("Content from HomeController");
        }

        // Lecture: Another view that can be reached using the ASP.NET Core
        // naming convention of [hostname]/[controllerPrefix]/[actionMethodName]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Lecture: Sending a fully constructed model into the view is a way to 
            // dynamically populate a view with data. However, all of this is done at the server-side.
            // If your model is huge, like a list of 1 million User objects, then your server will be
            // working extra hard to be able to process this request.  This issue is compounded by
            // however many users are getting this view. As such, you would need to consider if 
            // client-side dynamic rendering is a better option than server-side rendering.  
            // Client-side dynamic rendering offloads the work or processing large changes to the
            // user's browser, leaving your server more resources to process incoming requests.
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
