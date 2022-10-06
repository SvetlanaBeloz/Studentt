namespace Studentt
{
    public class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.AddOffset(10);
            student.AddOffset(10);
            student.AddOffset(12);
            student.AddProjects(12);
            student.AddProjects(12);
            student.AddProjects(11);
            student.AddExams(10);
            student.AddExams(12);
            student.AddExams(11);
            student.PrintInfo();
        }
    }
}