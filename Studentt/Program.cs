namespace Studentt

    ///<summary>
    /// класс Program 
    /// основной класс программы
    ///</summary>
{
    public class Program
    {
        /// <summary>
        /// Метод Main() является
        /// входной точкой работы программы
        /// </summary>
        /// <param name="args">Аргумент метода Main()</param>
        static void Main(string[] args)
        {

            Group g = new ();
            foreach (var item in g)
            {
                (item as Student).PrintInfo();
                Console.WriteLine("\n");
            }
            
            //Student student = new Student();
            //Console.WriteLine(student["projects", 0]); 
            //Student student1 = new Student("u","Y", "r");
            //student.AddExams(10);
            //student.AddExams(10);
            //student1.AddExams(0);
            //student1.AddExams(0);
            //Console.WriteLine(student < student1);

            //Console.WriteLine(student != student1);
            //Group first = new Group();
            //Group second = new Group();
            //Console.WriteLine(first != second);

            //student.AddOffset(10);
            //student.AddOffset(10);
            //student.AddOffset(12);
            //student.AddProjects(12);
            //student.AddProjects(12);
            //student.AddProjects(11);
            //student.AddExams(10);
            //student.AddExams(12);
            //student.AddExams(11);
            //student.PrintInfo();
            //Console.WriteLine("\n");
            //Console.WriteLine($"\n{student.RandomDay().ToString("d")}");
            //Console.WriteLine("\n\n");
            //Group group = new Group();
            //Console.WriteLine(group[0]);

            //group.PrintGroup();
            //group.Specialization = "hfhfhf";
            //group.PrintGroup();
            //Student s = group.WorstStudentExpulsion();
            //s.PrintInfo();
            //Console.WriteLine("\n");
            //group.PrintGroup();
            //Group group1 = new Group();
            //group.TransferStudent(0, group1);
            //group.PrintGroup();
            //group1.PrintGroup();

            //Aspirant a = new Aspirant();
            //a.Course = 4;
            //a.NameOfDessertation = "TTTT";
            //Console.WriteLine(a.Name);
            //a.PrintInfo();
            //Student student = new BadStudent();
            //student.PrintInfo();
            //Group g = new Group();
            //g.AddStudent(student);
            //g.PrintGroup();
            //Student s = new GoodStudent();
            //s.PrintInfo();
            //g.AddStudent(s);
            //g.PrintGroup();


        }
    }
}