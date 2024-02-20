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
        
        public User(string userId, string userPassword, string userFirstName, string userLastName, string userType){
            _userId = userId;
            _userPassword = userPassword;
            _userFirstName = userFirstName;
            _userLastName = userLastName;
            _userType = userType;
        }
        public virtual string GetStringRepresentation(){
            return $"{userId}|{userPassword}|{userFirstName}|{userLastName}|{userType}";
        }
        public virtual List<string> GetMenu(){
            List<string> options = new List<string>(){
                "1",
                "2"
            };
            Console.Write("Menu Options:\n 1. Sign Out\n 2. Search Inventory\n\nSelect a choice from the menu: ");
            return options;
        }
    }