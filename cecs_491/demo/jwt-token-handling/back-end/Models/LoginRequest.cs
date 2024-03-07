using System.ComponentModel.DataAnnotations;

namespace back_end
{
    public class LoginRequest
    {
        // When dealing with string data types developers must verify
        // if the following are acceptable values: null, empty string and whitespaces
        public string Username { get; set; }
        public string? Password { get; set; }
    }
}