namespace Projekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zmiana_produkt_cena_decimal2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produkts", "basePrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produkts", "basePrice", c => c.Single(nullable: false));
        }
    }
}
