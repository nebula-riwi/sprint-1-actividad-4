namespace exercises_poo.classes
{
    public class Students
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grades { get; set; }

        // Constructor
        public Students(string name, int age, int grades)
        {
            Name = name;
            Age = age;
            Grades = grades;
        }

        // method show info user
        public void ShowInfo()
        {
            Console.WriteLine($"The name of the student is {Name}, he is {Age} years old, and is in grade {Grades}.");
        }

        // Class static 
        public static class StudentExe
        {
            public static void exe()
            {
                Students student1 = new Students("Juan", 15, 9);
                Students student2 = new Students("Maria", 16, 10);

                student1.ShowInfo();
                student2.ShowInfo();
            }
        }
    }
}