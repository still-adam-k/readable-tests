using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using TestsSwissArmyKnife._01_Builder;
using Xunit;

namespace TestsSwissArmyKnife
{
    public class GIVEN_User_Registration_Service_and_User_Account_Request
    {
        [Fact]
        public void THEN_user_has_been_added()
        {
            UserAccountRequest userRequest = new BuildUserRequest().WithPhoneNumber("123456789");
            var subject = new UserRegistrationService();

            subject.RegisterUser(userRequest);

            subject.Users.Should().Contain(user => user.PhoneNumber == "123456789");

            Console.WriteLine(userRequest);
        }

        [Fact]
        public void and_no_password_THEN_result_is_insufficient_parameters()
        {
            var subject = new UserRegistrationService();
            var userRequest = new BuildUserRequest()
                .WithPassword("");

            var result = subject.RegisterUser(userRequest);

            result.Should().BeOfType<TooFewDataPassed>();
        }

        [Fact]
        public void and_user_has_less_than_16_years_THEN_result_is_user_too_young()
        {
            var subject = new UserRegistrationService();
            var userData = new BuildUserRequest()
                .WithBirthDate("2010-10-01");

            var result = subject.RegisterUser(userData);

            result.Should().BeOfType<UserIsTooYoung>();

        }

        [Fact]
        public void THEN_we_can_do_many_things_with_fluent_assertions()
        {
            var subject = new UserRegistrationService();
            var userData = new BuildUserRequest()
                .WithBirthDate("2010-10-01");

            var result = subject.RegisterUser(userData);

            subject.Invoking(x => x.RegisterUser(null)).ShouldThrow<NullReferenceException>();

            subject.ExecutionTimeOf(x => x.RegisterUser(userData)).ShouldNotExceed(new TimeSpan(0, 0, 1));
        }

        [Fact]
        public void THEN_we_can_use_value_comparison()
        {
            var userRequest = new UserAccountRequest() { Email = "foo@bar.com"};
            var second_userRequest = new UserAccountRequest() { Email = "foo@bar.com" };


            Assert.Equal(userRequest, second_userRequest);
            //userRequest.ShouldBeEquivalentTo(second_userRequest);
        }
    }
}
