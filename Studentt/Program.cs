namespace Studentt
{
    public class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            //student.AddOffset(10);
            //student.AddOffset(10);
            //student.AddOffset(12);
            //student.AddProjects(12);
            //student.AddProjects(12);
            //student.AddProjects(11);
            //student.AddExams(10);
            //student.AddExams(12);
            //student.AddExams(11);
            student.PrintInfo();
            Console.WriteLine($"\n{student.RandomDay().ToString("d")}");
            Console.WriteLine("\n\n");
            Group group = new Group();
            group.PrintGroup();
            Student s = group.WorstStudentExpulsion();
            s.PrintInfo() ;
            Console.WriteLine("\n");
            group.PrintGroup();
            Group group1 = new Group();
            group.TransferStudent(0, group1);
            group.PrintGroup();
            group1.PrintGroup();

        }
    }
}