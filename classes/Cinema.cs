namespace exercises_poo.classes;

public class Cinema
{
    public string Tittle { get; set; }
    public string Gender { get; set; }
    public int Duration { get; set; }

    public Cinema(string title, string gender, int duration)
    {
        Tittle = title;
        Gender = gender;
        Duration = duration;
    }

    public void ShowInfo()
    {
        Console.WriteLine("*****************");
        Console.WriteLine($"Tittle: {Tittle}, Gender: {Gender}, Duration: {Duration}");
    }

    public static class CinemaExe
    {
        private static List<Cinema> movies = new List<Cinema>();
        public static void Exe()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("===MENU CINEMA===");
                Console.WriteLine("1. Register new Movie");
                Console.WriteLine("2. Show info Movie");
                Console.WriteLine("3. Consult Movie tha duration will be more than 120Minutes ");
                Console.WriteLine("0. Exit");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1" :
                        RegisterMovie();
                        break;
                    case "2" :
                        ShowInfoMovie();
                        break;
                    case "3" :
                        ConsultMovie();
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

        private static void RegisterMovie()
        {
            Console.WriteLine("Enter the title of the movie");
            string title = Console.ReadLine();
            
            Console.WriteLine("Enter the gender of the movie");
            string gender = Console.ReadLine();
            
            Console.WriteLine("Enter the duration of the movie");
            int duration = int.Parse(Console.ReadLine());

            Cinema movie = new Cinema(title, gender, duration);
            movies.Add(movie);
            Console.WriteLine("Movie registered successfully");
        }

        public static void ShowInfoMovie()
        {
            Console.WriteLine("Enter the title of the movie");
            string title = Console.ReadLine();
            
            var movie=movies.FirstOrDefault(m=>(!string.IsNullOrEmpty(title) && m.Tittle.Equals(title, StringComparison.OrdinalIgnoreCase)));

            if (movie != null)
            {
                Console.WriteLine("book find with this information");
                movie.ShowInfo();
            }
            else
            {
                Console.WriteLine("Movie not found...");
            }
        }

        public static void ConsultMovie()
        {
            var result = movies.Where(m => m.Duration > 120).ToList();

            if (result.Count == 0)
            {
                Console.WriteLine("Movies not found with more than 120 minutes");
            }
            else
            {
                Console.WriteLine("Movies with more than 120 minutes...");
                foreach (var movie in result)
                {
                    movie.ShowInfo();
                }
            }
        }
    }
}