using System;
using System.Collections.Generic;

namespace exercises_poo.classes
{
    public class Shop
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

        public Shop(string name, double price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }
        
        // method show info of product 
        public void ShowInfo()
        {
            Console.WriteLine($"Product: {Name}, Price: {Price}, Stock: {Stock}");
        }
        
        // method sell product
        public void Sell(int quantity)
        {
            if (quantity <= 0)
            {
                Console.WriteLine(" Sell is invalid, should be greater than 0");
                return;
            }

            if (quantity > Stock)
            {
                Console.WriteLine(" Sell is invalid, quantity should be less than stock");
            }
            else
            {
                Stock -= quantity;
                Console.WriteLine($" Sell realized: {quantity} units of {Name}");
            }
        }

        // static class of execution
        public static class ShopExe
        {
            private static List<Shop> products = new List<Shop>();

            public static void exe()
            {
                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("\n== SHOP MENU ==");
                    Console.WriteLine("1. REGISTER PRODUCT");
                    Console.WriteLine("2. CONSULT PRODUCT");
                    Console.WriteLine("3. SELL PRODUCT");
                    Console.WriteLine("0. EXIT");
                    Console.Write("Select an option: ");
                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            RegisterProduct();
                            break;
                        
                        case "2":
                            ConsultProduct();
                            break;
                        
                        case "3":
                            SellProduct();
                            break;
                        
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("INVALID OPTION");
                            break;
                    }
                }
            }

            private static void RegisterProduct()
            {
                Console.Write("Enter the product name: ");
                string name = Console.ReadLine();
                
                Console.Write("Enter the product price: ");
                double price = double.Parse(Console.ReadLine());
                
                Console.Write("Enter the product stock: ");
                int stock = int.Parse(Console.ReadLine());
                
                Shop product = new Shop(name, price, stock);
                products.Add(product);
                
                Console.WriteLine("Product added successfully");
            }

            private static void ConsultProduct()
            {
                Console.Write("Enter the product name: ");
                string name = Console.ReadLine();
                
                Shop product = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

                if (product != null)
                {
                    product.ShowInfo();
                }
                else
                {
                    Console.WriteLine(" Product not found");
                }
            }

            private static void SellProduct()
            {
                Console.Write("Enter the product name: ");
                string name = Console.ReadLine();
                
                Shop product = products.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

                if (product != null)
                {
                    Console.Write("Enter the quantity to sell: ");
                    int quantity = int.Parse(Console.ReadLine());
                    product.Sell(quantity);
                }
                else
                {
                    Console.WriteLine(" Product not found");
                }
            }
        }
    }
}
