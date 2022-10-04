using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVKP3
{
    class Employer
    {
        public int EmployerId { get; set; }
        public string employer_name { get; set; }

        public ICollection<Card> cards { get; set; }
        public Employer()
        {
            cards = new List<Card>();
        }
    }
}
