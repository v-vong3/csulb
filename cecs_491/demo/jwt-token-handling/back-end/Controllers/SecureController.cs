using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Logging.Console;

namespace back_end.Controllers;

[ApiController]
[Route("[controller]")]
public class SecureController : ControllerBase
{

#if DEBUG
    [HttpGet()]
    [Route("/secure")]
    public IActionResult Get()
    {
        return Ok("Started");
    }
#endif

    [HttpGet()]
    [Route("/secure/cookie")]
    public IActionResult SecureCookie()
    {
        if(Request.Cookies.Any(c => c.Key == "Authentication-Cookie"))
        {
            Request.Cookies.TryGetValue("Authentication-Cookie", out var token);

            if(token == "Token-HERE")
            {
                return Ok("<h2 class='granted'>Access Granted (Cookie)</h2>");
            }
        }

        return Ok("<h2 class='denied'>Access Denied (Cookie)</h2>");
    }

    [HttpGet()]
    [Route("/secure/header")]
    public IActionResult SecureHeader([FromHeader(Name = "Authorization")] string token)
    {
        if(token == "bearer Token-HERE")
        {
            return Ok("<h2 class='granted'>Access Granted (Header)</h2>");
        }

        return Ok("<h2 class='denied'>Access Denied (Header)</h2>");
    }

    [HttpPost()]
    [Route("/secure/loginModel")]
    public IActionResult LoginModel(LoginRequest loginRequest)
    {
        if(loginRequest is null)
        {
            return BadRequest();
        }

        if(!ModelState.IsValid) 
        {
            return BadRequest();
        }

        if(loginRequest.Username != "test" && loginRequest.Password != "test")
        {
            return Unauthorized("Invalid credentials provided");
        }

        return Ok("Token-HERE");
    }

    [HttpPost()]
    [Route("/secure/loginCookie")]
    public IActionResult LoginCookie(LoginRequest loginRequest)
    {
        if(loginRequest.Username != "test" && loginRequest.Password != "test")
        {
            return Unauthorized();
        }

        var cookieOpts = new CookieOptions()
        {
            Domain = "localhost",
            Path = "/",
            Expires = DateTime.UtcNow.AddHours(1),
            SameSite = SameSiteMode.None, // SameSiteMode.Lax / Strict
            HttpOnly = false, // true
            Secure = false, // true
            IsEssential = true // GDPR --> user consent not required for cookie
        };

        this.Response.Cookies.Append("Authentication-Cookie", "Token-HERE", cookieOpts);

        
        return Ok();
    }


    [HttpPost()]
    [Route("/secure/loginWebStorage")]
    public IActionResult LoginWebStorage(LoginRequest loginRequest)
    {
        if(loginRequest.Username == "test" && loginRequest.Password == "test")
        {
            var token = "Token-HERE (web storage)";

            return Ok(token);
        }

        return Unauthorized("Invalid credentials");
    }




    [HttpPost()]
    [Route("/secure/createToken")]
    public IActionResult CreateJwt(LoginRequest loginRequest)
    {
        // TODO: Check security credentials match Database

        var header = new JwtHeader();
        var payload = new JwtPayload()
        {
            Iss = Request.Host.Host,
            Sub = "myApp",
            Aud = "myApp",
            Iat = DateTime.UtcNow.Ticks,
            Exp = DateTime.UtcNow.AddMinutes(20).Ticks
        };

        // TODO: Add custom permissions to payload


        var serializerOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        };

        var encodedHeader = Base64UrlEncode(JsonSerializer.Serialize(header, serializerOptions));
        var encodedPayload = Base64UrlEncode(JsonSerializer.Serialize(payload, serializerOptions));


        using(var hash = new HMACSHA256(Encoding.UTF8.GetBytes("simple-key")))
        {
            // String to Byte[]
            var signatureInput = $"{encodedHeader}.{encodedPayload}";
            var signatureInputBytes = Encoding.UTF8.GetBytes(signatureInput); 

            // Byte[] to String
            var signatureDigestBytes = hash.ComputeHash(signatureInputBytes);
            var encodedSignature = WebEncoders.Base64UrlEncode(signatureDigestBytes);

            var jwt = new Jwt()
            {
                Header = header,
                Payload = payload,
                Signature = encodedSignature
            };

            return Ok(JsonSerializer.Serialize(jwt));
        }
    }

    private static string Base64UrlEncode(string input) 
    {
        var bytes = Encoding.UTF8.GetBytes(input);

        return WebEncoders.Base64UrlEncode(bytes); 
    }

}
