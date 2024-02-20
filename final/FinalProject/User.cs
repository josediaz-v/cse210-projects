using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject
{
    public class User
    {
        private string _userId;
        public string userId { get { return _userId; } set { _userId = value; } }

        private string _userPassword;
        public string userPassword { get { return _userPassword; } set { _userPassword = value; } }

        private string _userFirstName;
        public string userFirstName { get { return _userFirstName; } set { _userFirstName = value; } }

        private string _userLastName;
        public string userLastName {  get { return _userLastName; } set { _userLastName = value; } }

        private string _userType;
        public string userType { get { return _userType; } set { _userType = value; } }
    }
}