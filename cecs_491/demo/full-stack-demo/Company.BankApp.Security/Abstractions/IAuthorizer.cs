using Company.BankApp.Security.Models;
using System.Collections.Generic;

namespace Company.BankApp.Security.Abstractions
{
    public interface IAuthorizer
    {
        bool IsAuthorized(string userAccountId, IEnumerable<UserClaim> requiredClaims);


        //bool IsAuthorized(IEnumerable<UserClaim> actual, IEnumerable<UserClaim> expected);
    }
}
