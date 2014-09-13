using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using TestsSwissArmyKnife._01_Builder;
using Xunit;

namespace TestsSwissArmyKnife
{
    public class GIVEN_User_Registration_Service_and_User_Account_Request
    {
        [Fact]
        public void THEN_user_has_been_added()
        {
            var userRequest = new BuildUserRequest();
            var subject = new UserRegistrationService();

            subject.RegisterUser(userRequest);

            Assert.Contains("123456789", subject.Users.Select(user => user.PhoneNumber));
        }

        [Fact]
        public void and_no_password_THEN_result_is_insufficient_parameters()
        {
            var subject = new UserRegistrationService();
            var userRequest = new BuildUserRequest()
                .WithPassword("");

            var result = subject.RegisterUser(userRequest);

            Assert.IsType<TooFewDataPassed>(result);
        }

        [Fact]
        public void and_user_has_less_than_16_years_THEN_result_is_user_too_young()
        {
            var subject = new UserRegistrationService();
            var userData = new BuildUserRequest()
                .WithBirthDate("2010-10-01");

            var result = subject.RegisterUser(userData);

            Assert.IsType<UserIsTooYoung>(result);
        }
    }
}
