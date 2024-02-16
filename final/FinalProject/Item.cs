﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject
{
    public class Item
    {
        private int _itemId;
        public int itemId { get { return _itemId; } set { _itemId = value; } }

        private string _itemName;
        public string itemName { get { return _itemName; } set { _itemName = value; } }

        private double _itemPrice;
        public double itemPrice{ get { return _itemPrice; } set { _itemPrice = value; } }

        private double _itemStock;
        public double itemStock { get { return _itemStock; } set { _itemStock = value; } }

        private string _itemUnit;
        public string itemUnit { get { return _itemUnit; } set { _itemUnit = value; } }

        private double _itemRestock;
        public double itemRestock { get { return _itemRestock; } set { _itemRestock = value; } }

        private double _price;
        public double price { get { return _price; } set { _price = value; } }
    }
}