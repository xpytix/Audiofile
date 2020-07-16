namespace Audiofile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Czwarta : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PozycjaZamowienia", "urzadzenie_UrzadzenieId", "dbo.Urzadzenie");
            DropIndex("dbo.PozycjaZamowienia", new[] { "urzadzenie_UrzadzenieId" });
            RenameColumn(table: "dbo.PozycjaZamowienia", name: "urzadzenie_UrzadzenieId", newName: "UrzadzenieId");
            AlterColumn("dbo.PozycjaZamowienia", "UrzadzenieId", c => c.Int(nullable: false));
            CreateIndex("dbo.PozycjaZamowienia", "UrzadzenieId");
            AddForeignKey("dbo.PozycjaZamowienia", "UrzadzenieId", "dbo.Urzadzenie", "UrzadzenieId", cascadeDelete: true);
            DropColumn("dbo.PozycjaZamowienia", "KursId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PozycjaZamowienia", "KursId", c => c.Int(nullable: false));
            DropForeignKey("dbo.PozycjaZamowienia", "UrzadzenieId", "dbo.Urzadzenie");
            DropIndex("dbo.PozycjaZamowienia", new[] { "UrzadzenieId" });
            AlterColumn("dbo.PozycjaZamowienia", "UrzadzenieId", c => c.Int());
            RenameColumn(table: "dbo.PozycjaZamowienia", name: "UrzadzenieId", newName: "urzadzenie_UrzadzenieId");
            CreateIndex("dbo.PozycjaZamowienia", "urzadzenie_UrzadzenieId");
            AddForeignKey("dbo.PozycjaZamowienia", "urzadzenie_UrzadzenieId", "dbo.Urzadzenie", "UrzadzenieId");
        }
    }
}
