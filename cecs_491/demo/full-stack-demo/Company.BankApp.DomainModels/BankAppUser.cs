using System;

namespace Company.BankApp.DomainModels
{
    public class BankAppUser : IEquatable<BankAppUser>
    {
        public string EntityId { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public string Salt { get; set; }


        public string DOB { get; set; }



        // Lecture: Note that when you need to override the 
        // Equals() method, that it is also a good idea to 
        // override the GetHashCode() method as well so that
        // the rest of the .NET infrastructure will use your
        // interpretation of Equals()
        public override bool Equals(object obj)
        {
            return Equals(obj as BankAppUser);
        }

        public override int GetHashCode()
        {
            return this.EntityId.GetHashCode();
        }


        public bool Equals(BankAppUser other)
        {
            if (other is null)
            {
                return false;
            }

            return this.EntityId.Equals(other.EntityId);
        }

        public override string ToString()
        {
            return $"{nameof(BankAppUser)}_{this.EntityId}";
        }


    }
}
