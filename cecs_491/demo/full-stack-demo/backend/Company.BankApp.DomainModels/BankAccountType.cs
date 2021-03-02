namespace Company.BankApp.DomainModels
{
    // Lecture: It is a good idea to always make the default
    // value of an enumeration an invalid setting.  This will
    // make sure your code has to actively set a valid value
    // instead of accidentally getting set purely through instantiation.
    public enum BankAccountType
    {
        None,
        Savings,
        Checking,
        Loan
    }
}
