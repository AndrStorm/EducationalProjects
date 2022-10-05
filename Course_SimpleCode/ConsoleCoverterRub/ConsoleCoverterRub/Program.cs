using System;

namespace ConsoleCoverterRub
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число рублей");

            string enterValue = Console.ReadLine();
            double rub,rubToUSD=75,rubToEur=90;


            bool tryConvert = double.TryParse(enterValue, out rub);
            if (tryConvert){  
                Console.WriteLine(rub + " rub = " + Math.Round(rub / rubToUSD,2) + " USD ");
                Console.WriteLine(rub + " rub = " + Math.Round(rub / rubToEur,2) + " EUR ");
            }
            else
                {
                Console.WriteLine(" ошибка конвертации");
                }


            Console.ReadLine();
            
        }
    }
}
