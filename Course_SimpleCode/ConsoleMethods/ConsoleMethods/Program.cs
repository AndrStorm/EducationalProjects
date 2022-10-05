using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleMethods
{
    public class Program1
    {
        static void PrintSymbols(string symbol,uint quanity) 
        {
            for (int i = 0; i < quanity; i++)
            Console.Write(symbol);
            Console.WriteLine();   
        }

        public static uint GetQuanity()
        {
            uint quanity = 0;

            while (true)
            {
                try
                {
                    quanity = UInt32.Parse(Console.ReadLine());
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

        static string GetSymbol()
        {
            string symbol="*";
            symbol = Console.ReadLine();
            symbol = symbol.FirstOrDefault().ToString();
            return symbol;
        }

        static void Main(string[] args)
        {
            uint quanityOfSymbols = 0;
            string symbol;


            Console.WriteLine("enter the symbol");
            symbol = GetSymbol();


            Console.WriteLine("enter quanity of "+symbol+" symbols");
            quanityOfSymbols = GetQuanity();


            PrintSymbols(symbol, quanityOfSymbols);


            Console.ReadLine();

        }
    }
}
