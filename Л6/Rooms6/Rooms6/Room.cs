using System;

namespace ConsoleApp1
{
    enum bedNum
    {
        First = 1,
        Second,
        Third,
        Fourth
    }

    class Room : Premise
    {
        public int numberofbeds;

        public Room() : this("Неизвестно", "Неизвестно", 0, 0)
        {
        }
        public Room(string a, string b, int c, bedNum f)
        {
            name = a;
            square = b;
            numberofwindows = c;
            ID = generateID();
            numberofbeds = (int)f;
        }

        public override void getInfo()
        {
            Console.WriteLine($"Имя: {name}");
            Console.WriteLine($"Square: {square}");
            Console.WriteLine($"Number of windows: {numberofwindows}");
            Console.WriteLine($"Number of beds: {numberofbeds}");
            Console.WriteLine($"ID: {ID}");
        }


    }
}