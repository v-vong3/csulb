using Company.BankApp.DataAccess.Abstractions;
using Company.BankApp.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Company.BankApp.DataAccess
{
    // Lecture: Example of how you can reuse an interface for a different technology
    // without it impacting the rest of your application code.
    public class SqlBankDAO : IBankDAO
    {
        private readonly string _connectionString;

        private static string UserTable => nameof(BankAppUserEntity);
        private static string AccountTable => nameof(BankAccountEntity);

        public SqlBankDAO(string connectionString)
        {
            _connectionString = connectionString;
        }


        public bool AddBankUser(BankAppUserEntity bankUser)
        {
            // Assign key
            bankUser.EntityId = $"{UserTable}_{DateTime.UtcNow.ToString(FormatDefaults.UserFormat)}";

            using (var conn = new SqlConnection(_connectionString))
            {
                // Lecture: 
                // For simplicity the asynchronous methods are not being used, but since this
                // operation is IO bound, it is best practice to leverage the respective asynchronous 
                // methods instead
                conn.Open();

                using (var command = new SqlCommand())
                {
                    command.Transaction = conn.BeginTransaction();
                    command.Connection = conn;
                    command.CommandTimeout = TimeSpan.FromSeconds(60).Seconds;
                    command.CommandType = CommandType.Text;


                    // Lecture: 
                    // Avoid building dynamic SQL string statements as it can lead to 
                    // SQL injection vulnerabilities. 
                    command.CommandText =
                        $"INSERT INTO BankUser(EntityId,CreateDate,Username,PasswordHash,Salt,DOB)" +
                        $"SELECT {bankUser.EntityId},{DateTime.UtcNow}," +
                        $"{bankUser.Username},{bankUser.PasswordHash},{bankUser.Salt},{bankUser.DOB}";

                    #region SQL Injection Protection Example
                    // Lecture:
                    // Use parameterized SQL commands to limit SQL injection attack vector by  
                    // leveraging ADO.NET security checks by using SqlParameter.
                    // The better alternative is to call a SQL Stored Procedure
                    // and pass values through SqlParameters. 
                    command.CommandText =
                        "INSERT INTO BankUser(EntityId,CreateDate,Username,PasswordHash,Salt,DOB)" +
                        "SELECT @v0,@v1,@v2,@v3,@v4,@v5";

                    var parameters = new SqlParameter[6];
                    parameters[0] = new SqlParameter("@v0", bankUser.EntityId);
                    parameters[1] = new SqlParameter("@v1", DateTime.UtcNow);
                    parameters[2] = new SqlParameter("@v2", bankUser.Username);
                    parameters[3] = new SqlParameter("@v3", bankUser.PasswordHash);
                    parameters[4] = new SqlParameter("@v4", bankUser.Salt);
                    parameters[5] = new SqlParameter("@v5", bankUser.DOB);


                    command.Parameters.AddRange(parameters);
                    #endregion


                    #region Reflection Example (Code Introspection)
                    command.CommandText =
                        "INSERT INTO BankUser(EntityId,CreateDate,Username,PasswordHash,Salt,DOB)" +
                        "SELECT ";

                    // Lecture: When using Reflection, always make sure to target the class members
                    // as narrow as possible to avoid letting false positives in. Remember that 
                    // all objects in C# are derived from System.Object, thus they will contain
                    // common methods which is often overlooked and can impact Reflection code.
                    var flags = BindingFlags.Public | BindingFlags.Instance;
                    var properties = typeof(BankAppUserEntity).GetProperties(flags)
                                                     .Where(p => p.CanRead)
                                                     .Where(p => p.CanWrite)
                                                     .Where(p => p.PropertyType.IsPrimitive);

                    foreach (var p in properties)
                    {
                        command.CommandText += $"@{p.Name},";
                        command.Parameters.AddWithValue(p.Name, p.GetValue(bankUser));
                    }
                    // Remove last comma
                    command.CommandText = command.CommandText.Remove(command.CommandText.Length - 1);

                    #endregion


                    var rowsAdded = command.ExecuteNonQuery();

                    if (rowsAdded == 1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public ISet<BankAppUserEntity> GetBankUsers()
        {
            throw new NotImplementedException();
        }

        public bool AddBankAccount(BankAccountEntity bankAccount)
        {
            throw new NotImplementedException();
        }

        public ISet<BankAccountEntity> GetBankAccountsBy(string bankUserId)
        {
            throw new NotImplementedException();
        }

        public bool CreditAccount(string bankAccountId, decimal amount)
        {
            throw new NotImplementedException();
        }

        public bool DebitAccount(string bankAccountId, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
