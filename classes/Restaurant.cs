namespace exercises_poo.classes;
using System.Linq;

public class Restaurant
{
    public int NumberTable { get; set; }
    public string NameFood { get; set; }
    public double Price { get; set; }

    public Restaurant(int numberTable, string nameFood, double price)
    {
        NumberTable = numberTable;
        NameFood = nameFood;
        Price = price;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"The food is {NameFood} from number table {NumberTable} with a price of {Price}.");
    }

    public static class RestaurantExe
    {
        private static List<Restaurant> orders = new List<Restaurant>();

        public static void exe()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("==RESTAURANT==");
                Console.WriteLine("1. Register new orders");
                Console.WriteLine("2. Calculate total of order");
                Console.WriteLine("3. Information of the plates in a order");
                Console.WriteLine("4. Show all orders");
                Console.WriteLine("0. Exit");
                Console.WriteLine("--------------------");
                Console.WriteLine("SELECT AN OPTION:");
                string option= Console.ReadLine();
                switch (option)
                {
                    case "1":
                        RegisterOrder();
                        break;
                    case "2":
                        CalculateOrder();
                        break;
                    case "3":
                        ShowInformationOrder();
                        break;
                    case "4":
                        ShowAllOrders();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        private static int orderCounter = 0;
        private static void RegisterOrder()
        {
            
            int orderNumber = orderCounter++;
            
            Console.WriteLine("Enter the name of the food:");
            string foodName = Console.ReadLine();
            
            Console.WriteLine("Enter the price of the food:");
            double foodPrice = double.Parse(Console.ReadLine());
            
            Restaurant order=new Restaurant(orderNumber, foodName, foodPrice);
            orders.Add(order);
            
            Console.WriteLine("Order registered");
        }

        private static void CalculateOrder()
        {
            Console.WriteLine("Enter the order number:");
            int number = int.Parse(Console.ReadLine());
            
            //filter all plates of the order
            var result=orders.Where(o => o.NumberTable == number).ToList();

            if (result.Count == 0)
            {
                Console.WriteLine("Order not found...");
            }
            else
            {
                double total=result.Sum(o=>o.Price);
                Console.WriteLine($"Total for order {number} is {total:C}");
            }
        }

        private static void ShowInformationOrder()
        {
            Console.WriteLine("Enter the order number:");
            int number = int.Parse(Console.ReadLine());
            
            var result=orders.Where(o=>o.NumberTable == number).ToList();

            if (result.Count == 0)
            {
                Console.WriteLine("Order not found...");
            }
            else
            {
                Console.WriteLine($"Details for order number #{number}:");
                foreach (var order in result)
                {
                    order.ShowInfo();
                }
                
            }
        }

        private static void ShowAllOrders()
        {
            if (orders.Count == 0)
            {
                Console.WriteLine("orders not registered...");
                return;
            }
            Console.WriteLine("===ALL ORDERS===");
            foreach (var order in orders)
            {
                order.ShowInfo();
            }
            Console.WriteLine();
        }
    }
}