using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    static class P
    {
        static void Main()
        {
            
            FullName[] fullNames = new FullName[5];
            fullNames[0] = new FullName("Борздов", "Марк", "Александрович");
            fullNames[1] = new FullName("Богданов", "Никита", "Несаныч");
            fullNames[2] = new FullName("Соболев", "Роман", "Валерьевич");
            fullNames[3] = new FullName("Аванесян", "Григорий", "Ромаевич");
            fullNames[4] = new FullName("Иванов", "Алексей", "Михайлович");

            UniSorter<FullName> politech2 = new UniSorter<FullName>(fullNames);

            ISorter<FullName>.Comparator compareByLastName 
                = ((n1, n2) => string.Compare(n1.LastName, n2.LastName, StringComparison.OrdinalIgnoreCase));
            ISorter<FullName>.Comparator compareByFirstName 
                = ((n1, n2) => string.Compare(n1.FirstName, n2.FirstName, StringComparison.OrdinalIgnoreCase));
            ISorter<FullName>.Comparator compareByMiddleName 
                = ((n1, n2) => string.Compare(n1.MiddleName, n2.MiddleName, StringComparison.OrdinalIgnoreCase));
            politech2.FastSort(compareByLastName,
                compareByFirstName,
                compareByMiddleName);


            Console.WriteLine("Исходный:");
            Console.WriteLine(politech2);

            int n = 7;
            Person[] kalibr = new Person[n];
            //for (int i = 0; i < n; i++)
            //    kalibr[i] = new Person();
            kalibr[0] = new Person(181, 18);
            kalibr[1] = new Person(181, 19);
            kalibr[2] = new Person(173, 19);
            kalibr[3] = new Person(177, 19);
            kalibr[4] = new Person(174, 19);
            kalibr[5] = new Person(181, 20);
            kalibr[6] = new Person(178, 19);


            UniSorter<Person> politech = new UniSorter<Person>(kalibr);
            ISorter<Person>.Comparator compareByHeight
                = new ISorter<Person>.Comparator((p1, p2) => p1.Height - p2.Height);
            ISorter<Person>.Comparator compareByAge
                = new ISorter<Person>.Comparator((p1, p2) => p1.Age - p2.Age);


            Console.WriteLine("Исходный:");
            Console.WriteLine(politech);

            Console.WriteLine("Пузырьковая:");
            politech.BubbleSort(compareByHeight, compareByAge);
            Console.WriteLine(politech);
            politech.Randomize();

            Console.WriteLine("Богобого:");
            politech.BogoBogoSort(compareByHeight, compareByAge);
            Console.WriteLine(politech);
            politech.Randomize();

            Console.WriteLine("Вставками:");
            politech.InsertSort(compareByHeight, compareByAge);
            Console.WriteLine(politech);
            politech.Randomize();

            Console.WriteLine("Шелла:");
            politech.ShellSort(compareByHeight, compareByAge);
            Console.WriteLine(politech);
            politech.Randomize();

            Console.WriteLine("Быстрая:");
            politech.FastSort(compareByHeight, compareByAge);
            Console.WriteLine(politech);
            politech.Randomize();

            Console.WriteLine();
        }
    }

    public class Person
    {
        private Random rnd = new Random();
        private int height;
        private int age;
        public int Height { get { return height; } set { height = value; } }
        public int Age { get { return age; } set { age = value; } }

        public Person()
        {
            height = rnd.Next(50, 250);
            age = rnd.Next(0, 100);
        }

        public Person(int height, int age)
        {
            this.height = height;
            this.age = age;
        }

        public override string ToString()
        {
            return ("Height = " + height + ", Age = " + age + "; ");
        }
    }
    public class FullName
    {
        public string LastName { get; }
        public string FirstName { get; }
        public string MiddleName { get; }

        public FullName(string lastName, string firstName, string middleName)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
            this.MiddleName = middleName;
        }

        public int CompareTo(FullName other)
        {
            int lastNameComparison = string.Compare(LastName, other?.LastName, StringComparison.OrdinalIgnoreCase);

            if (lastNameComparison != 0)
            {
                return lastNameComparison;
            }

            int firstNameComparison = string.Compare(FirstName, other?.FirstName, StringComparison.OrdinalIgnoreCase);

            if (firstNameComparison != 0)
            {
                return firstNameComparison;
            }

            return string.Compare(MiddleName, other?.MiddleName, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return $"ФИО: {LastName} {FirstName} {MiddleName},\n";
        }
    }
}
