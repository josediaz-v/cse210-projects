    public class Customer : User
    {
        private string _phoneNumber;
        public string phoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; } }

        private string _email;
        public string email { get { return _email; } set { _email = value; } }

        public Customer(string userId, string userPassword, string userFirstName, string userLastName, string userType, string phoneNumber, string email) : base (userId, userPassword, userFirstName, userLastName, userType){
            _phoneNumber = phoneNumber;
            _email = email;
        }
        public override string GetStringRepresentation(){
            return $"{userId}|{userPassword}|{userFirstName}|{userLastName}|{userType}|{phoneNumber}|{email}";
        }
}