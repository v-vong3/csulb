using Company.BankApp.DataAccess;
using Company.BankApp.DataAccess.Abstractions;
using Company.BankApp.DomainModels;
using Company.BankApp.Managers;
using Company.BankApp.Services;
using System;

namespace Company.BankApp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {


            while (true)
            {
                PrintMenu();

                switch (Console.ReadLine())
                {
                    case "1":
                        CreateUser();
                        break;

                    case "2":
                        ShowUsers();
                        break;

                    case "3":
                        CreateBankAccount();
                        break;

                    case "4":
                        ShowBankAccounts();
                        break;

                    default:
                        break;
                }
            }


        }


        static void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("\t\t\t 1) Create User");
            Console.WriteLine("\t\t\t 2) Show Users");
            Console.WriteLine("\t\t\t 3) Create Bank Account");
            Console.WriteLine("\t\t\t 4) Show Bank Accounts");
            Console.WriteLine();
        }

        static void CreateUser()
        {
            BankAppUserManager manager = new BankAppUserManager();

            Console.Write("Enter Username: ");

            var username = Console.ReadLine();

            var bankAppUser = new BankAppUser()
            {
                Username = username
            };

            manager.CreateUser(bankAppUser);

        }

        static void ShowUsers()
        {
            BankAppUserManager manager = new BankAppUserManager();

            var users = manager.GetAllUsers();

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Username} {user.EntityId}");
            }
        }


        static void CreateBankAccount()
        {
            IBankDAO bankDAO = new InMemoryBankDAO();
            BankAccountService service = new BankAccountService(bankDAO);
            BankAccountManager manager = new BankAccountManager(service);


            Console.Write("Enter UserId: ");
            var userId = Console.ReadLine();

            Console.Write("Enter Account Type: ");
            var accountType = int.Parse(Console.ReadLine());

            Console.Write("Enter balance: ");
            var balance = decimal.Parse(Console.ReadLine());

            var newBankAccount = new BankAccount()
            {
                AccountType = (BankAccountType)accountType,
                Owner = new BankAppUser()
                {
                    EntityId = userId
                },
                Balance = balance
            };

            manager.CreateAccount(newBankAccount);

        }

        static void ShowBankAccounts()
        {
            IBankDAO bankDAO = new InMemoryBankDAO();
            BankAccountService service = new BankAccountService(bankDAO);
            BankAccountManager manager = new BankAccountManager(service);

            Console.WriteLine("Enter UserId");
            var userId = Console.ReadLine();


            var accounts = manager.GetUserBankAccounts(userId);

            foreach (var account in accounts)
            {
                Console.WriteLine($"{account.EntityId} - {(int)account.AccountType} has ${account.Balance}");
            }

        }


    }
}
