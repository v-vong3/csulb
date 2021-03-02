using Company.BankApp.Security.Models;
using System.Collections.Generic;

namespace Company.BankApp.Security.Abstractions
{
    public interface IClaimsService
    {
        //IEnumerable<(string permission, string scope)> GetClaims(string userAccountId);

        IEnumerable<UserClaim> GetClaims(string userAccountId);

    }
}
