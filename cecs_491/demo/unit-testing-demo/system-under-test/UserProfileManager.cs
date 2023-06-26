using System;

namespace unit_testing_demo
{
    public class UserProfileManager
    {
        private DatabaseService _dbService;

        public UserProfileManager()
        { 
            _dbService = new DatabaseService();
        }

        private bool IsValidUserProfile(UserProfile userProfile)
        {
            if(String.IsNullOrWhiteSpace(userProfile.Username) || 
                userProfile.Username.Length > 8)
            {
                return false;
            }

            if(String.IsNullOrWhiteSpace(userProfile.Email))
            {
                return false;
            }

            if(userProfile.Email.IndexOf('@') < 0 || 
                userProfile.Email.IndexOf('@') == userProfile.Email.Length - 1)
            {
                return false;
            }

            if(userProfile.DOB > DateTime.Now ||
                (DateTime.Now - userProfile.DOB).TotalDays < 0)
            {
                return false;
            }

            if((DateTime.Now - userProfile.DOB).TotalDays / 365 < 18 || 
                (DateTime.Now - userProfile.DOB).TotalDays / 365 >= 150)
            {
                return false;
            }

            if(userProfile.HomeAddress is null ||
                String.IsNullOrWhiteSpace(userProfile.HomeAddress.AddressLine1) || 
                String.IsNullOrWhiteSpace(userProfile.HomeAddress.City) ||
                String.IsNullOrWhiteSpace(userProfile.HomeAddress.StateCode) ||
                String.IsNullOrWhiteSpace(userProfile.HomeAddress.PostalCode))
            {
                return false;
            }

            if(userProfile.BillingAddress is null ||
                String.IsNullOrWhiteSpace(userProfile.BillingAddress.AddressLine1) || 
                String.IsNullOrWhiteSpace(userProfile.BillingAddress.City) ||
                String.IsNullOrWhiteSpace(userProfile.BillingAddress.StateCode) ||
                String.IsNullOrWhiteSpace(userProfile.BillingAddress.PostalCode))
            {
                return false;
            }

            return true;
        }

        public void UpdateUserProfile(UserProfile modifiedUserProfile)
        {
            if(IsValidUserProfile(modifiedUserProfile))
            {
                modifiedUserProfile.LastUpdateDate = DateTime.UtcNow;
                
                _dbService.SaveUserProfile(modifiedUserProfile);
            }
        }

    }
}