using Company.DataStoreEntities;

namespace Company.BankApp.Entities
{
    // Lecture:
    // Leveraging common entities to build application specific entities.
    // Note that the suffix "Entity" is only added to avoid confusion with
    // Domain Models within the Business Layer. Typically you want to avoid
    // such naming conventions unless you absolutely need it
    public class BankAccountEntity : EntityBase
    {
        public int BankAccountTypeValue { get; set; }

        public string OwnerId { get; set; }


        public decimal Balance { get; set; }
    }
}
