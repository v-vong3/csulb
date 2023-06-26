using System;

namespace unit_testing_demo
{
    public class UserProfile
    {
        public string Username { get; set; }
        public string Email { get; set; }

        public DateTime DOB { get; set; }

        public Address HomeAddress { get; set; } 

        public Address BillingAddress { get; set; } 

        public DateTime LastUpdateDate { get; set; }
    }
}