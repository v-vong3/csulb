using System;

namespace unit_testing_demo
{
    public class UserProfileManagerV2
    {
        private DatabaseService _dbService;

        public UserProfileManagerV2()
        { 
            _dbService = new DatabaseService();
        }

        public bool HasValidUsername(UserProfile userProfile)
        {
            if(!String.IsNullOrWhiteSpace(userProfile.Username) && 
                userProfile.Username.Length <= 8)
            {
                return true;
            }

            return false;  // Negation is now the default
        }


        public bool HasValidEmail(UserProfile userProfile)
        {
            if(String.IsNullOrWhiteSpace(userProfile.Email))
            {
                return false;
            }

            if(userProfile.Email.IndexOf('@') < 0 || 
                userProfile.Email.IndexOf('@') == userProfile.Email.Length - 1)
            {
                return false;
            }

            return true;
        }


        public bool IsValidAgeRange(UserProfile userProfile)
        {
            if(userProfile.DOB > DateTime.Now ||
                (DateTime.Now - userProfile.DOB).TotalDays < 0 ||
                (DateTime.Now - userProfile.DOB).TotalDays / 365.0 >= 150.0)
            {
                return false;
            }

            return true;
        }

        public bool IsMinor(UserProfile userProfile)
        {
            if((DateTime.UtcNow - userProfile.DOB).TotalDays / 365 < 18)
            {
                return false;
            }

            return true;
        } 

        
        public bool HasValidAddress(Address address) // Notice the parameter's data type
        {
            if(address is null ||
                String.IsNullOrWhiteSpace(address.AddressLine1) || 
                String.IsNullOrWhiteSpace(address.City) ||
                String.IsNullOrWhiteSpace(address.StateCode) ||
                String.IsNullOrWhiteSpace(address.PostalCode))
            {
                return false;
            }

            return true;
        }


        public bool UpdateUserProfile(UserProfile modifiedUserProfile)
        {
            if(HasValidUsername(modifiedUserProfile) &&
                HasValidEmail(modifiedUserProfile) &&
                IsValidAgeRange(modifiedUserProfile) &&
                !IsMinor(modifiedUserProfile) &&
                HasValidAddress(modifiedUserProfile.HomeAddress) &&
                HasValidAddress(modifiedUserProfile.BillingAddress))
            {
                modifiedUserProfile.LastUpdateDate = DateTime.UtcNow;
                
                _dbService.SaveUserProfile(modifiedUserProfile);

                return true;
            }

            return false;
        }

    }
}