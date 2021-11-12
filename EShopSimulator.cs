//Alexis D Vera De Jesus
using System;
using System.Collections.Generic;

namespace EShopSimulator
{
    class EShopSimulator
    {
        readonly List<Item> Inventory = new List<Item>();
        readonly List<Item> Cart = new List<Item>();
        public Item soap;
        public Item actionFigure;
        public Item movie;
        public Item cartItem;
        public Customer customer;
        public float customerBudget;
        public bool isCheckout;
        public int itemAmount;
        public int addedItemNumber;
        private int purchasedSoapAmount;

        public int GetPurchasedSoapAmount()
        {
            return purchasedSoapAmount;
        }

        public void SetPurchasedSoapAmount(int value)
        {
            purchasedSoapAmount = value;
        }

        private int purchasedFigureAmount;

        public int GetPurchasedFigureAmount()
        {
            return purchasedFigureAmount;
        }

        public void SetPurchasedFigureAmount(int value)
        {
            purchasedFigureAmount = value;
        }

        private int purchasedMovieAmount;

        public int GetpurchasedMovieAmount()
        {
            return purchasedMovieAmount;
        }

        public void SetpurchasedMovieAmount(int value)
        {
            purchasedMovieAmount = value;
        }

        static void Main()
        {
            EShopSimulator es = new EShopSimulator();
            es.Begin();
        }

        private void Begin()
        {
            int input;
            Initialize();
            do
            {
                ShowMainMenu();
                input = GetInt("\n" + "Please Select an option: ");
                MenuProccess(input);
            }
            while (!Exit(input));
        }

        private void Initialize()
        {
            soap = new Item("Soap", 1.00F, 20);
            actionFigure = new Item("Figure", 30.00F, 15);
            movie = new Item("Movie", 5.00F, 20);
            customerBudget = 100F;
            customer = new Customer(customerBudget, cartItem);
            isCheckout = false;

            Inventory.Add(soap);
            Inventory.Add(actionFigure);
            Inventory.Add(movie);
        }

        private void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Eshop Simulator!!");
            ShowShop();
            Console.Write("[0] Exit ");
            Console.Write("[1] Add Items To Cart ");
            Console.Write("[2] Remove Items From Cart ");
            Console.Write("[3] Checkout ");
        }

        private void ShowShop()
        {
            Console.WriteLine("Available Inventory Items: ");
            FancyLines();
            for (int i = 0; i < Inventory.Count; i++)
            {
                Console.WriteLine("[" + i + "] " + Inventory[i]);
            }
            FancyLines();

            Console.WriteLine("Your Budget!");
            Console.WriteLine(customer.budget);
            FancyLines();

            Console.WriteLine("Items in your cart: ");
            if (Cart.Count != 0)
            {
                for (int i = 0; i < Cart.Count; i++)
                {
                    FancyLines();
                    Console.WriteLine("[" + i + "] " + Cart[i]);
                    FancyLines();
                }
            }
            else
            {
                Console.WriteLine("Your Cart is Empty go buy shit!!!!");
            }
        }

        private static void FancyLines()
        {
            Console.WriteLine("--------------------------------------------------------------------");
        }

        private void MenuProccess(int input)
        {
            switch (input)
            {
                case 1:
                    AddItemsToCart();
                    break;
                case 2:
                    RemoveItemsFromCart();
                    break;
                case 3:
                    Checkout();
                    break;
            }
        }

        private void AddItemsToCart()
        {
            int itemTotalCost;

            addedItemNumber = GetInt("Choose an Item to add: ");
            switch (addedItemNumber)
            {
                case 0:
                    itemAmount = GetInt("How much do you want? ");
                    SetPurchasedSoapAmount(itemAmount);
                    if (!(soap.itemQuantity < itemAmount || soap.itemQuantity <= 0))
                    {
                        itemTotalCost = (int)(soap.itemPrice * itemAmount);
                        cartItem = new Item(soap.itemName, itemTotalCost, itemAmount);
                        Cart.Add(cartItem);
                    }
                    else
                    {
                        Console.WriteLine("We don't have enough of that item! But I doubt you have enough to pay.");
                        PressEnter();
                    }
                    break;

                case 1:
                    itemAmount = GetInt("How much do you want? ");
                    SetPurchasedFigureAmount(itemAmount);
                    if (!(actionFigure.itemQuantity < itemAmount || actionFigure.itemQuantity <= 0))
                    {                       
                        itemTotalCost = (int)actionFigure.itemPrice * itemAmount;
                        cartItem = new Item(actionFigure.itemName, itemTotalCost, itemAmount);
                        Cart.Add(cartItem);

                    }
                    else
                    {
                        Console.WriteLine("We don't have enough of that item! But I doubt you have enough to pay.");
                        PressEnter();
                    }
                    break;

                case 2:
                    itemAmount = GetInt("How much do you want? ");
                    SetpurchasedMovieAmount(itemAmount);
                    if (!(movie.itemQuantity < itemAmount || movie.itemQuantity <= 0))
                    {
                        itemTotalCost = (int)movie.itemPrice * itemAmount;
                        cartItem = new Item(movie.itemName, itemTotalCost, itemAmount);
                        Cart.Add(cartItem);
                    }
                    else
                    {
                        Console.WriteLine("We don't have enough of that item! But I doubt you have enough to pay.");
                        PressEnter();
                    }
                    break;

                default:
                    break;
            }
        }

        private void RemoveItemsFromCart()
        {
            int removedItem;

            removedItem = GetInt("Wish item do you wish to remove from your car? ");
            switch (removedItem)
            {
                case 0:
                    Cart.RemoveAt(removedItem);
                    break;
                case 1:
                    Cart.RemoveAt(removedItem);
                    break;
                case 2:
                    Cart.RemoveAt(removedItem);
                    break;

                default:
                    break;
            }
        }

        private bool Checkout()
        {
            int option;
            float total = cartItem.itemPrice;
            option = GetInt("The total is " + total + " Do you want to pay? " + "\n" + "[0] YES [1] NO  ");
            switch (option)
            {
                case 0:
                    if (customer.budget < total)
                    {
                        isCheckout = false;
                        Console.WriteLine("Get out of here you poor shit!");
                        PressEnter();
                        return false;
                    }
                    else
                    {
                        customer.budget -= total;
                        Cart.Clear();
                        isCheckout = true;
                        Console.WriteLine("Thank you for your purchase!");
                        PressEnter();
                    }
                    break;
                case 1:
                    isCheckout = false;
                    Console.WriteLine("You better be getting more shit or else...");
                    Console.ReadLine();
                    break;
            }
            if (isCheckout == true)
            {
                soap.itemQuantity -= purchasedSoapAmount;
                actionFigure.itemQuantity -= purchasedFigureAmount;
                movie.itemQuantity -= purchasedMovieAmount;
            }
            return true;
        }

        private int GetInt(string comment)
        {
            do
            {
                try
                {
                    Console.Write(comment);
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
            while (true);
        }

        private bool Exit(int input)
        {
            if (input == 0)
            {
                int choice = GetInt("Do you Wish to exit" + "\n" + "[1] Exit [Any Number] Stay:  ");
                if (choice == 1)
                {
                    Console.WriteLine("Thank you for Shopping!!");
                    PressEnter();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void PressEnter()
        {
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();
        }
    }
}
