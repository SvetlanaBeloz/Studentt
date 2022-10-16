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

            Student student = new Student("AAAA", "WWWW", "GGGG");
            Student student1 = new Student("AAAA", "DDDD", "VVVVV");
            student.AddExams(10);
            student.AddExams(10);
            student1.AddExams(10);
            student1.AddExams(10);
            Console.WriteLine(student < student1);

            Console.WriteLine(student != student1);
            Group first = new Group(10);
            Group second = new Group(20);
            Console.WriteLine(first != second);

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
            //group.PrintGroup();
            //Student s = group.WorstStudentExpulsion();
            //s.PrintInfo();
            //Console.WriteLine("\n");
            //group.PrintGroup();
            //Group group1 = new Group();
            //group.TransferStudent(0, group1);
            //group.PrintGroup();
            //group1.PrintGroup();

        }
    }
}