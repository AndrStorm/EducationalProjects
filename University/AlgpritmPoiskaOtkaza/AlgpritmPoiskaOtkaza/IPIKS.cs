using System;
using System.Collections.Generic;

namespace AlgpritmPoiskaOtkaza
{
    class IPIKS
    {
        public List<Uzel> listOfNodes = new List<Uzel>();

        public int SerchCrack()
        {
            int totalCount = listOfNodes.Count;
            int curruntElement = 0;
            int curHalf = totalCount/2;

            bool isCrack = false;
            bool crackDetected = false;

            curruntElement = curHalf - 1; //выбор элемента для первого испытания

            while (true)
            {
                curHalf = curHalf / 2;
                Uzel curElement = listOfNodes[curruntElement];
                isCrack = curElement.SendMessage();

                if (isCrack)
                {
                    crackDetected = true;
                    if (curHalf == 0) return curruntElement + 1;     //сбой в текущем элементе

                    curruntElement = (curruntElement) - curHalf;     //выбор элемента в левой части графа

                }
                else
                {
                    if (curHalf == 0)
                        if (crackDetected)
                        {
                            return curruntElement + 2;     //сбой в следующем элементе или не обнаружен
                        }
                        else
                        {
                            Console.WriteLine("Crack don't detected");
                            return 0;                      //сбой не обнаружен
                        }                           

                    curruntElement = (curruntElement) + curHalf;     //выбор элемента в правой части графа
                }
            }
        }
    }
}
