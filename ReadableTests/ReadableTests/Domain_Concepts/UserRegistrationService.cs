using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace TestsSwissArmyKnife
{
    class UserRegistrationService
    {
        private List<UserAccount> users;

        public IUserRepository UsersRepository { get; set; }

        public UserRegistrationService()
        {
            users = new List<UserAccount>();
        }

        internal RegistrationResult RegisterUser(UserAccountRequest userAccountRequest)
        {
            if (string.IsNullOrEmpty(userAccountRequest.Email) || string.IsNullOrEmpty(userAccountRequest.Name) ||
                string.IsNullOrEmpty(userAccountRequest.Password) || userAccountRequest.DateOfBirth == DateTime.MinValue)
            {
                return new TooFewDataPassed();
            }

            if (userAccountRequest.DateOfBirth > DateTime.UtcNow.AddYears(-16))
            {
                return new UserIsTooYoung();
            }

            var newCard = new UserAccount(userAccountRequest);
            users.Add(newCard);

            return new RegistrationSuccesfull();
        }

        public IEnumerable<UserAccount> Users { get { return users; } }

        public UserAccount GetUserInformation(int id)
        {
            return UsersRepository.GetUser(id);
        }
    }
    
    public class RegistrationResult
    { }

    public class RegistrationSuccesfull : RegistrationResult
    {
    }

    public class UserIsTooYoung : RegistrationResult
    {
    }

    class TooFewDataPassed : RegistrationResult
    {
    }
}
