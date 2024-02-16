using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject
{
    public class Customer : User
    {
        private int _phoneNumber;
        public int phoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; } }

        private string _email;
        public string email { get { return _email; } set { _email = value; } }
    }
}