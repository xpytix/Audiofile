

using Audiofile.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Audiofile.DAL
{
    public class UrzadzeniaContext : IdentityDbContext<ApplicationUser>
    {
        public UrzadzeniaContext() : base("UrzadzeniaContext")
        {
        }

        static UrzadzeniaContext()
        {
           Database.SetInitializer<UrzadzeniaContext>(new UrzadzeniaInitializer());
        }

        public static UrzadzeniaContext Create()
        {
            return new UrzadzeniaContext();
        }

        public DbSet<Urzadzenie> Urzadzenia { get; set; }
        public DbSet<Kategoria> Kategorie { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<PozycjaZamowienia> PozycjeZamowienia { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}