using System;

namespace Company.DataStoreEntities
{
    // Lecture: It is best practice to consolidate
    // common attributes into a single base class to
    // avoid redundant code.
    // All properties here are common meta-data that
    // you would want each record to have.
    // Also, C# properties are preferred versus fields 
    // as it makes Code Reflection easier.
    public abstract class EntityBase
    {
        public virtual string EntityId { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        public DateTimeOffset? UpdateDate { get; set; }

    }
}
