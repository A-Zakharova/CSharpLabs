using System;

namespace Rooms3
{
    class Premise
    {
        public string Square { get; set; }
        public Premise(string number, string name)
        {
            Square = number;

            Console.WriteLine(name);
            Console.WriteLine("Square: " + Square);
        }
    }
    class Rooms : Premise
    {
        private int beds;
        public Rooms(int beds, string number, string name) : base(number, name)
        {
            this.beds = beds;
            Console.WriteLine("The number of beds " + beds + "\n");
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Rooms LivingRoom = new Rooms(2, "24.3 m^2", "Living room");
            Rooms BedRoom = new Rooms(1, "18.7 m^2", "Bedroom");
            Rooms ChildrenRoom = new Rooms(3, "10.9 m^2", "Children's room");
        }
    }
}