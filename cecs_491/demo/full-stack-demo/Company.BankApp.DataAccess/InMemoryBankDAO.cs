
using Company.BankApp.DataAccess.Abstractions;
using Company.BankApp.Entities;
using Company.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Company.BankApp.DataAccess
{
    public class InMemoryBankDAO : IBankDAO
    {

        private readonly InMemoryDataStore _ds;
        private static string UserTable => nameof(BankAppUserEntity);
        private static string AccountTable => nameof(BankAccountEntity);

        public InMemoryBankDAO()
        {
            _ds = new InMemoryDataStore(nameof(InMemoryBankDAO));
            _ds.CreateTable(UserTable);
            _ds.CreateTable(AccountTable);
        }

        public ISet<BankAppUserEntity> GetBankUsers()
        {
            var allUsers = new HashSet<BankAppUserEntity>();

            foreach (var user in _ds.GetRows(UserTable))
            {
                allUsers.Add((BankAppUserEntity)user);
            }

            return allUsers;
        }

        public bool AddBankUser(BankAppUserEntity bankUser)
        {
            // Lecture: Depending on the technology, the developer maybe responsible for assigning
            // the universally unique identifier (UUID) for each entity record.  The easier way to
            // do this is to use the date.  However, this may not be an option if you are 
            // expecting multiple records being created at the same exact time, which is a very
            // common need in modern systems. Using one of the predefined UUID algorithm would
            // be better, specifically the UUID version 2.  If you are using a RDBMS, then use the 
            // built-in capabilities instead of defining your own.

            // Assign key
            bankUser.EntityId = $"{UserTable}_{DateTime.UtcNow.ToString(FormatDefaults.UserFormat)}";

            var bankUsers = GetBankUsers();

            if (bankUsers.Contains(bankUser))
            {
                // Business Rule: Cannot add duplicate
                return false;
            }

            return _ds.AddOrUpdate(UserTable, bankUser);
        }



        public ISet<BankAccountEntity> GetBankAccountsBy(string bankUserId)
        {
            var accounts = _ds.GetRows(AccountTable).Select(x => (BankAccountEntity)x)
                                                    .Where(x => x.OwnerId == bankUserId)
                                                    .ToHashSet();

            return accounts;
        }


        public bool AddBankAccount(BankAccountEntity bankAccount)
        {
            #region Argument Guards
            if (bankAccount is null)
            {
                throw new ArgumentNullException(nameof(bankAccount));
            }
            #endregion


            #region Business Rules
            if (String.IsNullOrWhiteSpace(bankAccount.OwnerId))
            {
                throw new ArgumentException($"Invalid {nameof(bankAccount.OwnerId)}");
            }

            if (!GetBankUsers().Select(x => x.EntityId).Contains(bankAccount.OwnerId))
            {
                throw new Exception($"Only existing users can have bank accounts");
            }
            #endregion

            // Assign key
            bankAccount.EntityId = $"{AccountTable}_{DateTime.UtcNow.ToString(FormatDefaults.BankAccountFormat)}";


            return _ds.AddOrUpdate(AccountTable, bankAccount);
        }

        public bool CreditAccount(string bankAccountId, decimal amount)
        {
            var account = _ds.GetRows(AccountTable).Select(x => (BankAccountEntity)x)
                                                   .Where(x => x.EntityId == bankAccountId)
                                                   .FirstOrDefault();


            account.Balance += amount;

            return _ds.AddOrUpdate(AccountTable, account);
        }

        public bool DebitAccount(string bankAccountId, decimal amount)
        {
            var account = _ds.GetRows(AccountTable).Select(x => (BankAccountEntity)x)
                                                   .Where(x => x.EntityId == bankAccountId)
                                                   .FirstOrDefault();


            account.Balance -= amount;

            // What if balance is < 0?

            return _ds.AddOrUpdate(AccountTable, account);
        }
    }
}
