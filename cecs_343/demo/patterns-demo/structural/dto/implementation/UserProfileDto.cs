using patterns_demo.structural.dto.contract;

namespace patterns_demo.structural.dto.implementation
{
    /// <summary>
    /// UI model for a User's profile
    /// </summary>
    public class UserProfileDto : IUserProfile
    {
        public string Username {get;}
        public string Role {get;}

        // Note 1: Data type is a string instead of a DateTime object
        // .NET DateTime object also contains time information.  For a Date of Birth, we just want
        // the month, day and year in MM/DD/YY format so we converted it into a string
        public string DOB {get; set;} 

        // Note 2: Full name instead of separate FirstName and LastName properties
        // We only needed the full name of the user so if the UserProfile.cs added a middle name field
        // It would not require a change to this DTO
        public string FullName {get; set;} 

        // Note 3: Missing UserId property
        // Internal identifiers are typically not meant to be exposed outside of an application. 
        // In this case, it is for internal use only so we
        // don't want to leak this information out to the UI boundary 

        // Note 4: Missing SSN property
        // Obviously, we do not want to leak a user's SSN unlike certain credit bureaus,
        // therefore, we are not sending out to the UI boundary

    }
}