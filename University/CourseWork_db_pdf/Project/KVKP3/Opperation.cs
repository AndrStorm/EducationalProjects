using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVKP3
{
    class Opperation
    {
        public int OpperationId { get; set; }
        public DateTime use_date { get; set; }
        public bool used_successfull { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}
