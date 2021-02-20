using System;

namespace Company.BankApp.DomainModels
{
    public class BankAccount : IEquatable<BankAccount>
    {

        public string EntityId { get; set; }

        public BankAccountType AccountType { get; set; }

        public BankAppUser Owner { get; set; }


        public decimal Balance { get; set; }




        public override bool Equals(object obj)
        {
            return Equals(obj as BankAccount);
        }

        public override int GetHashCode()
        {
            return this.EntityId.GetHashCode();
        }


        public bool Equals(BankAccount other)
        {
            if (other is null)
            {
                return false;
            }

            return this.EntityId.Equals(other.EntityId);
        }



        public override string ToString()
        {
            return $"{nameof(BankAccount)} {this.EntityId}";
        }
    }
}
