using System;
using System.Collections.Generic;

namespace EShopSimulator
{
    public class Item
    {
        public string itemName;
        public float itemPrice;
        public int itemQuantity;

        public Item(string name, float price, int quantity)
        {
            itemName = name;
            itemPrice = price;
            itemQuantity = quantity;
        }

        public override string ToString()
        {
            return "Product Name: [" + itemName + "] Price: [" + itemPrice + "] Quantity: [" + itemQuantity + "]";
        }
    }
}
