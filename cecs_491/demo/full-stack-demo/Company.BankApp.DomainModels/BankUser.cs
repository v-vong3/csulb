using System;

namespace Company.BankApp.DomainModels
{
    public class BankUser : EntityBase, IEquatable<BankUser>
    {
        public string Firstname { get; set; }

        public string Surname { get; set; }


        public string City { get; set; }

        public string StateCode { get; set; }





        // Lecture: Note that when you need to override the 
        // Equals() method, that it is also a good idea to 
        // override the GetHashCode() method as well so that
        // the rest of the .NET infrastructure will use your
        // interpretation of Equals()
        public override bool Equals(object obj)
        {
            return Equals(obj as BankUser);
        }

        public override int GetHashCode()
        {
            return this.EntityId.GetHashCode();
        }


        public bool Equals(BankUser other)
        {
            if (other is null)
            {
                return false;
            }

            return this.EntityId.Equals(other.EntityId);
        }

        public override string ToString()
        {
            return $"{nameof(BankUser)}_{this.EntityId}";
        }


    }
}
