namespace exercises_poo.classes;

public class Parking
{
    public string Plate { get; set; }
    public string Brand { get; set; }
    // timespan to represent hour and duration
    public TimeSpan HourDay { get; set; }

    public Parking(string plate, string brand, TimeSpan hourDay)
    {
        Plate = plate;
        Brand = brand;
        HourDay = hourDay;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"The plate is {Plate} with the brand {Brand} entered the parking at {HourDay}.");
    }

    public static class ParkingExe
    {
        private static List<Parking> tickets = new List<Parking>();

        public static void exe()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("==WELCOME TO THE PARKING==");
                Console.WriteLine("==================");
                Console.WriteLine("1. Register ticket of the vehicle");
                Console.WriteLine("2. Register exit of the vehicle");
                Console.WriteLine("3. Calculate price of the vehicle according to the hour ticket to exit");
                Console.WriteLine("0. exit");
                Console.WriteLine("------------------");
                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        RegisterTicket();
                        break;
                    case "2":
                        RegisterExit();
                        break;
                    case "3":
                        CalculatePrice();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option.");
                        break;
                }
            }
        }

        private static void RegisterTicket()
        {
            Console.WriteLine("Enter plate number: ");
            string plate = Console.ReadLine();

            Console.WriteLine("Enter brand: ");
            string brand = Console.ReadLine();

            Console.WriteLine("Enter hour of entry (hh:mm:ss). Example: 14:30:00");
            string inputHour = Console.ReadLine();

            TimeSpan hourDay;
            if (TimeSpan.TryParse(inputHour, out hourDay))
            {
                Console.WriteLine("Hour entered successfully: " + hourDay);
                Parking ticket = new Parking(plate, brand, hourDay);
                tickets.Add(ticket);
                Console.WriteLine("The ticket has been registered successfully.");
            }
            else
            {
                Console.WriteLine("Incorrect format. Please try again.");
            }
        }

        private static void RegisterExit()
        {
            Console.WriteLine("Enter plate of vehicle exiting: ");
            string plate = Console.ReadLine();

            Parking ticket = tickets.FirstOrDefault(t => t.Plate == plate);

            if (ticket != null)
            {
                Console.WriteLine($"Vehicle {ticket.Plate} - {ticket.Brand} exited. Entry time was {ticket.HourDay}.");
                
                Console.WriteLine($"Enter the exit hour (hh:mm:ss). Example: 16:30:00 :");
                string inputExit = Console.ReadLine();

                if (TimeSpan.TryParse(inputExit, out TimeSpan exitHour))
                {
                    TimeSpan duration = exitHour - ticket.HourDay;

                    if (duration.TotalMinutes < 0)
                    {
                        Console.WriteLine("Exit time be earlier than entry time");
                        return;
                    }

                    double priceHour = 2000;
                    int totalHours=(int)Math.Ceiling(duration.TotalHours);
                    double totalPrice = totalHours * priceHour;
                    
                    Console.WriteLine($"The vehicle sttayed {duration.TotalHours}hours  ");
                    Console.WriteLine($"Total to pay: {totalPrice}");
                }
                else
                {
                    Console.WriteLine("Format invalid");
                }

                tickets.Remove(ticket);
            }
            else
            {
                Console.WriteLine("Vehicle not found.");
            }
        }

        private static void CalculatePrice()
        {
            Console.WriteLine("Enter the plate number: ");
            string plate = Console.ReadLine();
            //find the ticket by plate
            Parking ticket = tickets.FirstOrDefault(t => t.Plate == plate);

            if (ticket != null)
            {
                Console.WriteLine($"Vehicle found: {ticket.Plate} - {ticket.Brand}");
                Console.WriteLine($"Entry time: {ticket.HourDay}.");
                
                //get the exit hour
                Console.WriteLine("Enter the hour (hh:mm:ss). Example: 14:30:00)");
                string inputExit = Console.ReadLine();
                
                TimeSpan exitHour;
                if (TimeSpan.TryParse(inputExit, out exitHour))
                {
                    TimeSpan duration=exitHour-ticket.HourDay;

                    if (duration.TotalMinutes < 0)
                    {
                        Console.WriteLine("Exit time cannot be earlier than entry time");
                        return;
                    }
                    
                    //price by hour
                    double priceHour = 2000;
                    
                    //redond the hours
                    int totalHours=(int)Math.Ceiling(duration.TotalHours);

                    double totalPrice = totalHours * priceHour;
                    
                    Console.WriteLine($"The vehicle stayed {duration.TotalMinutes}minutes");
                    Console.WriteLine($"Total to pay: {totalPrice}");
                }
                else
                {
                    Console.WriteLine("Incorrect format. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Vehicle not found.");
            }
        }
    }
}
