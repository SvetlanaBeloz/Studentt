using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Studentt

    ///<summary>
    /// класс Group (группа студентов)
    ///</summary>
{
    public class Group
    {
        private List<Student> students = new ();
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
                CourseNumber = courseNumber;
                GroupName = groupName;
                Specialization = specialization;
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
                CourseNumber = courseNumber;
                GroupName = groupName;
                Specialization = specialization;
            }
        }

        /// <summary>
        /// конструктор на базе уже существующего массива студентов
        /// </summary>
        /// <param name="students">Уже существующий массив студентов</param>
        public Group(List<Student> students)
        {
            this.students = students;
            CourseNumber = courseNumber;
            GroupName = groupName;
            Specialization = specialization;
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
        /// Свойства поля названия группы
        /// </summary>

        public string GroupName
        {
            get => this.groupName;
            set => this.groupName = value;
        }

        /// <summary>
        /// Свойства поля названия специализации группы
        /// </summary>

        public string Specialization
        {
            set =>this.specialization = value;
            get => this.specialization;
        }

        /// <summary>
        /// Свойства поля номера курса
        /// </summary>
 
        public int CourseNumber
        {
            set
            {
                try
                {
                    if (value < 0 && value > 5)
                        throw new Exception("Некорректный номер курса, введите число от 1 до 5!");
                    this.courseNumber = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            get => this.courseNumber;
        }

       /// <summary>
       /// Вывод информации о студенте на экран
       ///</summary>

        public void PrintGroup()
        {
            Console.WriteLine("Name of Group : " + groupName);
            Console.WriteLine("Specialization of group : " + specialization);
            Console.WriteLine("\n\n");
            var sortedStudent = from s in students
                                orderby s.Surname ascending
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
        /// <summary>
        /// Перегрузка оператора ==
        /// </summary>
        /// <param name="left">Группа номер один</param>
        /// <param name="right">Группа номер два</param>
        /// <returns>переменную типа bool</returns>

        public static bool operator ==(Group left, Group right)
        {
            return left.students.Count == right.students.Count;
        }
        /// <summary>
        /// Перегрузка оператора !=
        /// </summary>
        /// <param name="left">Группа номер один</param>
        /// <param name="right">Группа номер два</param>
        /// <returns>переменную типа bool</returns>

        public static bool operator !=(Group left, Group right)
        {
            return left.students.Count != right.students.Count;
        }
        /// <summary>
        /// Перегрузка индексатора с одним параметром
        /// </summary>
        /// <param name="index">индекс в коллекции студентов</param>
        /// <returns>студента по индексу</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public Student this[int index]
        {
            get
            {
                if (index < 0 || index >= students.Count)
                    throw new IndexOutOfRangeException();
                else
                {

                    return students.ElementAt(index);
                }
            }
            set
            {
                students[index] = value;
            }
        }
    }
}
