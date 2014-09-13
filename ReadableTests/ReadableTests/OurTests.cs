using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace TestsSwissArmyKnife
{
    public class GIVEN_User_Registration_Service_and_User_Account_Request
    {
        [Fact]
        public void THEN_user_has_been_added()
        {
            var userData = new UserAccountRequest
            {
                Name = "John Kovalsky",
                Email = "someone@somedomain.com",
                DateOfBirth = DateTime.Parse("1990-10-01"),
                Password = "password",
                PhoneNumber = "123456789"
            };
            var subject = new UserRegistrationService();

            subject.RegisterUser(userData);

            Assert.Contains("123456789", subject.Users.Select(user => user.PhoneNumber));
        }

        [Fact]
        public void and_no_password_THEN_result_is_insufficient_parameters()
        {
            var userData = new UserAccountRequest
            {
                Name = "John Kovalsky",
                Email = "someone@somedomain.com",
                DateOfBirth = DateTime.Parse("1990-10-01"),
            };
            var subject = new UserRegistrationService();

            var result = subject.RegisterUser(userData);

            Assert.IsType<TooFewDataPassed>(result);
        }

        [Fact]
        public void and_user_has_less_than_16_years_THEN_result_is_user_too_young()
        {
            var userData = new UserAccountRequest
            {
                Name = "John Kovalsky",
                Email = "someone@somedomain.com",
                DateOfBirth = DateTime.Parse("2010-10-01"),
                Password = "password",
                PhoneNumber = "123456789"
            };
            var subject = new UserRegistrationService();

            var result = subject.RegisterUser(userData);

            Assert.IsType<UserIsTooYoung>(result);
        }

    }
}
