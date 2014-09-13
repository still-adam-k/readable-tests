using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using ReadableTests.Builder;
using TestsSwissArmyKnife;
using Xunit;

namespace ReadableTests
{
    public class GIVEN_UserRegistrationService
    {
        [Fact]
        public void THEN_credit_card_number_is_masked()
        {
            var expectedUser = new UserAccount("myName", "myEmail", DateTime.Parse("1990-10-10"), "123456789",
                "password", "4111222233337890");

            UserRegistrationService service = new BuildUserRegistrationService()
                .ForAccount(123)
                .Return(expectedUser);

            var returnedUser = service.GetUserInformation(123);

            Assert.Equal("41**********7890", returnedUser.CreditCardNo);
        }

    }
}
