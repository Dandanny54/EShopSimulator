using System;
using System.Collections.Generic;

namespace EShopSimulator
{
    class Customer
    {
        public float budget;
        public Item cart;

        public Customer(float b, Item c)
        {
            budget = b;
            cart = c;
        }

        public override string ToString()
        {
            return "Budget: " + budget + " " + cart;
        }
    }
}
