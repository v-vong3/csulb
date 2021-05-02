
using System;

namespace Company.BankApp.DomainModels
{
    public class LoginDTO 
    {
        public string Username { get; init; }

        public string Password { get; init; }
    }

    public class SecureLoginDTO
    {
        public string Username { get; init; }

        public SecureString Password { get; init; }
    }
}