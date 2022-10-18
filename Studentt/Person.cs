using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Studentt
{
    public class Person
    {
        private string name;
        private string surname;
        private string patronymic;
        private string address;
        private string phoneNumber;
        private DateTime birthday;

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

        enum Gender { Male = 1, Female}

        /// <summary>
        /// Конструктор без параметров с генерацией случайной информации о человеке.
        /// </summary>

        public Person()
        {
            Gender Gender = (Gender)random.Next(1, 3);
            switch (Gender)
            {
                case Gender.Male:
                Surname = surnames[random.Next(10)];
                Name = names[random.Next(10)];
                Patronymic = patronymics[random.Next(10)];
                    break;
            
                case Gender.Female:
            
                Surname = surnames[random.Next(10, 20)];
                Name = names[random.Next(10, 20)];
                Patronymic = patronymics[random.Next(10, 20)];
                    break;
            }
            Address = addresses[random.Next(10)];
            PhoneNumber = phoneNumbers[random.Next(9)];
            RandomDay();
        }

        /// <summary>
        /// Конструктор с параметрами имени, фамилии, отчества
        /// </summary>
        /// <param name="name">Имя человека</param>
        /// <param name="surname">Фамилия человека</param>
        /// <param name="patronymic">Отчество человека</param>

        public Person(string name, string surname, string patronymic) : this(name, surname, patronymic,
            "street Aleksandrovskaya, 15", "223332", new DateTime(2000, 01, 01))
        { }

        /// <summary>
        /// Конструктор со всеми параметрами
        /// </summary>
        /// <param name="name">Имя человека</param>
        /// <param name="surname">Фамилия человека</param>
        /// <param name="patronymic">Отчество человека</param>
        /// <param name="address">Адрес человека</param>
        /// <param name="birthday">День рождение человека</param>
        /// <param name="phoneNumber">номер телефона человека</param>

        public Person(string name, string surname, string patronymic, string address, string phoneNumber, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Address = address;
            PhoneNumber = phoneNumber;
            Birthday = birthday;
        }

        /// <summary>
        /// Свойства поля имени человека
        /// </summary>

        public string Name
        {
            set
            {
                try
                {
                    bool result = value.All(Char.IsLetter);
                    if (!result)
                        throw new Exception("Не можем присвоить человеку вводимое имя, так как имя должно состоять только из букв");
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
        /// Свойства поля фамилии человека
        /// </summary>

        public string Surname
        {
            set
            {
                try
                {
                    bool result = value.All(Char.IsLetter);
                    if (!result)
                        throw new Exception("Не можем присвоить человеку вводимую фамилию, так как фамилия должна состоять " +
                            "только из букв");
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
        /// Свойства поля отчества человека
        /// </summary>

        public string Patronymic
        {
            set
            {
                try
                {
                    bool result = value.All(Char.IsLetter);
                    if (!result)
                        throw new Exception("Не можем присвоить человеку вводимое отчество, так как отчество должно состоять " +
                            "только из букв");
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
        /// Свойства поля адреса человека
        /// </summary>
        public string Address
        {
            set => address = value;
            get => this.address;
        }

        /// <summary>
        /// Свойства поля номера телефона человека
        /// </summary>

        public string PhoneNumber
        {
            set => phoneNumber = value;
            get => this.phoneNumber;
        }

        /// <summary>
        /// Свойства поля дня рождения человека
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
            DateTime start = new(1995, 1, 1);
            DateTime finish = new(2004, 1, 1);
            int range = (finish - start).Days;
            return birthday = start.AddDays(random.Next(range));
        }

        /// <summary>
        /// Вывод на экран информации человеку
        /// </summary>


        public virtual void PrintInfo()
        {
            Console.WriteLine("surname - " + Surname);
            Console.WriteLine("name - " + Name);
            Console.WriteLine("patronymic - " + Patronymic);
            Console.WriteLine("address - " + Address);
            Console.WriteLine("phone number - " + PhoneNumber);
            Console.WriteLine("date of birth - " + ($"{Birthday.ToString("d")}"));
        }

    }
}
