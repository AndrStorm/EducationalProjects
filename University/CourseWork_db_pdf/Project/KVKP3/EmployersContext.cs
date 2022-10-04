using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace KVKP3
{
    class EmployersContext : DbContext
    {
        public EmployersContext() :
            base("DBConnection")
        { }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Opperation> Opperations { get; set; }


    }
}
