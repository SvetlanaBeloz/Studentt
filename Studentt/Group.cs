using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentt
{
    public class Group
    {
        private List<Student> students = new List<Student>();
        private string groupName = "ПУ111";
        private string specialization = "Программирование на .Net";
        private int courseNumber = 2;
   

        public Group()
        {
            for (int i = 0; i < 12; i++)
            {
                students.Add(new Student());
                SetCourseNumber(courseNumber);
                SetGroupName(groupName);
                SetSpecialization(specialization);
            }
        }

        public Group(int number)
        {
            for (int i = 0; i < number; i++)
            {
                students.Add(new Student());
                SetCourseNumber(courseNumber);
                SetGroupName(groupName);
                SetSpecialization(specialization);
            }
        }

        public Group(List<Student> students)
        {
            this.students = students;
            SetCourseNumber(courseNumber);
            SetGroupName(groupName);
            SetSpecialization(specialization);
        }

        public Group(Group inputGroup)
        {
            List<Student> copyStudents = new List<Student>();
            foreach(var student in inputGroup.students)
            {
                copyStudents.Add(student);
            }
            this.students = copyStudents;
            this.courseNumber = inputGroup.courseNumber;
            this.groupName = inputGroup.groupName;
            this.specialization = inputGroup.specialization;
        }

        public void SetGroupName(string groupName)
        {
            this.groupName = groupName;
        }

        public void SetSpecialization(string specialization)
        {
            this.specialization = specialization;
        }

        public void SetCourseNumber( int courseNumber)
        {
            this.courseNumber = courseNumber;
        }
        public string GetGroupName()
        {
            return groupName;
        }

        public string GetSpecialization()
        {
            return specialization;
        }

        public int GetCourseNumber()
        {
            return courseNumber;
        }

        public void PrintGroup()
        {
            Console.WriteLine("Name of Group : " + GetGroupName());
            Console.WriteLine("Specialization of group : " + GetSpecialization());
            Console.WriteLine("\n\n");
            var sortedStudent = from s in students
                                orderby s.GetSurname() ascending
                                select s;
            int number = 1;
            foreach (var s in sortedStudent)
            {
                Console.WriteLine("Student " + number + " :");
                s.PrintInfo();
                Console.WriteLine("Exams rate is: " + s.ExamsRate()); 
                number++;
                Console.WriteLine("\n\n");
            }
           
        }

        public void AddStudent(Student s)
        {
            students.Add(s);
        }

        public void TransferStudent(int index, Group destination)
        {
            if (index < 0 || index >= students.Count)  return;
            destination.AddStudent(students.ElementAt(index));
            StudentExpulsion(index);
        }


        public void StudentExpulsion(int index)
        {
            this.students.RemoveAt(index);
        }

        public Student WorstStudentExpulsion()
        {
            double minAverage = students.ElementAt(0).ExamsRate();
            int CurrentIndex = 0;
            int worstIndex = 0;
            Student worst = students.ElementAt(0);
            for(int i = 0; i < students.Count; i++)
            {
                double averageExamRate = students[i].ExamsRate();
                if(averageExamRate < minAverage)
                {
                    minAverage = averageExamRate;
                    worstIndex = i;
                    worst = students[i];
                    
                }
                CurrentIndex++;
            }
            StudentExpulsion(worstIndex);
            return worst;
        }
    }
}
