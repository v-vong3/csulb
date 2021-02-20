using Company.BankApp.DomainModels;
using Company.BankApp.Services;
using System.Collections.Generic;

namespace Company.BankApp.Managers
{
    public class BankAccountManager
    {
        private readonly BankAccountService _bankAccountService;

        public BankAccountManager(BankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }



        // Feature: Create new accounts
        // Requirements:
        //      Savings must have a minimum of 500
        public bool CreateAccount(BankAccount newBankAccount)
        {

            if (newBankAccount.AccountType == BankAccountType.Savings)
            {
                if (newBankAccount.Balance < 500)
                {
                    return false;
                }
            }



            return _bankAccountService.CreateAccount(newBankAccount);
        }


        // Feature: Retrieve all bank accounts 
        // Requirements:
        //      Only your bank accounts is returned
        public ISet<BankAccount> GetUserBankAccounts(string bankAppUserId)
        {
            // Lecture:
            // One major problem of having different models or using the
            // DTO pattern is the need to box values just to be able to 
            // pass along the abstraction layers
            var bankAppUser = new BankAppUser()
            {
                EntityId = bankAppUserId
            };


            return _bankAccountService.GetBankAccounts(bankAppUser);

        }



        // Feature: Transfer Funds between accounts 
        // Requirements:
        //      Must be owner of both source and destination accounts
        //      Can only transfer between checking and savings 
        //      Can only transfer quantity >= 100
        public bool TransferFunds(BankAppUser invokingUser, BankAccount source, BankAccount destination, decimal amount)
        {
            if (source.Owner.EntityId != invokingUser.EntityId || destination.Owner.EntityId != invokingUser.EntityId)
            {
                return false;
            }

            if (source.AccountType != BankAccountType.Checking || source.AccountType != BankAccountType.Savings)
            {
                return false;
            }

            if (destination.AccountType != BankAccountType.Checking || destination.AccountType != BankAccountType.Savings)
            {
                return false;
            }

            if (amount < 100)
            {
                return false;
            }


            return _bankAccountService.TransferFund(source, destination, amount);
        }



    }
}
