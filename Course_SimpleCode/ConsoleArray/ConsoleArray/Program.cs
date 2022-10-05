using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleArray
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int evenNumbersSumm = 0, min;
            int elementsCount = 0;



            Console.Write("enter array lenght\t");

            while (true)
            {
                try
                {
                    elementsCount = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("wrong number, try again\t");
                    continue;
                }
                break;
            }

            int[] numberArray = new int[elementsCount];



            for (int i = 0; i < numberArray.Length; i++)
            {
                Console.Write("\nenter " + (i + 1) + " number\t");

                try
                {
                    numberArray[i] = Int32.Parse( Console.ReadLine());

                }
                catch (Exception)
                {
                    Console.WriteLine("wrong number, try again\t");
                    i--;
                    continue;
                    
                }
            }
            Console.WriteLine(" ");

            
            int []result = numberArray.Reverse().ToArray();
            Console.WriteLine(result.FirstOrDefault());
            Array.Reverse(numberArray);

            Console.Write("\nreverse array\t");
            for (int i = numberArray.Length -1; i >= 0; i--)
            {
                Console.Write(" " + numberArray[i]);
            }
            Console.WriteLine(" ");





            for (int i = 0; i < numberArray.Length; i++)
            {
                if (numberArray[i]%2==0)
                {
                    evenNumbersSumm += numberArray[i];
                }
                
            }
            Console.WriteLine("\neven numbers summ in the array = " + evenNumbersSumm);





            min = numberArray[0];
            for (int i = 0; i < numberArray.Length; i++)
            {
                if (numberArray[i]<min)
                {
                    min = numberArray[i];
                }
            }
            Console.WriteLine("\nmin = " + min);




            Console.ReadLine();
        }
    }
}
