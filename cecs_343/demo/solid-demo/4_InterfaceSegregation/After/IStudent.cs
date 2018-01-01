namespace solid_demo.InterfaceSegregation.After
{
    public interface IStudent
    {
        // Public properties
        string FirstName {get;}
        string LastName {get;}
        string Major {get;}
        bool IsUndergrad {get;}


        // Public methods
        void UpdateMajor(string newMajor);
    }
}