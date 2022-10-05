using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleСalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.Clear();

                double firstValue, secondValue;

                try
                {
                    Console.WriteLine("enter the first value");
                    firstValue = double.Parse(Console.ReadLine());


                    Console.WriteLine("enter the second value");
                    secondValue = double.Parse(Console.ReadLine());
                }
                catch (Exception)
                {

                    Console.WriteLine("Can't recognize the value");
                    Console.ReadLine();
                    continue;
                }
                


                Console.WriteLine("enter the operation");
                ConsoleKey consoleKey = Console.ReadKey().Key;
                Console.WriteLine(" ");



                if (consoleKey == ConsoleKey.Add)
                {
                    
                    Console.WriteLine("a + b" + " = " + (firstValue + secondValue));
                }
                else if (consoleKey == ConsoleKey.OemMinus)
                {
                    
                    Console.WriteLine("a - b" + " = " + (firstValue - secondValue));
                }
                else if (consoleKey == ConsoleKey.Multiply)
                {
                    
                    Console.WriteLine("a * b" + " = " + (firstValue * secondValue));
                }
                else if (consoleKey == ConsoleKey.Divide)
                {
                    
                    Console.WriteLine("a / b" + " = " + (firstValue / secondValue));
                }
                else
                {
                    Console.WriteLine("unknown action");
                }

                Console.WriteLine("press enter to continue");
                Console.ReadKey();

            }

           
        }
            
    }
}
