namespace exercises_poo.classes;
public class Pet
{
    public string Name { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }

    public Pet(string name, string species, int age)
    {
        Name = name;
        Species = species;
        Age = age;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Name: {Name},  Species: {Species},  Age: {Age}");
    }

    public static class Petexe
    {
        private static List<Pet> pets = new List<Pet>();
        
        public static void exe()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("MENU PET");
                Console.WriteLine("1.Register new pet");
                Console.WriteLine("2. consult pet information");
                Console.WriteLine("3. Know if pet is puppy");
                Console.WriteLine("0. Exit");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1" :
                        RegisterPet();
                        break;
                    case "2" :
                        ConsultPetInfo();
                        break;
                    case "3":
                        ConsultIfPupy();
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

        public static void RegisterPet()
        {
            Console.WriteLine("Enter the name of the pet:");
            string name = Console.ReadLine();
        
            Console.WriteLine("Enter the species of the pet:");
            string species = Console.ReadLine();
        
            Console.WriteLine("Enter the age of the pet:");
            int age = int.Parse(Console.ReadLine());
        
            Pet newPet= new Pet(name, species, age);
            pets.Add(newPet);
            Console.WriteLine("Pet registered successfully");
        }

        public static void ConsultPetInfo()
        {
            Console.WriteLine("Enter the name of the pet:");
            string name = Console.ReadLine();

            var pet = pets.FirstOrDefault(p =>
                (!string.IsNullOrEmpty(name) && p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));

            if (pet != null)
            {
                pet.ShowInfo();
            }
            else
            {
                Console.WriteLine("Pet not found");
            }
        }

        public static void ConsultIfPupy()
        {
            var result = pets.Where(p => p.Age < 2).ToList();

            if (result.Count == 0)
            {
                Console.WriteLine("Pet not found");
            }
            else
            {
                Console.WriteLine("The puppy animals are:");
                foreach (var pet in result)
                {
                    pet.ShowInfo();
                }
            }
        }
    }
}