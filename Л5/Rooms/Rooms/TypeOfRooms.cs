using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class TypeOfRooms : Room
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
            base.getInfo();
            Console.WriteLine($"Number of TV: {roomStruct.numberOfTV}");
            Console.WriteLine($"Number of baby bed: {roomStruct.numberOfbabybed}");
        }
    }
}
