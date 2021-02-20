using Company.BankApp.DataAccess.Abstractions;
using Company.BankApp.DomainModels;
using Company.BankApp.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Company.BankApp.Services
{
    public class BankAccountService
    {
        private readonly IBankDAO _bankDAO;


        public BankAccountService(IBankDAO bankDAO)
        {
            _bankDAO = bankDAO;
        }




        public ISet<BankAccount> GetBankAccounts(BankAppUser bankAppUser)
        {
            var accountEntities = _bankDAO.GetBankAccountsBy(bankAppUser.EntityId);

            var bankAccounts = accountEntities.Select(x => new BankAccount()
            {
                Balance = x.Balance,
                Owner = bankAppUser,
                AccountType = (BankAccountType)x.BankAccountTypeValue,
                EntityId = x.EntityId
            }).ToHashSet();


            return bankAccounts;

        }





        public bool CreateAccount(BankAccount newAccount)
        {
            var bankAccountEntity = new BankAccountEntity()
            {
                Balance = newAccount.Balance,
                OwnerId = newAccount.Owner.EntityId,
                BankAccountTypeValue = (int)newAccount.AccountType
            };


            return _bankDAO.AddBankAccount(bankAccountEntity);
        }


        public bool TransferFund(BankAccount source, BankAccount destination, decimal amount)
        {
            if (_bankDAO.DebitAccount(source.EntityId, amount))
            {
                if (_bankDAO.CreditAccount(destination.EntityId, amount))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
