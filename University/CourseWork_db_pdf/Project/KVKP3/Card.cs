using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVKP3
{
    class Card
    {
        public int CardId { get; set; }
        public bool card_activated { get; set; }

        public int EmployerId { get; set; }
        public Employer Employer { get; set; }

        public ICollection<Opperation> opperations { get; set; }
        public Card()
        {
            opperations = new List<Opperation>();
        }
    }
}
