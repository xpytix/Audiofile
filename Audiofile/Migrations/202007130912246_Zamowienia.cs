namespace Audiofile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Zamowienia : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Zamowienie", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.Zamowienie", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
            AddColumn("dbo.Zamowienie", "Adres", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Zamowienie", "Miasto", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Zamowienie", "Telefon", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Zamowienie", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Zamowienie", "Ulica");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Zamowienie", "Ulica", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Zamowienie", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Zamowienie", "Telefon", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Zamowienie", "Miasto", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.Zamowienie", "Adres");
            RenameIndex(table: "dbo.Zamowienie", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Zamowienie", name: "UserId", newName: "ApplicationUser_Id");
        }
    }
}
