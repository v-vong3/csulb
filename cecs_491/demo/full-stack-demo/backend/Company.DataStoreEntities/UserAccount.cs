using System;

namespace Company.DataStoreEntities
{
    // Lecture:
    // Security related attributes and
    // user specific attributes that very rarely 
    // will ever need to be changed
    public class UserAccount : EntityBase
    {
        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public string Salt { get; set; }

        public DateTimeOffset DOB { get; set; }

        public string Role { get; set; }
    }
}
