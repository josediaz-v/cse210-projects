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

        User user = new User();
        Item item = new Item();
        User signedUser = new User();

        private bool signedIn = false;

        public Manager() {
            LoadUsers();
            while (!signedIn)
            {
                Start();
            }
        }
        public void Start()
        {
            Console.Clear();
            Console.Write("Welcome to the Inventory Manager\nMenu Options:\n 1. Sign in\n 2. Create user\n\nSelect a choice from the menu: ");
            string userInput = Console.ReadLine();
            if(userInput == "1")
            {
                SignIn();
            }
            else if(userInput == "2")
            {
                CreateUser();
            }
        }

        public void Display()
        {

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

        //Methods used by the manager to update an item
        public void AddItem() { }

        public void RemoveItem() { }

        public void UpdateItem() { }

        //Methods for writing and reading from file
        public void LoadUsers() {
            string filename = "users.txt";
            string[] lines = System.IO.File.ReadAllLines(filename);
            userList.Clear();
            foreach (string line in lines)
            {
                string[] parts = line.Split("|");
                
                User user = new User();
                user.userId = parts[0];
                user.userPassword = parts[1];
                user.userFirstName = parts[2];
                user.userLastName = parts[3];
                user.userType = parts[4];

                userList.Add(user);
            }
        }

        //Save userList to users.txt file
        public void SaveUsers() {
            string filename = "users.txt";

            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (User user in userList)
                {
                    outputFile.WriteLine(user.userId + "|" + user.userPassword + "|" + user.userFirstName + "|" + user.userLastName + "|" + user.userType);
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
                if(signedIn)
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome {signedUser.userFirstName} {signedUser.userLastName}");
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong user or password, try again? y/n");
                    string userInput = Console.ReadLine();
                    if(userInput == "n")
                    {
                        break;
                    }
                }
            }            
        }

        //Method for signing out
        public void SignOut() { }

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
            User user = new User();

            Console.Write("Enter User ID: ");
            user.userId = Console.ReadLine();
            foreach(User users in userList)
            {
                while(user.userId == users.userId)
                {
                    Console.Write("User already exists, enter another User ID: ");
                    user.userId = Console.ReadLine();
                }
            }
            Console.Write("Enter Password: ");
            user.userPassword = Console.ReadLine();
            Console.Write("Enter First Name: ");
            user.userFirstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            user.userLastName = Console.ReadLine();
            Console.Write("Are you a Supervisor, Seller or Customer? ");
            user.userType = Console.ReadLine();

            userList.Add(user);

            SaveUsers();
        }
    }
}