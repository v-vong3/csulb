using System;
using Xunit;

namespace unit_testing_demo
{
    public class UserProfileManagerTest
    {

        [Fact] // Flags method as a test
        [Trait("Scenario", "Success")]
        public void UpdateUserProfile_WithValidUserProfile_Pass()
        {
            // Arrange
            var profile = new UserProfile()
            {
                Username = "user123",
                Email = "user123@example",
                DOB = new DateTime(2000, 1, 1),
                HomeAddress = new Address()
                {
                    AddressLine1 = "123 Main St",
                    City = "Anytown",
                    StateCode = "ZZ",
                    PostalCode = "12345"
                },
                BillingAddress = new Address()
                {
                    AddressLine1 = "111 Warehouse Drive",
                    AddressLine2 = "Suite ABC",
                    City = "Anytown",
                    StateCode = "ZZ",
                    PostalCode = "12345"
                }
            };
            var sut = new UserProfileManager();

            // Act
            sut.UpdateUserProfile(profile);

            // Assert
        }

        
        [Fact]
        [Trait("Scenario", "Failure")]
        public void UpdateUserProfile_WithInvalidUsername_Fail()
        {
            // Arrange
            var profile = new UserProfile()
            {
                Username = null,
                Email = "user123@example",
                DOB = new DateTime(2000, 1, 1),
                HomeAddress = new Address()
                {
                    AddressLine1 = "123 Main St",
                    City = "Anytown",
                    StateCode = "ZZ",
                    PostalCode = "12345"
                },
                BillingAddress = new Address()
                {
                    AddressLine1 = "111 Warehouse Drive",
                    AddressLine2 = "Suite ABC",
                    City = "Anytown",
                    StateCode = "ZZ",
                    PostalCode = "12345"
                }
            };
            var sut = new UserProfileManager();

            // Act
            sut.UpdateUserProfile(profile);

            // Assert
        }



    }
}