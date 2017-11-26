using System.Web.Http;

namespace api_demo.Controllers
{
    public class TestDTO
    {
        public string[] Data { get; set; }
    }

    public class DemoController : ApiController
    {
        // Route is set by WebAPI convention (api/demo/test)
        public IHttpActionResult GetTest()
        {
            return Ok(new TestDTO() { Data = new string[] { "Test", "data", "right here" } });
        }

    }
}