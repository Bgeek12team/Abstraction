using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    static class P
    {
        static void Main()
        {
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
}
