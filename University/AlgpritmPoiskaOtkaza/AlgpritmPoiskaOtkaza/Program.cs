using System;

namespace AlgpritmPoiskaOtkaza
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initialization...");

            IPIKS infocommunicationSystem = new IPIKS();
            //
            //Test input data
            //
            Uzel uzel1 = new Uzel(true);
            Uzel uzel2 = new Uzel(true);
            Uzel uzel3 = new Uzel(true);
            Uzel uzel4 = new Uzel(false);

            uzel1.nextUzel = uzel2;
            uzel2.nextUzel = uzel3;
            uzel3.nextUzel = uzel4;

            infocommunicationSystem.listOfNodes.Add(uzel1);
            infocommunicationSystem.listOfNodes.Add(uzel2);
            infocommunicationSystem.listOfNodes.Add(uzel3);
            infocommunicationSystem.listOfNodes.Add(uzel4);

            int crack = infocommunicationSystem.SerchCrack();
            if (crack != 0)
            {
                Console.WriteLine("Crack detected between " + crack + " and " + (crack + 1));
            }
            
        }
    }
}
