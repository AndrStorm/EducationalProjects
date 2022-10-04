using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEnum
{
    class Program
    {

        enum DayOfWeek
        {
            monday = 1,
            tuesday,
            wednsday,
            thursday,
            friday,
            saturday,
            sunday
        }
        static void Main(string[] args)
        {
            DayOfWeek dayOfWeek = DayOfWeek.friday;

            int dayValue = 3;

            if (Enum.IsDefined(typeof(DayOfWeek),dayValue))
            {
                dayOfWeek = (DayOfWeek)dayValue;
            }
            else
            {
                throw new Exception("Invalid day of week value");
            }

            Console.WriteLine(dayOfWeek);

            Console.WriteLine((int)dayOfWeek);



            Console.WriteLine();



            Console.WriteLine(typeof(DayOfWeek));

            Console.WriteLine(Enum.GetUnderlyingType(typeof(DayOfWeek)));

            Console.WriteLine();



            var daysOfWeek = Enum.GetValues(typeof(DayOfWeek));
            foreach (var day in daysOfWeek)
            {
                Console.WriteLine(day);
            }

            Console.ReadLine();

        }
    }
}
