using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject
{
    public class Manager
    {
        private List<Item> itemList = new List<Item>();

        User user = new User();
        Item item = new Item();
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
        public void LoadFile() { }
        public void SaveFile() { }

        //Methods for sign in or out
        public void SignIn() { }
        public void SignOut() { }
    }
}