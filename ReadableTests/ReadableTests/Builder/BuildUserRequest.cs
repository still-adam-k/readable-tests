using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsSwissArmyKnife._01_Builder
{
    class BuildUserRequest
    {
        private string defaultName;
        private string defaultEmail;
        private string defaultPhoneNumber;
        private string defaultPassword;
        private DateTime defaultBirthDate;

        public BuildUserRequest()
        {
            defaultName = "John Kovalsky";
            defaultEmail = "a@b.com";
            defaultPhoneNumber = "123456789";
            defaultPassword = "password";
            defaultBirthDate = DateTime.Parse("1990-10-01");
        }

        public BuildUserRequest WithBirthDate(string dateTime)
        {
            this.defaultBirthDate = DateTime.Parse(dateTime);
            return this;
        }

        public BuildUserRequest WithEmail(string email)
        {
            this.defaultEmail = email;
            return this;
        }

        public BuildUserRequest WithName(string email)
        {
            this.defaultName = email;
            return this;
        }

        public BuildUserRequest WithPassword(string password)
        {
            this.defaultPassword = password;
            return this;
        }

        public BuildUserRequest WithPhoneNumber(string phoneNumber)
        {
            this.defaultPhoneNumber = phoneNumber;
            return this;
        }

        internal UserAccountRequest Build()
        {
            return new UserAccountRequest
            {
                Name = defaultName,
                Email = defaultEmail,
                DateOfBirth = defaultBirthDate,
                Password = defaultPassword,
                PhoneNumber = defaultPhoneNumber
            };
        }

        public static implicit operator UserAccountRequest(BuildUserRequest builder)
        {
            return builder.Build();
        }
    }
}
