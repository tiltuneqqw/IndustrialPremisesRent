using Microsoft.EntityFrameworkCore;
using IndustrialPremisesRent.Models;

namespace IndustrialPremisesRent.Data
{
    public class IndustrialPremisesRentContext : DbContext
    {
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<IndustrialPremise> IndustrialPremises { get; set; }

        public IndustrialPremisesRentContext()
        {
        }

        public IndustrialPremisesRentContext(DbContextOptions<IndustrialPremisesRentContext> options) : base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EquipmentType>().ToTable("EquipmentType");
            modelBuilder.Entity<IndustrialPremise>().ToTable("IndustrialPremise");
            modelBuilder.Entity<Contract>().ToTable("Contract");
        }
    }
}