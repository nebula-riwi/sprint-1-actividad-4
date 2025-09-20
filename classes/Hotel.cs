namespace exercises_poo.classes;

public class Hotel
{
    public int RoomNumber { get; set; }
    public string GuestName { get; set; }
    public int Nights { get; set; }

    public Hotel(int roomNumber, string guestName, int nights)
    {
        RoomNumber = roomNumber;
        GuestName = guestName;
        Nights = nights;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Room: {RoomNumber}, Guest: {GuestName}, Nights: {Nights}");
    }

    public static class HotelExe
    {
        private static List<Hotel> reservations = new List<Hotel>();

        public static void exe()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n=== HOTEL MENU ===");
                Console.WriteLine("1. Register new reservation");
                Console.WriteLine("2. Consult reservation");
                Console.WriteLine("3. Calculate total cost");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        RegisterReservation();
                        break;
                    case "2":
                        ConsultReservation();
                        break;
                    case "3":
                        CalculateTotalCost();
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

        private static void RegisterReservation()
        {
            Console.Write("Enter the room number: ");
            int room = int.Parse(Console.ReadLine());

            Console.Write("Enter the guest name: ");
            string guest = Console.ReadLine();

            Console.Write("Enter the number of nights: ");
            int nights = int.Parse(Console.ReadLine());

            Hotel reservation = new Hotel(room, guest, nights);
            reservations.Add(reservation);
            Console.WriteLine("Reservation registered successfully!");
        }

        private static void ConsultReservation()
        {
            Console.Write("Enter the room number to search: ");
            int room = int.Parse(Console.ReadLine());

            var reservation = reservations.FirstOrDefault(r => r.RoomNumber == room);
            if (reservation != null)
            {
                Console.WriteLine("Reservation found:");
                reservation.ShowInfo();
            }
            else
            {
                Console.WriteLine(" Reservation not found...");
            }
        }

        private static void CalculateTotalCost()
        {
            Console.Write("Enter the room number: ");
            int room = int.Parse(Console.ReadLine());

            var reservation = reservations.FirstOrDefault(r => r.RoomNumber == room);
            if (reservation != null)
            {
                Console.Write("Enter the price per night: ");
                double price = double.Parse(Console.ReadLine());

                double total = reservation.Nights * price;
                Console.WriteLine($"The total cost of the stay is: ${total}");
            }
            else
            {
                Console.WriteLine(" Reservation not found...");
            }
        }
    }
}