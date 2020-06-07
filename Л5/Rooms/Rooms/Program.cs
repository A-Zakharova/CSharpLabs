using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TypeOfRooms roomType = new TypeOfRooms("22.4 km^2", "Bedroom", 2, (bedNum)1, 1, 0);
            roomType.getInfo();

        }
    }
}
