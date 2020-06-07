using System;

namespace ConsoleApp1
{
    class TypeOfRooms : Room
    {
        public struct parametre
        {
            public int numberOfTV;
            public int numberOfbabybed;

        }

        public delegate void forEvent(string mes);
        public event forEvent checkWindows;

        public parametre roomStruct;

        public TypeOfRooms() : this("Неизвестно", "Неизвестно", 0, 0, 0, 0)
        {
            ID = 0;
        }
        public TypeOfRooms(string a, string b, int c, bedNum f, int g, int h)
        {
            name = a;
            square = b;
            numberofwindows = c;
            ID = generateID();
            numberofbeds = (int)f;
            roomStruct.numberOfTV = g;
            roomStruct.numberOfbabybed = h;
        }

        public override void getInfo()
        {
            Console.WriteLine($"Имя: {name}");
            Console.WriteLine($"Square: {square}");
            Console.WriteLine($"Number of windows: {numberofwindows}");
            Console.WriteLine($"Number of beds: {numberofbeds}");
            Console.WriteLine($"Number of TV: {roomStruct.numberOfTV}");
            Console.WriteLine($"Number of baby bed: {roomStruct.numberOfbabybed}");
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine("");
        }

    
    }
}