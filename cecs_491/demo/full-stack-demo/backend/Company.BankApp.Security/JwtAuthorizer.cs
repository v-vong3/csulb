using Company.BankApp.Security.Abstractions;
using Company.BankApp.Security.Models;
using System;
using System.Collections.Generic;

namespace Company.BankApp.Security
{
    class JwtAuthorizer : IAuthorizer
    {
        public bool IsAuthorized(string currentUserId, IEnumerable<UserClaim> requiredClaims)
        {
            // Fetch assigned claims for user

            // Loop through each requiredClaims to ensure user has matching claims

            throw new NotImplementedException();
        }
    }
}
