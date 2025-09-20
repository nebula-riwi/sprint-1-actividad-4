namespace exercises_poo.classes;

public class Clinic
{
    public string PatientName { get; set; }
    public string Specialty { get; set; }
    public DateTime AppointmentDate { get; set; }

    public Clinic(string patientName, string specialty, DateTime appointmentDate)
    {
        PatientName = patientName;
        Specialty = specialty;
        AppointmentDate = appointmentDate;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Patient: {PatientName}, Specialty: {Specialty}, Date: {AppointmentDate.ToShortDateString()}");
    }

    public static class ClinicExe
    {
        private static List<Clinic> appointments = new List<Clinic>();

        public static void exe()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n=== MEDICAL CLINIC MENU ===");
                Console.WriteLine("1. Register new appointment");
                Console.WriteLine("2. Consult appointment");
                Console.WriteLine("3. Days left until appointment");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        RegisterAppointment();
                        break;
                    case "2":
                        ConsultAppointment();
                        break;
                    case "3":
                        DaysUntilAppointment();
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

        private static void RegisterAppointment()
        {
            Console.Write("Enter the patient's name: ");
            string patientName = Console.ReadLine();

            Console.Write("Enter the specialty: ");
            string specialty = Console.ReadLine();

            Console.Write("Enter the appointment date (yyyy-MM-dd): ");
            DateTime appointmentDate = DateTime.Parse(Console.ReadLine());

            Clinic appointment = new Clinic(patientName, specialty, appointmentDate);

            appointments.Add(appointment);

            Console.WriteLine("Appointment registered successfully!");
        }

        private static void ConsultAppointment()
        {
            Console.Write("Enter the patient's name to search: ");
            string name = Console.ReadLine();

            var appointment = appointments.FirstOrDefault(a => a.PatientName.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (appointment != null)
            {
                Console.WriteLine("Appointment found:");
                appointment.ShowInfo();
            }
            else
            {
                Console.WriteLine(" Appointment not found...");
            }
        }

        private static void DaysUntilAppointment()
        {
            Console.Write("Enter the patient's name: ");
            string name = Console.ReadLine();

            var appointment = appointments.FirstOrDefault(a => a.PatientName.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (appointment != null)
            {
                int daysLeft = (appointment.AppointmentDate - DateTime.Now).Days;

                if (daysLeft >= 0)
                    Console.WriteLine($"There are {daysLeft} day(s) left until {appointment.PatientName}'s appointment.");
                else
                    Console.WriteLine($" The appointment for {appointment.PatientName} has already passed.");
            }
            else
            {
                Console.WriteLine("Appointment not found...");
            }
        }
    }
}
