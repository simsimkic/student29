/***********************************************************************
 * Module:  RegisteredUser.cs
 * Purpose: Definition of the Class SystemUsers.RegisteredUser
 ***********************************************************************/

using System;

namespace Model.SystemUsers
{
   public class RegisteredUser
   {
        private Address adress;

        private String username;
        private String password;
        private String name;
        private String surname;
        private long id;

        public RegisteredUser(Address adress, string username, string password, string name, string surname, long id)
        {
            Address = adress;
            Username = username;
            Password = password;
            Name = name;
            Surname = surname;
            Id = id;
        }

        public RegisteredUser(long id, string name, string surname)
        {
            Name = name;
            Surname = surname;
            Id = id;
        }

        public RegisteredUser()
        {
            Address = new Address();
            Username = "";
            Password = "";
            Name = "";
            Surname = "";
            Id = 0;
        }

        public Address Address { get => adress; set => adress = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public long Id { get => id; set => id = value; }
    }
}