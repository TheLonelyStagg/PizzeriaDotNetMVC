namespace Projekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zamina_modelu_produktu : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Produkts", "ifThreePricepionts");
            DropColumn("dbo.Produkts", "medumPrice");
            DropColumn("dbo.Produkts", "largePrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produkts", "largePrice", c => c.Double(nullable: false));
            AddColumn("dbo.Produkts", "medumPrice", c => c.Double(nullable: false));
            AddColumn("dbo.Produkts", "ifThreePricepionts", c => c.Boolean(nullable: false));
        }
    }
}
