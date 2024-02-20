using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace FinalProject
{
    public class Manager
    {
        private List<Item> itemList = new List<Item>();
        private List<User> userList = new List<User>();

        User user = new User("","","","","");
        Item item = new Item(){};
        User signedUser = new User("","","","","");

        private bool signedIn = false;

        public Manager() {
            LoadUsers();
            LoadItems();
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
                EndProgram();
            }
        }

        public void Display()
        {
            string userInput = "";
            while(userInput!="1"){
                Console.Clear();
                Console.Write($"Welcome {signedUser.userFirstName} {signedUser.userLastName} to the Inventory Manager\n");
                if(signedUser.userType == "supervisor"){
                    ItemsRestock();
                }
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

        public string CheckInventory(string itemName)
        {
            bool found = false;
            string result="";
            foreach(Item item in itemList){
                if(item.itemName.ToLower().Contains(itemName.ToLower())){
                    switch (signedUser.userType)
                    {
                        case "supervisor":
                            result += $"\n\n Item Id: {item.itemId}\n Name: {item.itemName}\n Price: ${item.itemPrice}\n Stock: {item.itemStock} {item.itemUnit}\n Restock: {item.itemRestock} {item.itemUnit}";
                            found = true;
                            break;
                        case "seller":
                            result += $"\n\n Item Id: {item.itemId}\n Name: {item.itemName}\n Price: ${item.itemPrice}\n Stock: {item.itemStock} {item.itemUnit}";
                            found = true;
                            break;
                        case "customer":
                            result += $"\n\n Item Id: {item.itemId}\n Name: {item.itemName}\n Price: ${item.itemPrice}";
                            found = true;
                            break;
                    }
                }
            }
            if(!found){                
                result = "No item found";
            }
            return result;
        }

        public void SearchItem(){
            Console.Clear();
            Console.Write("Enter item name: ");
            string itemName = Console.ReadLine();
            Console.WriteLine("\nResult:"+CheckInventory(itemName));
            Console.Write("\nPress Enter to continue...");
            Console.ReadLine();
        }
        public void AddItem(){
            string userInput = "y";
            while(userInput == "y"){
                Console.Clear();
                Item item = new Item();
                int i = 0;
                if(itemList.Count>0){
                    foreach(Item items in itemList){
                        if(items.itemId-1 == i){
                            i++;
                        }
                    }
                    item.itemId = i+1;
                }
                else{                    
                    item.itemId = itemList.Count()+1;
                }

                Console.Write("Enter Item Name: ");
                item.itemName = Console.ReadLine();
                foreach(Item items in itemList)
                {
                    while(item.itemName == items.itemName)
                    {
                        Console.Write("Item already exists, enter another Item Name: ");
                        item.itemName = Console.ReadLine();
                    }
                }
                Console.Write("Enter Item Price: ");
                item.itemPrice = double.Parse(Console.ReadLine());
                Console.Write("Enter Item Stock: ");
                item.itemStock = double.Parse(Console.ReadLine());
                Console.Write("Enter Item Unit: ");
                item.itemUnit = Console.ReadLine();
                Console.Write("Enter Item Restock: ");
                item.itemRestock = double.Parse(Console.ReadLine());
                itemList.Add(item);
                Console.Clear();
                Console.Write("Item successfully added.");
                Thread.Sleep(2000);
                userInput = "";
                while(userInput!="y" && userInput!="n"){
                    Console.Clear();
                    Console.Write("Add another item y/n? ");
                    userInput = Console.ReadLine();
                }
                List<Item> SortedList = itemList.OrderBy(i=>i.itemId).ToList();
                itemList.Clear();
                itemList = SortedList;
                SaveItem();
            }
        }
        public void RemoveItem(){
            Item itemToRemove = new Item();
            Console.Clear();
            Console.Write("Enter Item Id to remove: ");
            int itemId = int.Parse(Console.ReadLine());
            foreach(Item item in itemList){
                if(item.itemId == itemId){
                    itemToRemove = item;
                }
            }
            itemList.Remove(itemToRemove);
            SaveItem();
            Console.Clear();
            Console.Write("Item correctly removed.");
            Thread.Sleep(2000);
        }
        public void UpdateItem(){
            Console.Clear();
            Console.Write("Enter the item Id to Update: ");
            int itemId = int.Parse(Console.ReadLine());
            foreach(Item item in itemList){
                if(item.itemId == itemId){
                    Console.Write($"Would you like to Update {item.itemName} y/n? ");
                    string userInput = Console.ReadLine();
                    if(userInput=="y"){
                        Console.Write("Enter Item Name: ");
                        item.itemName = Console.ReadLine();
                        Console.Write("Enter Item Price: ");
                        item.itemPrice = double.Parse(Console.ReadLine());
                        Console.Write("Enter Item Stock: ");
                        item.itemStock = double.Parse(Console.ReadLine());
                        Console.Write("Enter Item Unit: ");
                        item.itemUnit = Console.ReadLine();
                        Console.Write("Enter Item Restock: ");
                        item.itemRestock = double.Parse(Console.ReadLine());
                    }
                }
            }

            SaveItem();
        }

        public void SaveItem(){
            string filename = "items.txt";

            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Item item in itemList)
                {
                    outputFile.WriteLine(item.itemId + "|" + item.itemName + "|" + item.itemPrice + "|" + item.itemStock + "|" + item.itemUnit + "|" + item.itemRestock);
                }
            }
        }
        
        public void LoadItems() {
            string filename = "items.txt";
            string[] lines = System.IO.File.ReadAllLines(filename);
            itemList.Clear();
            foreach (string line in lines)
            {
                string[] parts = line.Split("|");
                string userType = parts[4];
                Item item = new Item();
                item.itemId = int.Parse(parts[0]);
                item.itemName = parts[1];
                item.itemPrice = double.Parse(parts[2]);
                item.itemStock = double.Parse(parts[3]);
                item.itemUnit = parts[4];
                item.itemRestock = double.Parse(parts[5]);

                itemList.Add(item);
            }
        }

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

        //Method used for finishing the program
        public void EndProgram(){
        Console.Clear();
        Console.Write("Thank you for using the program");
        Thread.Sleep(2000);                
        System.Environment.Exit(1);   
        }

        public void ItemsRestock(){
            Console.WriteLine("\nItems to Restock:\n\nId | Name & Units Left\n----------------------");
            foreach(Item item in itemList){
                if(item.itemStock <= item.itemRestock){
                    Console.WriteLine(" " + item.itemId + " | " + item.itemName +" "+ item.itemStock + " " +item.itemUnit);
                }
            }
            Console.WriteLine("");
        }
    }
}