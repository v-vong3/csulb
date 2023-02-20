
// Top Level Statements is a new default mode of programming introduced in .NET 6
// It's meant to be easiser to "hit the ground" programming without needing to know
// about things like namespaces and classes.  It also allows for easy code snippet execution/testing.

// Every line of code in this file is actually being executed in a hidden class/hidden Main() method.
// View the ConsoleApp-OldApi to see the actual full code that is being executed at startup



// Notice that the "args" object is accessible even though it's never defined
Console.WriteLine($"Length: {args.Length}");

// Pause console app to see results of print statement
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