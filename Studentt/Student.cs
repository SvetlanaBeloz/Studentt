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
                SetSurname(surnames[random.Next(10)]);
                SetName(names[random.Next(10)]);
                SetPatronymic(patronymics[random.Next(10)]);
            }
            else
            {
                SetSurname(surnames[random.Next(10, 20)]);
                SetName(names[random.Next(10, 20)]);
                SetPatronymic(patronymics[random.Next(10, 20)]);
            }
            SetAddress(addresses[random.Next(10)]);
            SetPhoneNumber(phoneNumbers[random.Next(9)]);
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

        public Student(string name, string surname, string patronymic) : this (name, surname, patronymic, 
            "street Aleksandrovskaya, 15", "223332", new DateTime(2000, 01, 01)){ }

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
            SetName(name);
            SetSurname(surname);
            SetPatronymic(patronymic);
            SetAddress(address);
            SetPhoneNumber(phoneNumber);
            SetBirthday(birthday);
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
        /// Запись имени студента
        /// </summary>
        /// <param name="name"></param>
        public void SetName(string name)
        {
            try
            {
                bool result = name.All(Char.IsLetter);
                if (!result)
                    throw new Exception("Не можем присвоить студенту вводимое имя, так как имя должно состоять только из букв");
                this.name = name;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Запись фамилии студента
        /// </summary>
        /// <param name="surname"></param>
        public void SetSurname(string surname)
        {
            try
            {
                bool result = surname.All(Char.IsLetter);
                if (!result)
                    throw new Exception("Не можем присвоить студенту вводимую фамилию, так как фамилия должна состоять только из букв");
                this.surname = surname;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Запись отчества студента
        /// </summary>
        /// <param name="patronymic">Отчество студента</param>
        public void SetPatronymic(string patronymic)
        {
            try
            {
                bool result = patronymic.All(Char.IsLetter);
                if (!result)
                    throw new Exception("Не можем присвоить студенту вводимое отчество, так как отчество должно состоять только из букв");
                this.patronymic = patronymic;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Запись адреса студента
        /// </summary>
        /// <param name="address">Адрес студента</param>
        public void SetAddress(string address)
        {
            this.address = address;
        }

        /// <summary>
        /// Запись номера телефона студента
        /// </summary>
        /// <param name="phoneNumber">Номер телефона студента</param>

        public void SetPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        /// <summary>
        /// Запись дня рождения студента
        /// </summary>
        /// <param name="birthday">День рождения студента</param>

        public void SetBirthday(DateTime birthday)
        {
            try
            {
                if (birthday.Year < 1970 && birthday.Year > 2006)
                    throw new Exception("Некорректный год рождения!");
                this.birthday = birthday;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message); 
            }
        }

        /// <summary>
        /// Получение имени студента
        /// </summary>
        /// <returns>Имя студента</returns>

        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Получение фамилии студента
        /// </summary>
        /// <returns>Фамилия студента</returns>

        public string GetSurname()
        {
            return surname;
        }

        /// <summary>
        /// Получение отчества студента
        /// </summary>
        /// <returns>Отчество студента</returns>

        public string GetPatronymic()
        {
            return patronymic;
        }

        /// <summary>
        /// Получение адреса студента
        /// </summary>
        /// <returns>Адрес студента</returns>
        public string GetAddress()
        {
            return address;
        }

        /// <summary>
        /// Получение номера телефона студента
        /// </summary>
        /// <returns>Номер телефона студента</returns>

        public string GetPhoneNumber()
        {
            return phoneNumber;
        }

        /// <summary>
        /// Получение дня рождения студента
        /// </summary>
        /// <returns>День рождения студента</returns>

        public DateTime GetBirthday()
        {
            return birthday;
        }

        /// <summary>
        /// Получение случайной даты
        /// </summary>
        /// <returns>День рождения студента</returns>

        public DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            DateTime finish = new DateTime(2004, 1, 1);
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
            Console.WriteLine("surname - " + GetSurname());
            Console.WriteLine("name - " + GetName());
            Console.WriteLine("patronymic - " + GetPatronymic());
            Console.WriteLine("address - " + GetAddress());
            Console.WriteLine("phone number - " + GetPhoneNumber());
            Console.WriteLine("date of birth - " + ($"{GetBirthday().ToString("d")}")); 
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
    }
}
