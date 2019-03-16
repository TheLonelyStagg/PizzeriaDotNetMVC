namespace Projekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class utworzenie_baz_produkt_uzytkownik : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produkts",
                c => new
                    {
                        ProduktId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Category = c.String(),
                        ifThreePricepionts = c.Boolean(nullable: false),
                        basePrice = c.Double(nullable: false),
                        medumPrice = c.Double(nullable: false),
                        largePrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProduktId);
            
            CreateTable(
                "dbo.Uzytkowniks",
                c => new
                    {
                        UzytkownikId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        HashedPasswrd = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        PhoneNumber = c.String(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UzytkownikId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Uzytkowniks");
            DropTable("dbo.Produkts");
        }
    }
}
