using System;
using System.Diagnostics.CodeAnalysis;

namespace Company.BankApp.Security.Models
{
    public class UserClaim : IEquatable<UserClaim>
    {
        public UserClaim(string permission, string scope)
        {
            Permission = permission;
            Scope = scope;
        }

        public string Permission { get; }

        public string Scope { get; }


        public bool Equals([AllowNull] UserClaim other)
        {
            if (other is null)
            {
                return false;
            }


            return this.Permission == other.Permission && this.Scope == other.Scope;
        }
    }
}
