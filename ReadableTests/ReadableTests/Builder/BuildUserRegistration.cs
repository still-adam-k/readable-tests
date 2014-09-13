using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using TestsSwissArmyKnife;

namespace ReadableTests.Builder
{
    class BuildUserRegistrationService
    {
        private UserAccount defaultUserToReturn;
        private int forAccountReturn;

        public BuildUserRegistrationService()
        {
            defaultUserToReturn = new UserAccount("", "", new DateTime(), "", "");
        }

        public BuildUserRegistrationService ForAccount(int id)
        {
            forAccountReturn = id;
            return this;
        }

        public BuildUserRegistrationService Return(UserAccount user)
        {
            this.defaultUserToReturn = user;
            return this;
        }

        private UserRegistrationService Build()
        {
            var service = new UserRegistrationService();
            var mock = new Mock<IUserRepository>();
            mock.Setup(o => o.GetUser(forAccountReturn)).Returns(defaultUserToReturn);
            service.UsersRepository = mock.Object;
            return service;
        }

        public static implicit operator UserRegistrationService(BuildUserRegistrationService builder)
        {
            return builder.Build();
        }
    }
}
