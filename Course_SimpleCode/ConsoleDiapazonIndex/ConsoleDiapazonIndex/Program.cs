using System;

namespace ConsoleDiapazonIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = { 2, 41, 53, 38, 76 };

            Console.WriteLine(myArray[^1]);

            int[] myArray2 = myArray[2..];

            string str = "Hellow world!!! =)";
            Console.WriteLine(str[^2..]);

            foreach (var item in myArray2)
                Console.WriteLine($" {item} ");

            Console.WriteLine(" ");

            foreach (var item in myArray2)
            {
                Console.WriteLine(" " + item);
            }
        }
    }
}
