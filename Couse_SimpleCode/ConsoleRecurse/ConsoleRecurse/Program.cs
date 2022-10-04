using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRecurse
{
    class Program
    {
        static void PrintArray(int[] array, int index = 0)
        {
            if (index < array.Length )
            {
                Console.Write(array[index] + " ");
                PrintArray(array , index+1);
            }
           
        }

        static int SummArray(int[] array, int firstElement = 0)
        {
            if (firstElement < array.Length-1)
            {  
                return array[firstElement] + SummArray(array, firstElement + 1);
            }
            return array[firstElement];   
        }

        static int SummOfdigits(int value)
        {
            if (value < 10)
                return value;

            return value % 10 + SummOfdigits(value / 10);
        }
        static void Main(string[] args)
        {
            int[] myArray= { 123, 66, 23, 21, 77 };

            PrintArray(myArray);
            Console.WriteLine();

            Console.WriteLine(SummArray(myArray));
            Console.WriteLine();

            Console.WriteLine(SummOfdigits(1234));

            Console.ReadLine();
        }
    }
}
