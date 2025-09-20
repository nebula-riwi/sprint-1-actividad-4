using System;
using exercises_poo.classes;

namespace exercises_poo
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. Exercise students");
                Console.WriteLine("2. Exercise bank");
                Console.WriteLine("3. Exercise shop");
                Console.WriteLine("4. Exercise Library");
                Console.WriteLine("5. Exercise Restaurant");
                Console.WriteLine("6. Exercise Parking");
                Console.WriteLine("7. Exercise Cinema");
                Console.WriteLine("8. Exercise Pet");
                Console.WriteLine("9. Exercise Hotel");
                Console.WriteLine("10. Exercise Clinic");
                Console.WriteLine("0. exit");
                Console.Write("select an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Students.StudentExe.exe();
                        break;
                    case "2":
                        Bank.BankExe.exe();
                        break;
                    case "3":
                        Shop.ShopExe.exe();
                        break;
                    case "4":
                        Library.LibraryExe.exe();
                        break;
                    case "5":
                        Restaurant.RestaurantExe.exe();
                        break;
                    case "6":
                        Parking.ParkingExe.exe();
                        break;
                    case "7" :
                        Cinema.CinemaExe.Exe();
                        break;
                    case "8":
                        Pet.Petexe.exe();
                        break;
                    case "9":
                        Hotel.HotelExe.exe();
                        break;
                    case "10":
                        Clinic.ClinicExe.exe();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Option not is valid");
                        break;
                }
            }
        }
    }
}