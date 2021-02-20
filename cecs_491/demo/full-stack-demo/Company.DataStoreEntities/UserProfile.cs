namespace Company.DataStoreEntities
{
    public class UserProfile : EntityBase
    {
        // Lecture: 
        // Necessary to have a direct link to the
        // UserAccount
        public string UserAccountId { get; set; }


        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string Surname { get; set; }

        public string DefaultLanguage { get; set; }

        public string DefaultUnitsOfMeasure { get; set; }
    }
}
