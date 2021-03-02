using Company.BankApp.Security.Abstractions;
using Company.BankApp.Security.Models;
using System.Collections.Generic;

namespace Company.BankApp.Security
{
    public class ClaimsService : IClaimsService
    {
        public IEnumerable<UserClaim> GetClaims(string userAccountId)
        {
            return new UserClaim[]
            {
                new UserClaim("create", "savings"),
                new UserClaim("transfer", "saving"),
                new UserClaim("transfer", "checking")
            };
        }
    }
}
