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
            int n = 4;
            Person[] kalibr = new Person[n];
            for (int i = 0; i < n; i++)
            {
                kalibr[i] = new Person();
            }

            UniSorter<Person> politech = new UniSorter<Person>(kalibr);
            ISorter<Person>.Comparator compareByHeight
                = new ISorter<Person>.Comparator((p1, p2) => p1.Height - p2.Height);
            ISorter<Person>.Comparator compareByAge
                = new ISorter<Person>.Comparator((p1, p2) => p1.Age - p2.Age);
            politech.Randomize();
            Console.WriteLine(politech);

            politech.BubbleSort(compareByHeight);
            Console.WriteLine(politech);
            politech.Randomize();

            politech.BogoBogoSort(compareByHeight);
            Console.WriteLine(politech);
            politech.Randomize();
            
            politech.InsertSort(compareByHeight);
            Console.WriteLine(politech);
            politech.Randomize();

            politech.ShellSort(compareByHeight);
            Console.WriteLine(politech);
            politech.Randomize();

            politech.FastSort(compareByHeight);
            Console.WriteLine(politech);
            politech.Randomize();
            politech.PancakeSort(compareByHeight);
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
