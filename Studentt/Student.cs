using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Studentt

    /// <summary>
    /// Класс Student  для заполнения класса Group (группа студентов)
    /// </summary>
   
{
    public class Student : Person, ICloneable, IComparable<Student>
    {

        private List<int> offset = new();
        private List<int> projects = new();
        private List<int> exams = new();

        /// <summary>
        /// Конструктор без параметров с генерацией случайной информации о студенте 
        /// </summary>

        public Student() : base() { }

        public Student(string name, string surname, string patronymic) : base(name, surname, patronymic) { }


        /// <summary>
        /// Конструктор со всеми параметрами
        /// </summary>
        /// <param name="name">Имя студента</param>
        /// <param name="surname">Фамилия студента</param>
        /// <param name="patronymic">Отчество студента</param>
        /// <param name="address">Адрес студента</param>
        /// <param name="birthday">День рождение студента</param>
        /// <param name="phoneNumber">номер телефона студента</param>
        /// <param name="e">массив с оцеками за экзамены</param>
        /// <param name="p">массив с оцеками за курсовые работы</param>
        /// <param name="o">массив с оцеками за зачеты</param>

        public Student(string name, string surname, string patronymic, string address, string phoneNumber, DateTime birthday,
            List<int> e, List<int> p, List<int> o) : base(name, surname, patronymic, address, phoneNumber, birthday)
        {
            this.offset = o;
            this.projects = p;
            this.exams = e;
        }

        /// <summary>
        /// Добавление оценки за зачет 
        /// </summary>
        /// <param name="mark">Оценка за зачет</param>
       

        public void AddOffset(int mark)
        {
            try
            {
                if (mark < 1 && mark > 12)
                    throw new Exception("Оценка не может быть меньше одного или больше двенадцати");

                this.offset.Add(mark);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            } 
        }

        /// <summary>
        /// Добавление оценки за курсовую работу
        /// </summary>
        /// <param name="mark">Оценка за курсовую работу</param>

        public void AddProjects(int mark)
        {
            try
            {
                if (mark < 1 && mark > 12)
                    throw new Exception("Оценка не может быть меньше одного или больше двенадцати");
                this.projects.Add(mark);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Добавление оценки за экзамен 
        /// </summary>
        /// <param name="mark">Оценка за экзамен</param>

        public void AddExams(int mark)
        {
            try
            {
                if (mark < 1 && mark > 12)
                    throw new Exception("Оценка не может быть меньше одного или больше двенадцати");

                this.exams.Add(mark);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Вычисление среднего балла студента по экзаменам
        /// </summary>
        /// <returns>Средний балл студента по экзаменам</returns>
        public double ExamsRate()
        {
            double result = 0;
            foreach (var item in exams)
            {
                result += item;
            }
            return result / exams.Count;
        }
        
        /// <summary>
        /// Вывод на экран информации по студенту и его оценки
        /// </summary>

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.Write ("offsets  :\t");
            foreach (var item in offset)
            {
                Console.Write(item + "\t");
            }
            Console.Write("\nprojects :\t");
            foreach (var item in projects)
            {
                Console.Write(item + "\t");
            }
            Console.Write("\nexams    :\t");
            foreach (var item in exams)
            {
                Console.Write(item + "\t");
            }
        }
   
        public static bool operator ==(Student left, Student right)
        {
            return (left.ExamsRate() == right.ExamsRate());
        }
     
        public static bool operator !=(Student left, Student right)
        {
            return (left.ExamsRate() != right.ExamsRate());
        }


        public static bool operator >(Student left, Student right)
        {
            return (left.ExamsRate() > right.ExamsRate());
        }

        public static bool operator <(Student left, Student right)
        {
            return (left.ExamsRate() < right.ExamsRate());
        }

        public override string ToString()
        {
            string result = string.Empty;
            result += @$"surname - {Surname}
name - {Name}
patronymic - {Patronymic}
address - {Address}
phone number - {PhoneNumber}
date of birth - {$"{Birthday.ToString("d")}"}";

            return result;
        }

       
        public double this[string name, int index]
        {
            get
            {
                if (name == "offset") return offset[index];
                else if (name == "projects") return projects[index];
                else if (name == "exams") return exams[index];
                else throw new Exception("Не правильное название оценки!");
            }

            set
            {
                if (name == "offset") offset[index] = (int) value;
                else if (name == "projects") projects[index] = (int) value;
                else if (name == "exams") exams[index] = (int) value;
                else throw new Exception("Не правильное название оценки!");
            }
        }

        public object Clone()
        {
            var copyOffset = new List<int>();
            copyOffset.AddRange(this.offset);
            var copyProjects = new List<int>();
            copyProjects.AddRange(this.projects);
            var copyExams = new List<int>();
            copyExams.AddRange(this.exams);
            var copy = new Student(this.Name, this.Surname, this.Patronymic, this.Address, this.PhoneNumber, this.Birthday,
            copyExams, copyProjects, copyOffset);
            return copy;
        }

        public int CompareTo(Student anotherStudent)
        {
            if (this.ExamsRate() > anotherStudent.ExamsRate()) return 1;
            if (this.ExamsRate() < anotherStudent.ExamsRate()) return -1;
            return 0;
        }

    }
}
