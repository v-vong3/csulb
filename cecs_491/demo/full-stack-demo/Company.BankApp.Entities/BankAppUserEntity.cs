using Company.DataStoreEntities;

namespace Company.BankApp.Entities
{
    // Lecture:
    // Leveraging common entities to build application specific entities.
    // Note that the suffix "Entity" is only added to avoid confusion with
    // Domain Models within the Business Layer. Typically you want to avoid
    // such naming conventions unless you absolutely need it
    public class BankAppUserEntity : UserAccount
    {
        public string FirstName { get; set; }

        public string Surname { get; set; }
    }


}
