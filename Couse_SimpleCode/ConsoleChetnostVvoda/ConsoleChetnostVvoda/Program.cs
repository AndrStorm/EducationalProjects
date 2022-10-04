using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChetnostVvoda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the number");
            int enterValue = Int32.Parse(Console.ReadLine());
            if(enterValue%2==0)
            {
                Console.WriteLine("THe number is even");
            }
            else
            {
                Console.WriteLine("The number is odd");
            }

            Console.ReadKey();

        }
    }
}
