using System;
using Xunit;

namespace unit_testing_demo
{
    public class UserProfileManagerV2Test
    {
        private UserProfile _testProfile;

        public UserProfileManagerV2Test()
        {
            _testProfile = new UserProfile()
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
        }


        [Fact]
        [Trait("Scenario", "Success")] 
        public void UpdateUserProfile_WithValidUserProfile_Pass()
        {
            // Arrange
            var sut = new UserProfileManagerV2();

            // Act
            var actual = sut.UpdateUserProfile(_testProfile);

            // Assert
            Assert.True(actual);
        }

        [Theory]
        [Trait("Scenario", "Failure")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("123456789")]
        public void UpdateUserProfile_WithInvalidUsername_Fail(string testData)
        {
            // Arrange
            var sut = new UserProfileManagerV2();
            _testProfile.Username = testData;

            // Act
            var actual = sut.UpdateUserProfile(_testProfile);

            // Assert
            Assert.True(!actual);
        }



    }
}