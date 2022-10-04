using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassCarLibrary;

namespace ConsoleClientOfdll
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("**** * C# CarLibrary Client App *****");
            // Создать объект SportsCar.
            SportCar viper = new SportCar("Viper", 240, 40);
            viper.TurboBoost();
            // Создать объект MiniVan.
            MiniVan mv = new MiniVan();
            mv.TurboBoost();
            Console.WriteLine("Done . Press any key to terminate");
            Console.ReadLine();
        }
    }
}
