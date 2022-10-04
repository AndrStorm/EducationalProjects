using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDiapozonWhile
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstValue, secondValue;
            uint oddNumberCounter = 0, evenNumberCounter = 0;
            int oddSumm=0, evenSumm=0;

            Console.WriteLine("enter min of range");
            firstValue = Int32.Parse(Console.ReadLine());
            Console.WriteLine("enter max of range");
            secondValue = Int32.Parse(Console.ReadLine());

            while (firstValue <= secondValue)
            {
                if (firstValue%2==0)
                {
                    evenNumberCounter++;
                    evenSumm += firstValue;
                }
                else
                {
                    oddNumberCounter++;
                    oddSumm += firstValue;
                }

                firstValue++;
            }

            Console.WriteLine("even number counter " + evenNumberCounter);
            Console.WriteLine("even summ "+evenSumm);
            Console.WriteLine("odd number counter "+oddNumberCounter);
            Console.WriteLine("odd summ "+oddSumm);
            Console.ReadKey();
        }
    }
}
