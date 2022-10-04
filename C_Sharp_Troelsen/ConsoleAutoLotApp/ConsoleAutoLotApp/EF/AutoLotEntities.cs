using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ConsoleAutoLotApp.EF
{
    public partial class AutoLotEntities : DbContext
    {
        public AutoLotEntities()
            : base("name=AutoLotConnection")
        {
        }

        public virtual DbSet<CreditRisk> CreditRisks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .Property(e => e.Make)
                .IsFixedLength();

            modelBuilder.Entity<Car>()
                .Property(e => e.Color)
                .IsFixedLength();

            modelBuilder.Entity<Car>()
                .Property(e => e.CarNickName)
                .IsFixedLength();

            modelBuilder.Entity<Car>()
                .HasOptional(e => e.Order)
                .WithRequired(e => e.Car);
        }
    }
}
