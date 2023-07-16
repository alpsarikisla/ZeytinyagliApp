namespace ZeytinyagliWebApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZeytinyagliWebApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<OliveOilDBModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(OliveOilDBModel context)
        {
            context.Managers.AddOrUpdate(x => x.ID, new Manager() { ID = 1, Name = "Alp", Surname = "Sarıkışla", Password = "1234", Mail = "a.sarikisla@hotmail.com", IsAdmin=true});

            context.Brands.AddOrUpdate(x => x.ID, new Brand() { ID= 1 , Name = "Komimi", Logo="komimi.png"});
        }
    }
}
