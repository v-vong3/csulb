using Company.BankApp.DataAccess;
using Company.BankApp.DataAccess.Abstractions;
using Company.BankApp.DomainModels;
using Company.BankApp.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Company.BankApp.Managers
{


    // Lecture:
    // Example of a manager that does not have a service
    // Managers now need to have direct dependency of the Data Access Layer
    // due to usage of Data Access Object and Entities 
    public class BankAppUserManager
    {

        private readonly IBankDAO _bankDAO = new InMemoryBankDAO();




        // Feature: Create new user
        // Requirements: 
        //      User does not already exist
        public bool CreateUser(BankAppUser newUser)
        {
            if (_bankDAO.GetBankUsers().Any(u => u.Username == newUser.Username))
            {
                return false;
            }


            var userEntity = new BankAppUserEntity()
            {
                //DOB = DateTime.Parse(newUser.DOB),
                Username = newUser.Username,
                PasswordHash = newUser.PasswordHash,
                Salt = newUser.Salt
            };

            return _bankDAO.AddBankUser(userEntity);
        }


        public IEnumerable<BankAppUser> GetAllUsers()
        {
            var users = _bankDAO.GetBankUsers();

            return users.Select(u => new BankAppUser()
            {
                DOB = u.DOB.ToString(),
                EntityId = u.EntityId,
                FirstName = u.FirstName,
                Surname = u.Surname,
                Username = u.Username

                // Not including the password and salt


            }).ToList();
        }



        // Feature: List all users
        // Requirements:
        //      Only users with checking accounts
        public IEnumerable<BankAppUser> GetAllUsersWithCheckingAccounts()
        {
            var users = _bankDAO.GetBankUsers();
            var usersWithChecking = new List<BankAppUser>();


            foreach (var u in users)
            {
                if (_bankDAO.GetBankAccountsBy(u.EntityId).Any(a => a.BankAccountTypeValue == (int)BankAccountType.Checking))
                {
                    usersWithChecking.Add(new BankAppUser()
                    {
                        DOB = u.DOB.ToString(),
                        EntityId = u.EntityId,
                        FirstName = u.FirstName,
                        Surname = u.Surname,
                        Username = u.Username

                        // Not including the password and salt


                    });
                }
            }



            return usersWithChecking;
        }


    }
}
