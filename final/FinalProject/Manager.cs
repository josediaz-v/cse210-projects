using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace FinalProject
{
    public class Manager
    {
        private List<Item> itemList = new List<Item>();
        private List<User> userList = new List<User>();

        User user = new User("","","","","");
        Item item = new Item();
        User signedUser = new User("","","","","");

        private bool signedIn = false;

        public Manager() {
            LoadUsers();
            while(!signedIn)
            {
                Start();
                while(signedIn){
                    Display();
                }
            }
        }
        public void Start()
        {
            Console.Clear();
            Console.Write("Welcome to the Inventory Manager\nMenu Options:\n 1. Sign in\n 2. Create user\n 3. Exit\n\nSelect a choice from the menu: ");
            string userInput = Console.ReadLine();
            if(userInput == "1")
            {
                SignIn();
            }
            else if(userInput == "2")
            {
                CreateUser();
            }
            else if(userInput == "3"){                
                System.Environment.Exit(1);
            }
        }

        public void Display()
        {
            string userInput = "";
            while(userInput!="1"){
                Console.Clear();
                Console.Write($"Welcome {signedUser.userFirstName} {signedUser.userLastName} to the Inventory Manager");
                List<string> options = signedUser.GetMenu();
                userInput = Console.ReadLine();
                if(options.Contains(userInput)){
                    switch(userInput){  
                        case "1":
                            SignOut();
                            break;
                        case "2":
                            SearchItem();
                            break;
                        case "3":
                            UpdateItem();
                            break;
                        case "4":
                            AddItem();
                            break;
                        case "5":
                            RemoveItem();
                            break;
                    }
                }
            }
        }

        public string CheckInventory(int itemId)
        {
            string result="";
            switch (user.userType)
            {

                case "supervisor":
                    result = $"{itemId}: {item.itemName} / ${item.price} / {item.itemStock} {item.itemUnit} / {item.itemRestock} {item.itemUnit}";
                    break;
                case "seller":
                    result = $"{itemId}: {item.itemName} / ${item.price} / {item.itemStock} {item.itemUnit}";
                    break;
                case "customer":
                    if (item.itemStock > 0)
                    {
                        result = $"{itemId}: {item.itemName} / ${item.price}";
                    }
                    else
                    {
                        result = "No item found";
                    }
                    break;

            }
            
            return result;
        }

        //Methods used to manipulate an item
        public void SearchItem(){ }
        public void AddItem(){ }
        public void RemoveItem(){ }
        public void UpdateItem(){ }

        //Methods for writing and reading from file
        public void LoadUsers() {
            string filename = "users.txt";
            string[] lines = System.IO.File.ReadAllLines(filename);
            userList.Clear();
            foreach (string line in lines)
            {
                string[] parts = line.Split("|");
                string userType = parts[4];
                switch(userType){
                    case "supervisor":
                        Supervisor supervisor = new Supervisor(parts[0], parts[1], parts[2], parts[3], parts[4]);
                        userList.Add(supervisor);
                        break;
                    case "seller":
                        Seller seller = new Seller(parts[0], parts[1], parts[2], parts[3], parts[4]);
                        userList.Add(seller);
                        break;
                    case "customer":
                        Customer customer = new Customer(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6]);
                        userList.Add(customer);
                        break;
                }
            }
        }

        //Save userList to users.txt file
        public void SaveUsers() {
            string filename = "users.txt";

            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (User user in userList)
                {
                    outputFile.WriteLine(user.GetStringRepresentation());
                }
            }
        }

        //Methods for signing in
        public void SignIn() {
            while(!signedIn)
            {
                Console.Clear();
                Console.Write("Enter your id: ");
                string userId = Console.ReadLine();
                Console.Write("Enter your password: ");
                string userPassword = Console.ReadLine();
                signedIn = CheckUser(userId, userPassword);
                /*if(signedIn)
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome {signedUser.userFirstName} {signedUser.userLastName}");
                    Thread.Sleep(1000);
                }*/
                if(!signedIn)
                {
                    Console.Clear();
                    Console.Write("Wrong user or password, try again y/n? ");
                    string userInput = Console.ReadLine();
                    if(userInput == "n")
                    {
                        break;
                    }
                }
            }            
        }

        //Method for signing out
        public void SignOut() {
            signedIn = false;
        }

        //Method used to check if the userId corresponds with the userPassword
        public bool CheckUser(string userId, string userPassword) {
            bool result = false;
            foreach(User user in userList)
            {
                if (user.userId == userId && user.userPassword == userPassword)
                {
                    signedUser = user;
                    result = true;
                }
            }
            return result;
        }

        //Method for creating user
        public void CreateUser()
        {
            Console.Clear();
            
            Console.Write("Enter User ID: ");
            string userId = Console.ReadLine();
            foreach(User users in userList)
            {
                while(userId == users.userId)
                {
                    Console.Write("User already exists, enter another User ID: ");
                    userId = Console.ReadLine();
                }
            }
            Console.Write("Enter Password: ");
            string userPassword = Console.ReadLine();
            Console.Write("Enter First Name: ");
            string userFirstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string userLastName = Console.ReadLine();

            bool typeCheck = false;
            while(!typeCheck){
                Console.Write("Are you a \"supervisor\", \"seller\" or \"customer\"? ");
                string userType = Console.ReadLine();
                switch(userType){
                    case "supervisor":
                        Supervisor supervisor = new Supervisor(userId, userPassword, userFirstName, userLastName, "supervisor");
                        userList.Add(supervisor);
                        typeCheck = true;
                        break;
                    case "seller":
                        Seller seller = new Seller(userId, userPassword, userFirstName, userLastName, "seller");
                        userList.Add(seller);
                        typeCheck = true;
                        break;
                    case "customer":
                        Console.Write("Enter Phone Number: ");
                        string userPhone = Console.ReadLine();
                        Console.Write("Enter Email: ");
                        string userEmail = Console.ReadLine();
                        Customer customer = new Customer(userId, userPassword, userFirstName, userLastName, "customer", userPhone, userEmail);
                        userList.Add(customer);
                        typeCheck = true;
                        break;
                    default:
                        typeCheck = false;
                        break;
                }
            }

            SaveUsers();
        }
    }
}