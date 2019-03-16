namespace Projekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodanie_StringLenght : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produkts", "Name", c => c.String(nullable: false, maxLength: 35));
            AlterColumn("dbo.Produkts", "Description", c => c.String(maxLength: 150));
            AlterColumn("dbo.Produkts", "Category", c => c.String(maxLength: 35));
            AlterColumn("dbo.Uzytkowniks", "Username", c => c.String(nullable: false, maxLength: 35));
            AlterColumn("dbo.Uzytkowniks", "HashedPasswrd", c => c.String(nullable: false, maxLength: 35));
            AlterColumn("dbo.Uzytkowniks", "Name", c => c.String(maxLength: 35));
            AlterColumn("dbo.Uzytkowniks", "Surname", c => c.String(maxLength: 35));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Uzytkowniks", "Surname", c => c.String());
            AlterColumn("dbo.Uzytkowniks", "Name", c => c.String());
            AlterColumn("dbo.Uzytkowniks", "HashedPasswrd", c => c.String(nullable: false));
            AlterColumn("dbo.Uzytkowniks", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Produkts", "Category", c => c.String());
            AlterColumn("dbo.Produkts", "Description", c => c.String());
            AlterColumn("dbo.Produkts", "Name", c => c.String(nullable: false));
        }
    }
}
