
using Company.BankApp.Entities;
using System.Collections.Generic;

namespace Company.BankApp.DataAccess.Abstractions
{
    // Lecture: Notice how the method signatures pays close attention to the
    // return types of the Get() methods.  This is an example of how you can 
    // enforce business rules by relying on the innate data structure.  In this
    // case, the use of ISet<T> is enforcing the business rule of no duplicates.
    public interface IBankDAO
    {
        bool AddBankUser(BankAppUserEntity bankUser);
        ISet<BankAppUserEntity> GetBankUsers();


        bool AddBankAccount(BankAccountEntity bankAccount);
        ISet<BankAccountEntity> GetBankAccountsBy(string bankUserId);


        bool CreditAccount(string bankAccountId, decimal amount);

        bool DebitAccount(string bankAccountId, decimal amount);


        //bool TransferFunds(string sourceAccountId, string destinationAccountId, decimal amount);

    }
}
