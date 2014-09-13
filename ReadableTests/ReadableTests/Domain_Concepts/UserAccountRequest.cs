using System;

namespace TestsSwissArmyKnife
{
    public class UserAccountRequest
    {
        public UserAccountRequest()
        {
        }
        
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }


        public UserAccountRequest(string email, DateTime dateOfBirth, string phoneNumber, string password, string name)
        {
            Email = email;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Password = password;
            Name = name;
        }
    }
}