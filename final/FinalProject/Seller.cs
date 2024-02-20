    public class Seller : User
    {
        public Seller(string userId, string userPassword, string userFirstName, string userLastName, string userType) : base (userId, userPassword, userFirstName, userLastName, userType){

        }
        public override List<string> GetMenu()
        {
            List<string> options = new List<string>(){
                "1",
                "2",
                "3"
            };
            Console.WriteLine("Menu Options:\n 1. Sign Out \n 2. Search Inventory\n 3. Update Item\n\nSelect a choice from the menu: ");
            return options;
        }
    }