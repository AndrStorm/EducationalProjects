using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMethodsArray
{
    class Program
    {
        static int SearchIndex (int[] newArray, int number)
        {
            int index=-1;
            for (int i = 0; i < newArray.Length; i++)
            {
                if (number == newArray[i])
                {
                    index = i;
                    return index;
                }
            }


            return index;

        }

        static int GetNumber()
        {
            int quanity = 0;

            while (true)
            {
                try
                {
                    quanity = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("wrong number, try again");
                    continue;
                }
                break;
            }

            return quanity;
        }
        static void Main(string[] args)
        {
            int[] myArray = { 1, 3, 6, 12, 54, 2, 34, 25, 6, 7 };
            int enterNumber = 0;

            Console.WriteLine("Enter the number");
            enterNumber = GetNumber();
            Console.WriteLine(SearchIndex(myArray,enterNumber));
            Console.ReadLine();


        }
    }
}
