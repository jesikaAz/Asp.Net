using System.Data.Entity;
using BO;


namespace TP_dojo.Models
{
    public class Context: DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Samourai>().HasMany(s => s.ArtsMartiaux).WithMany();
            modelBuilder.Entity<Samourai>().HasOptional(s => s.Arme).WithOptionalPrincipal();

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<BO.Samourai> Samourais { get; set; }

        public DbSet<BO.Arme> Armes { get; set; }

        public DbSet<BO.ArtMartial> ArtMartials { get; set; }

    }
}