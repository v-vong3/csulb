namespace ConsoleApp_OldApi;

class Program
{
    // Notice that the "args" is explicitedly defined here as a parameter of Main() method
    // In the ConsoleApp-MinApi, the namespace (ConsoleApp_OldApi), class (Program) and
    // the Main() method are hidden 
    static void Main(string[] args)
    {

        // The output of the following code will be the same as ConsoleApp-MinApi

        Console.WriteLine($"Length: {args.Length}");
        Console.ReadLine();


        /* Example of Composition Root

            var authDAO = new AuthDAO();
            var authChecker = new AuthChecker(authDAO);
            var accountManager = new AccountManager(authChecker);

            var result = accountManager.CreateAccount();

            if(result)
            {
                Console.WriteLine("Account created")
            }

          
        */

    }
}

