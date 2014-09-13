using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsSwissArmyKnife
{
    public class UserAccount
    {
        public UserAccount(string name, string email, DateTime dateOfBirth, string phoneNumber, string password)
        {
            Name = name;
            Email = email;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Password = password;
        }


        public UserAccount(UserAccountRequest copyObject)
        {
            Email = copyObject.Email;
            DateOfBirth = copyObject.DateOfBirth;
            PhoneNumber = copyObject.PhoneNumber;
            Password = copyObject.Password;
            Name = copyObject.Name;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Password { get; private set; }
    }
}
