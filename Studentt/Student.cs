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
    public class Student
    {
        private string name;
        private string surname;
        private string patronymic;
        private string address;
        private string phoneNumber;
        private DateTime birthday;

        private List<int> offset = new();
        private List<int> projects = new();
        private List<int> exams = new();


        public static string[] names = {"Александр", "Алексей", "Андрей", "Василий", "Георгий", "Михаил", "Никита", "Фёдор", "Тимофей",
            "Семён", "Дарья", "Елена", "Марина", "Илона", "Варвара", "Ирина", "Татьяна", "Светлана", "Ольга", "Юлия"};

        public static string[] surnames = {"Александров", "Алексеев", "Андреев", "Васильев", "Георгиев", "Михайлов", "Никитин", "Федоров",
        "Тимофеев", "Семенов", "Александрова", "Алексеева", "Андреева", "Васильева", "Георгиева", "Михайлова", "Никитина", "Федорова",
        "Тимофеева", "Семенова"};

        public static string[] patronymics = {"Александрович", "Алексеевич", "Андреевич", "Васильевич", "Георгиевич", "Михайлович",
            "Никитович", "Федорович", "Тимофеевич", "Семенович", "Александровна", "Алексеевна", "Андреевна", "Васильевна",
            "Георгиевна", "Михайловна", "Никитична", "Федоровна", "Тимофеевна", "Семеновна"};

        public static string[] addresses = {"Дерибасовская 15", "Гоголя 3", "Марсельская 60", "Греческая 18", "Левитана 23", "Львовская 34",
        "Бугаевская 40", "Польская 13", "Виноградная 25", "Гаванная 1"};

        public static string[] phoneNumbers = { "111111", "222222", "333333", "444444", "555555", "666666", "777777", "888888", "999999" };

        public static Random random = new Random();

        /// <summary>
        /// Конструктор без параметров с генерацией случайной информации о студенте.
        /// </summary>

        public Student()
        {
            int gender = random.Next(0, 2);
            if (gender == 0)
            {
                Surname = surnames[random.Next(10)];
                Name = names[random.Next(10)];
                Patronymic = patronymics[random.Next(10)];
            }
            else
            {
                Surname = surnames[random.Next(10, 20)];
                Name = names[random.Next(10, 20)];
                Patronymic = patronymics[random.Next(10, 20)];
            }
            Address = addresses[random.Next(10)];
            PhoneNumber = phoneNumbers[random.Next(9)];
            RandomDay();
            for (int j = 0; j < 8; j++)
            {
                AddExams(random.Next(2, 13));
                AddProjects(random.Next(2, 13));
                AddOffset(random.Next(2, 13));
            }
        }

        /// <summary>
        /// Конструктор с параметрами имени, фамилии, отчества
        /// </summary>
        /// <param name="name">Имя студента</param>
        /// <param name="surname">Фамилия студента</param>
        /// <param name="patronymic">Отчество студента</param>

        public Student(string name, string surname, string patronymic) : this(name, surname, patronymic,
            "street Aleksandrovskaya, 15", "223332", new DateTime(2000, 01, 01))
        { }

        /// <summary>
        /// Конструктор со всеми параметрами
        /// </summary>
        /// <param name="name">Имя студента</param>
        /// <param name="surname">Фамилия студента</param>
        /// <param name="patronymic">Отчество студента</param>
        /// <param name="address">Адрес студента</param>
        /// <param name="birthday">День рождение студента</param>
        /// <param name="phoneNumber">номер телефона студента</param>

        public Student(string name, string surname, string patronymic, string address, string phoneNumber, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Address = address;
            PhoneNumber = phoneNumber;
            Birthday = birthday;
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
        /// Свойства поля имени студента
        /// </summary>
       
        public string Name
        {
            set {
                try
                {
                    bool result = value.All(Char.IsLetter);
                    if (!result)
                        throw new Exception("Не можем присвоить студенту вводимое имя, так как имя должно состоять только из букв");
                    name = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            get => this.name;
        }

        /// <summary>
        /// Свойства поля фамилии студента
        /// </summary>
     
        public string Surname
        {
            set
            {
                try
                {
                    bool result = value.All(Char.IsLetter);
                    if (!result)
                        throw new Exception("Не можем присвоить студенту вводимую фамилию, так как фамилия должна состоять только из букв");
                    surname = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            get => this.surname;
        }

        /// <summary>
        /// Свойства поля отчества студента
        /// </summary>
        
        public string Patronymic
        {
            set
            {
                try
                {
                    bool result = value.All(Char.IsLetter);
                    if (!result)
                        throw new Exception("Не можем присвоить студенту вводимое отчество, так как отчество должно состоять только из букв");
                    patronymic = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            get => this.patronymic;
        }

        /// <summary>
        /// Свойства поля адреса студента
        /// </summary>
        
        public string Address { 
            set =>address = value;
            get =>this.address; }


        /// <summary>
        /// Свойства поля номера телефона студента
        /// </summary>


        public string PhoneNumber
        {
            set => phoneNumber = value;
            get => this.phoneNumber;
        }

        /// <summary>
        /// Свойства поля дня рождения студента
        /// </summary>


        public DateTime Birthday
        {
            set
            {
                try
                {
                    if (value.Year < 1970 && value.Year > 2006)
                        throw new Exception("Некорректный год рождения!");
                    birthday = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            get => this.birthday;
        }
        /// <summary>
        /// Формирование случайной даты в заданном диапазоне
        /// </summary>
        /// <returns>день рождения</returns>

        public DateTime RandomDay()
        {
            DateTime start = new (1995, 1, 1);
            DateTime finish = new (2004, 1, 1);
            int range = (finish - start).Days;
            return birthday = start.AddDays(random.Next(range));
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

        public void PrintInfo()
        {
            Console.WriteLine("surname - " + Surname);
            Console.WriteLine("name - " + Name);
            Console.WriteLine("patronymic - " + Patronymic);
            Console.WriteLine("address - " + Address);
            Console.WriteLine("phone number - " + PhoneNumber);
            Console.WriteLine("date of birth - " + ($"{Birthday.ToString("d")}")); 
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
    }
}
