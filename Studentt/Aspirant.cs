using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentt
{
    public class Aspirant : Student
    {
        private string nameOfDessertation = "Name of dessertation!!";
        private int course = 2;

        public Aspirant() : base() {}

        public Aspirant(string name, string surname, string patronymic,string nameOfDessertation, int course) : 
            base(name, surname, patronymic)
        {
            NameOfDessertation = nameOfDessertation;
            Course = course;
        }
        public string NameOfDessertation
        {
            set { nameOfDessertation = value; }
            get { return nameOfDessertation; }
        }

        public int Course
        {
            set { course = value; }
            get { return course; }
        }

        public override void PrintInfo()
        {
            Console.WriteLine("surname - " + Surname);
            Console.WriteLine("name - " + Name);
            Console.WriteLine("patronymic - " + Patronymic);
            Console.WriteLine("address - " + Address);
            Console.WriteLine("phone number - " + PhoneNumber);
            Console.WriteLine("date of birth - " + ($"{Birthday.ToString("d")}"));
            Console.WriteLine("\nНазвание диссертации - " + NameOfDessertation);
            Console.WriteLine("Номер курса - " + Course);
        }
    }
}
