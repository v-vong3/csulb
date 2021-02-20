using Company.BankApp.Security.Abstractions;
using Company.BankApp.Security.Models;
using System.Collections.Generic;
using System.Linq;

namespace Company.BankApp.Security
{
    public class Authorizer : IAuthorizer
    {
        private IClaimsService ClaimsService { get; }

        public Authorizer(IClaimsService claimsService)
        {
            ClaimsService = claimsService;
        }


        public bool IsAuthorized(string userAccountId, IEnumerable<UserClaim> requiredClaims)
        {
            var userClaims = ClaimsService.GetClaims(userAccountId);


            foreach (var rc in requiredClaims)
            {
                if (!userClaims.Any(uc => uc == rc))
                {
                    return false;
                }
            }


            return true;
        }




    }
}
