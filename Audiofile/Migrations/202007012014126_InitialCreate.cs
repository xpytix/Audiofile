namespace Audiofile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategoria",
                c => new
                    {
                        KategoriaId = c.Int(nullable: false, identity: true),
                        NazwaKategorii = c.String(nullable: false, maxLength: 100),
                        OpisKategorii = c.String(nullable: false),
                        NazwaPlikuIkony = c.String(),
                    })
                .PrimaryKey(t => t.KategoriaId);
            
            CreateTable(
                "dbo.Urzadzenie",
                c => new
                    {
                        UrzadzenieId = c.Int(nullable: false, identity: true),
                        KategoriaId = c.Int(nullable: false),
                        NazwaUrzadzenia = c.String(nullable: false, maxLength: 100),
                        ProducentUrzadzenia = c.String(),
                        DataDodania = c.DateTime(nullable: false),
                        NazwaPlikuObrazka = c.String(maxLength: 100),
                        OpisUrzadzenia = c.String(),
                        CenaUrzadzenia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ukryty = c.Boolean(nullable: false),
                        OpisSkrocony = c.String(),
                    })
                .PrimaryKey(t => t.UrzadzenieId)
                .ForeignKey("dbo.Kategoria", t => t.KategoriaId, cascadeDelete: true)
                .Index(t => t.KategoriaId);
            
            CreateTable(
                "dbo.PozycjaZamowienia",
                c => new
                    {
                        PozycjaZamowieniaId = c.Int(nullable: false, identity: true),
                        ZamowienieID = c.Int(nullable: false),
                        KursId = c.Int(nullable: false),
                        Ilosc = c.Int(nullable: false),
                        CennaZakupu = c.Decimal(nullable: false, precision: 18, scale: 2),
                        urzadzenie_UrzadzenieId = c.Int(),
                    })
                .PrimaryKey(t => t.PozycjaZamowieniaId)
                .ForeignKey("dbo.Urzadzenie", t => t.urzadzenie_UrzadzenieId)
                .ForeignKey("dbo.Zamowienie", t => t.ZamowienieID, cascadeDelete: true)
                .Index(t => t.ZamowienieID)
                .Index(t => t.urzadzenie_UrzadzenieId);
            
            CreateTable(
                "dbo.Zamowienie",
                c => new
                    {
                        ZamowienieID = c.Int(nullable: false, identity: true),
                        Imie = c.String(nullable: false, maxLength: 50),
                        Nazwisko = c.String(nullable: false, maxLength: 50),
                        Ulica = c.String(nullable: false, maxLength: 50),
                        Miasto = c.String(nullable: false, maxLength: 10),
                        KodPocztowy = c.String(nullable: false, maxLength: 6),
                        Telefon = c.String(nullable: false, maxLength: 11),
                        Email = c.String(nullable: false, maxLength: 50),
                        Komentarz = c.String(),
                        DataDodania = c.DateTime(nullable: false),
                        StanZamowienia = c.Int(nullable: false),
                        WartoscZamownia = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ZamowienieID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PozycjaZamowienia", "ZamowienieID", "dbo.Zamowienie");
            DropForeignKey("dbo.PozycjaZamowienia", "urzadzenie_UrzadzenieId", "dbo.Urzadzenie");
            DropForeignKey("dbo.Urzadzenie", "KategoriaId", "dbo.Kategoria");
            DropIndex("dbo.PozycjaZamowienia", new[] { "urzadzenie_UrzadzenieId" });
            DropIndex("dbo.PozycjaZamowienia", new[] { "ZamowienieID" });
            DropIndex("dbo.Urzadzenie", new[] { "KategoriaId" });
            DropTable("dbo.Zamowienie");
            DropTable("dbo.PozycjaZamowienia");
            DropTable("dbo.Urzadzenie");
            DropTable("dbo.Kategoria");
        }
    }
}
