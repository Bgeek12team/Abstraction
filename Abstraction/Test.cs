using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
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
    }

    static class P
    {
        static void Main()
        {
            Person Roma = new Person(177, 12);
            Person Grisha = new Person(172, 18);
            Person[] kalibr = new Person[] { Roma, Grisha };
            UniSorter<Person> politech = new UniSorter<Person>(kalibr);

            politech.BubbleSort((p1, p2) => p1.Height - p2.Height, (p1, p2) => p1.Age - p2.Age);

        }
    }
}
