using System;

namespace Company.BankApp.DomainModels
{
    // Lecture: It is best practice to consolidate
    // attributes into a common base class.
    // Also, C# properties are preferred versus fields 
    // as it makes Code Reflection easier.
    public abstract class EntityBase
    {
        public string EntityId { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        public DateTimeOffset? UpdateDate { get; set; }

    }
}
