namespace exercises_poo.classes;

public class Library
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int NumberPages { get; set; }

    public Library(string title, string author, int numberPages)
    {
        Title = title;
        Author = author;
        NumberPages = numberPages;
    }
    
    //method show info
    public void ShowInfo()
    {
        Console.WriteLine($"Book title: {Title}, author: {Author}, number pages: {NumberPages}");
    }

    public static class LibraryExe
    {
        private static List<Library> books = new List<Library>();

        public static void exe()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("==MENU==");
                Console.WriteLine("1. REGISTER BOOK");
                Console.WriteLine("2. CONSULT INFORMATION OF BOOK");
                Console.WriteLine("3. MORE THAN 300 PAGES");
                Console.WriteLine("0. EXIT");
                Console.WriteLine("-------------");
                Console.WriteLine("SELECT AN OPTION:");
                string option=Console.ReadLine();

                switch (option)
                {
                    case "1":
                        RegisterBook();
                        break;
                    case "2":
                        ConsultBook();
                        break;
                    case "3":
                        MoreThan(); 
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

        private static void RegisterBook()
        {
            Console.WriteLine("Enter the title of book:");
            string Title = Console.ReadLine();
            
            Console.WriteLine("Enter the author of book:");
            string Author = Console.ReadLine();
            
            Console.WriteLine("Enter the number of pages of book:");
            int NumberPages = int.Parse(Console.ReadLine());
            
            Library book = new Library(Title, Author, NumberPages);
            books.Add(book);//to add into the list
            Console.WriteLine("The book has been registered.");
        }

        private static void ConsultBook()
        {
            Console.WriteLine("Enter the title of book:");
            string title = Console.ReadLine();
            
            Console.WriteLine("Enter the author of book:");
            string author = Console.ReadLine();
            //LINQ
            var book = books.FirstOrDefault(b =>
                (!string.IsNullOrEmpty(title) && b.Title.Equals(title, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(author) && b.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
            );
            
            if (book == null)
            {
                Console.WriteLine("Book not found");
            }
            else
            {
                book.ShowInfo();
            }
        }

        private static void MoreThan()
        {
            var results = books.Where(b => b.NumberPages > 300).ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("No books with more than 300 pages...");
            }
            else
            {
                Console.WriteLine("Books with more than 300 pages:");
                foreach (var book in results)
                {
                    book.ShowInfo();
                }
            }
        }
    }
}