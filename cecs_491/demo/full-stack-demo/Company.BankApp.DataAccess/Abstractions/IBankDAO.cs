using Company.BankApp.DomainModels;
using System.Collections.Generic;

namespace Company.BankApp.DataAccess.Abstractions
{
    // Lecture: Notice how the method signatures pays close attention to the
    // return types of the Get() methods.  This is an example of how you can 
    // enforce business rules by relying on the innate data structure.  In this
    // case, the use of ISet<T> is enforcing the business rule of no duplicates.
    public interface IBankDAO
    {
        bool AddBankUser(BankUser bankUser);
        ISet<BankUser> GetBankUsers();


        bool AddBankAccount(BankAccount bankAccount);
        ISet<BankAccount> GetBankAccountsBy(string bankUserId);

    }
}
