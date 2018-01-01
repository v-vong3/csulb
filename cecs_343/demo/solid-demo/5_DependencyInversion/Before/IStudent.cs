namespace solid_demo.DependencyInversion.Before
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