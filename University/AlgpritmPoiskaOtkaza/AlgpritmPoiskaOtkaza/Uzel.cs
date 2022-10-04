using System;

namespace AlgpritmPoiskaOtkaza
{
    class Uzel
    {
        public Uzel nextUzel;
        private bool isWorking =true;

        public Uzel(bool isWorking, Uzel next=null)
        {
            this.isWorking = isWorking;
            nextUzel = next;
        }

        public bool SendMessage()
        {
            if (nextUzel==null)
            {
                return false;
            }

            bool crack = false;

            if(nextUzel.isWorking == true)
                crack = false;

            if (nextUzel.isWorking == false)
                crack = true;

            return crack;
        }

        public bool GetIsWorking()
        {
            return isWorking;
        }
    }
}
