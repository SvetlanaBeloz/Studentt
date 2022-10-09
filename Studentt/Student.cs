using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Studentt
{
    public class Student
    {
        private string name;
        private string surname;
        private string patronymic;
        private string address;
        private string phoneNumber;
        private DateTime birthday;

        private List<int> offset = new List<int>();
        private List<int> projects = new List<int>();
        private List<int> exams = new List<int>();


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
        public Student(string name, string surname, string patronymic) : this (name, surname, patronymic, 
            "street Aleksandrovskaya, 15", "223332", new DateTime(2000, 01, 01)){ }
 
        public Student(string name, string surname, string patronymic, string address, string phoneNumber, DateTime birthday)
        {
            SetName(name);
            SetSurname(surname);
            SetPatronymic(patronymic);
            SetAddress(address);
            SetPhoneNumber(phoneNumber);
            SetBirthday(birthday);
        }

        public void AddOffset(int mark)
        {
            this.offset.Add(mark);
        }

        public void AddProjects(int mark)
        {
            this.projects.Add(mark);
        }

        public void AddExams(int mark)
        {
            this.exams.Add(mark);
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetSurname(string surname)
        {
            this.surname = surname;
        }

        public void SetPatronymic(string patronymic)
        {
            this.patronymic = patronymic;
        }

        public void SetAddress(string address)
        {
            this.address = address;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        public void SetBirthday(DateTime birthday)
        {
            this.birthday = birthday;
        }

        public string GetName()
        {
            return name;
        }

        public string GetSurname()
        {
            return surname;
        }

        public string GetPatronymic()
        {
            return patronymic;
        }
        public string GetAddress()
        {
            return address;
        }

        public string GetPhoneNumber()
        {
            return phoneNumber;
        }

        public DateTime GetBirthday()
        {
            return birthday;
        }

        public DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            DateTime finish = new DateTime(2004, 1, 1);
            int range = (finish - start).Days;
            return birthday = start.AddDays(random.Next(range));
        }
        public double ExamsRate()
        {
            double result = 0;
            foreach (var item in exams)
            {
                result += item;
            }
            return result / exams.Count;
        }
        

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
    }
}
