namespace Audiofile.Migrations
{
    using Audiofile.DAL;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Audiofile.DAL.UrzadzeniaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Audiofile.DAL.UrzadzeniaContext";
        }

        protected override void Seed(Audiofile.DAL.UrzadzeniaContext context)
        {
            UrzadzeniaInitializer.SeedUrzadzeniaData(context);
            UrzadzeniaInitializer.SeedUzytkownicy(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
