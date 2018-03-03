using patterns_demo.structural.dto.contract;

namespace patterns_demo.structural.dto.implementation
{
    using System; // For DateTime

    /// <summary>
    /// Domain model for a User's profile
    /// </summary>
    public class UserProfile : IUserProfile
    {
        public string Username {get; set;}
        public string Role {get;}



        public string FirstName {get; set;}
        public string LastName {get; set;}
        public DateTime DOB {get; set;}
        public int UserId {get; set;} // For internal use ONLY
        public string SSN {get; set;} // Social Security Number
    }
}