using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public class TransportEventArgs : EventArgs
    {
        protected readonly string _name;
        public string Name { get => _name; }
        public int Speed { get; set; }
        public TransportEventArgs(string name, int speed)
        {
            this._name = name;
            Speed = speed;
        }
    }
    public abstract class Transport
    {
        protected readonly string _name;
        public event EventHandler Moves;
        public string Name { get => _name; }
        public abstract int Speed { get; set; }
        // конструктор абстрактного класса Transport
        public Transport(string name)
        {
            _name = name;
        }
        public virtual void Move() 
            => Moves?.Invoke(this, new TransportEventArgs(Name, Speed));


    }
    // класс самолета
    public class Plane : Transport
    {
        public override int Speed { get; set; }
        public Plane(string name) : base(name) { }
    }
    // класс машины
    public class Car : Transport
    {
        public override int Speed { get; set; }
        public int PeopleCount { get; set; }
        public Car(string name) : base(name) { }

        public void Accelerate(int speed)
        {
            Speed += speed;
        }

        public void Break()
        {
            Speed = 0;
        }
    }

}
