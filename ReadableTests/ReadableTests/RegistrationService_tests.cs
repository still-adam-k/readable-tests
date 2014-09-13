using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ReadableTests.Builder;
using TestsSwissArmyKnife;
using Xunit;

namespace ReadableTests
{
    public class GIVEN_UserRegistrationService
    {
        [Fact]
        public void THEN_returns_user_for_that_id()
        {
            var expectedUser = new UserAccount("myName", "myEmail", DateTime.Parse("1990-10-10"), "123456789",
                "password");

            var service = new UserRegistrationService();
            var mock = new Mock<IUserRepository>();
            mock.Setup(o => o.GetUser(It.IsAny<int>())).Returns(expectedUser);
            service.UsersRepository = mock.Object;

            var returnedUser = service.GetUserInformation(123);

            Assert.Equal(expectedUser, returnedUser);
        }

        [Fact]
        public void THEN_returns_user_for_that_id_prettier()
        {
            var expectedUser = new UserAccount("myName", "myEmail", DateTime.Parse("1990-10-10"), "123456789",
                "password");

            UserRegistrationService service = new BuildUserRegistrationService()
                .ForAccount(123)
                .Return(expectedUser);

            var returnedUser = service.GetUserInformation(123);

            Assert.Equal(expectedUser, returnedUser);
        }

    }
}
