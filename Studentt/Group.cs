using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentt

    ///<summary>
    /// класс Group (группа студентов)
    ///</summary>
{
    public class Group
    {
        private List<Student> students = new List<Student>();
        private string groupName = "ПУ111";
        private string specialization = "Программирование на .Net";
        private int courseNumber = 2;
   
        /// <summary>
        /// конструктор без параметров на 12 студентов
        /// </summary>
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

        /// <summary>
        /// конструктор с одним параметром, задающий количество студентов в группе
        /// </summary>
        /// <param name="number">колтчество студентов в группе</param>
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

        /// <summary>
        /// конструктор на базе уже существующего массива студентов
        /// </summary>
        /// <param name="students">Уже существующий массив студентов</param>
        public Group(List<Student> students)
        {
            this.students = students;
            SetCourseNumber(courseNumber);
            SetGroupName(groupName);
            SetSpecialization(specialization);
        }

        /// <summary>
        /// конструктор копирования 
        /// </summary>
        /// <param name="inputGroup">обЪект класса Group, копию которого надо создать</param>
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

        /// <summary>
        /// запись названия группы
        /// </summary>
        /// <param name="groupName">Название группы</param>

        public void SetGroupName(string groupName)
        {
            this.groupName = groupName;
        }

        /// <summary>
        /// Запись названия специализации группы
        /// </summary>
        /// <param name="specialization">Название специализации группы</param>

        public void SetSpecialization(string specialization)
        {
            this.specialization = specialization;
        }

        /// <summary>
        /// Запись номера курса
        /// </summary>
        /// <param name="courseNumber">Номер курса</param>

        public void SetCourseNumber( int courseNumber)
        {
            try
            {
                if (courseNumber < 0 && courseNumber > 5)
                    throw new Exception("Некорректный номер курса, введите число от 1 до 5!");
                this.courseNumber = courseNumber;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Получение названия группы
        /// </summary>
        /// <returns>Название группы</returns>
        public string GetGroupName()
        {
            return groupName;
        }

        /// <summary>
        /// Получение специализации группы
        /// </summary>
        /// <returns>специализация группы</returns>

        public string GetSpecialization()
        {
            return specialization;
        }

        /// <summary>
        /// Получение номера курса
        /// </summary>
        /// <returns>Номер курса</returns>

        public int GetCourseNumber()
        {
            return courseNumber;
        }

        /// <summary>
        /// Вывод информации о всех студентах в группе и их рейтинге
        /// </summary>

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

        /// <summary>
        /// Добавление студента в группу
        /// </summary>
        /// <param name="s">ОбЪект класса студент</param>

        public void AddStudent(Student s)
        {
            students.Add(s);
        }

        /// <summary>
        /// Перевод студента в другую группу
        /// </summary>
        /// <param name="index">индекс по которому студент находится в массиве студентов</param>
        /// <param name="destination">группа, в которую переводят студента</param>

        public void TransferStudent(int index, Group destination)
        {
            try
            {
            if (index < 0 || index >= students.Count)
                    throw new Exception("Некорректный индекс, по которому находится обЪект класса студент, которого надо перевести!");
            destination.AddStudent(students.ElementAt(index));
            StudentExpulsion(index);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// отчисление студента из группы
        /// </summary>
        /// <param name="index">индекс по которому студент находится в массиве студентов</param>

        public void StudentExpulsion(int index)
        {
            try
            {
                if (index < 0 || index >= students.Count)
                    throw new Exception("Некорректный индекс, по которому находится обЪект класса студент, которого надо отчислить!");
                this.students.RemoveAt(index);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Отчисление студента с худшей успеваемостью 
        /// </summary>
        /// <returns>обЪект клааса студент, который является худшим студентом</returns>

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
