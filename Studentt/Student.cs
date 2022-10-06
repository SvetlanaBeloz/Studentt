using System;
using System.Collections.Generic;
using System.Linq;
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

        public Student() : this ("Alexsandr", "Aleksandrov", "Aleksandrovich", "street Aleksandrovskaya, 15", "223332", 
            new DateTime(2000,01,01)) {}

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

        public void PrintInfo()
        {
            Console.WriteLine("name - " + GetName());
            Console.WriteLine("surname - " + GetSurname());
            Console.WriteLine("patronymic - " + GetPatronymic());
            Console.WriteLine("address - " + GetAddress());
            Console.WriteLine("phone number - " + GetPhoneNumber());
            Console.WriteLine("date of birth - " + ($"{GetBirthday().ToString("d")}")); 
            Console.Write ("offsets  :\t");
            for (int i = 0; i < offset.Count; i++)
            {
                Console.Write(offset[i] + "\t");
            }
            Console.Write("\nprojects :\t");
            for (int i = 0; i < projects.Count; i++)
            {
                Console.Write(projects[i] + "\t");
            }
            Console.Write("\nexams    :\t");
            for (int i = 0; i < exams.Count; i++)
            {
                Console.Write(exams[i] + "\t");
            }
        }
    }
}
