namespace patterns_demo.behavioral.repository.implementation
{
    using System;

    /// <summary>
    /// Simple domain object representing a user
    /// </summary>
    public class User
    {
        /// <summary>
        /// Explicit default contructor 
        /// </summary>
        public User()
        {
            UserId = DateTime.UtcNow.Ticks; // Auto-generate a "unique" identifier 

            // Important note:
            //  If you are using a relational database, do not use GUIDs as a unique identifier
            //  as it can lead to severe fragmentation of your data, resulting in performance 
            //  penalties
        }

        public long UserId {get;} // Only can be set by a constructor
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Username {get; set;}
        public string Password {get; set;}
    }
}