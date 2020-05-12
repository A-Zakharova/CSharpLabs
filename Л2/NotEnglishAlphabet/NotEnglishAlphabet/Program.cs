using System;


namespace NotEnglishAlphabet
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountofletters=0, indicator = 0;
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Console.WriteLine("Enter your line: ");
            string str = Console.ReadLine();

            for (int i = 0; i <= str.Length-1; i++)
            {
                if ((str[i] == str.ToUpper()[i])&&(str[i]!=' '))
                {
                    for (int j = 0; j <= alphabet.Length-1; j++)
                    {
                        if (str[i] == alphabet[j])
                        {
                            indicator = 0;
                            break; 
                        }
                        else indicator = 1 ;
                    }
                    if (indicator == 1) amountofletters++;
                }
            }
            Console.WriteLine("The number of capital letters of non-English alphabet =  " + amountofletters);
        }
    }
}
