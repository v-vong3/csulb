using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
[EnableCors("default")]
public class SignInController : ControllerBase
{
    [HttpGet()]
    [Route("myGetEndpoint")]
    public string Get()
    {
        // HTML sanitization should occur, especially before DOM injection
        // For example, don't allow raw <script> elements
        return "<p>GET: This is HTML content from the server</p>";
    }

    [HttpPost()]
    [Route("myPostEndpoint")]
    public string Post()
    {
        // HTML sanitization should occur, especially before DOM injection
        // For example, don't allow raw <script> elements
        return "<p>POST: This is HTML content from the server</p>";
    }
}
