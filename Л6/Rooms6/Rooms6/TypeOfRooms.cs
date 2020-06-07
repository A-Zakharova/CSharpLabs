using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class TypeOfRooms : Room, IComparable
    {
        public struct parametre
        {
            public int numberOfTV;
            public int numberOfbabybed;

        }

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

        public int CompareTo(object obj)
        {
            if (this.getWindows() > ((TypeOfRooms)obj).getWindows())
            {
                return 1;
            }
            else if (this.getWindows() < ((TypeOfRooms)obj).getWindows())
            {
                return -1;
            }
            else
                return 0;
        }
    }
}