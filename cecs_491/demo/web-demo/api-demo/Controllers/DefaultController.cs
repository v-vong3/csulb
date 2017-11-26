using System.Web.Http;

namespace api_demo.Controllers
{
    public class DefaultController : ApiController
    {
        // Route is set explicitly
        [Route("api/default/index")]
        [HttpGet]
        public string Index()
        {
            return "This is the default route.  Use api/demo/test to get test data.";
        }


    }
}