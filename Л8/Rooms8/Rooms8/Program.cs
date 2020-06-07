using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TypeOfRooms[] array = new TypeOfRooms[5];
            array[0] = new TypeOfRooms("Bedroom", "22.4 km^2", 2, (bedNum)1, 1, 0);
            array[1] = new TypeOfRooms("Baby bedroom", "12.3 km^2", 1, (bedNum)0, 0, 1);
            array[2] = new TypeOfRooms("Guest room", "24.7 km^2", 2, (bedNum)2, 1, 0);
            array[3] = new TypeOfRooms("Kitchen", "15.6 km^2", 3, (bedNum)0, 1, 0);
            array[4] = new TypeOfRooms("Children room", "35.9 km^2", 0, (bedNum)2, 4, 1);
 

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    if (array[i].getWindows() < 1)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    array[i].checkWindows += (mes) => Console.ForegroundColor = ConsoleColor.Red;
                }
                
                array[i].checkWindows += delegate (string mes)
                {
                    Console.WriteLine(mes);
                };
                array[i].getInfo();
            }


        }
    }
}

