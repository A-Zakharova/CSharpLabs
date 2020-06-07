using System;

namespace ConsoleApp1
{
    class Premise
    {
        protected string name;
        protected string square;
        protected int numberofwindows;
        public static int ID;

        public Premise() : this("Неизвестно")
        {
        }
        public Premise(string a) : this(a, "Неизвестно", 0)
        {
        }
        public Premise(string a, string b) : this(a, b, 0)
        {
        }
        public Premise(string a, int c) : this(a, "Неизвестно", c)
        {
        }
        public Premise(int b, string c) : this("Неизвестно", c, b)
        {
        }
        public Premise(string a, string b, int c)
        {
            name = a;
            square = b;
            numberofwindows = c;
        }


        public void setValue(string nameValue, string squareValue)
        {
            name = nameValue;
            square = squareValue;
        }
        public string getName()
        {
            return name;
        }
        public string getCountry()
        {
            return square;
        }

        public void setValue(int windowsValue)
        {
            numberofwindows = windowsValue;
        }
        public int getAge()
        {
            return numberofwindows;
        }

        public virtual void getInfo()
        {
            Console.WriteLine($"Имя: {name}");
            Console.WriteLine($"Square: {square}");
            Console.WriteLine($"Number of windows: {numberofwindows}");
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine("");
        }


        public int generateID()
        {
            Random rnd = new Random();
            return ID = rnd.Next(100000, 999999);
        }


    }
}