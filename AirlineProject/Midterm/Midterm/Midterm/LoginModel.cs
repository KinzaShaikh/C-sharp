using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm
{
    class LoginModel
    {

        //creating auto implemented property.
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int SuperUser { get; set; }

        //creating dictionary of LoginModel.
        public static Dictionary<string, LoginModel> loginDictionary;

        //creating constructors
        public LoginModel() { }

        public LoginModel(int id, string username, string password, int superUser)
        {
            ID = id;
            Username = username;
            Password = password;
            SuperUser = superUser;
        }
    }
}
