namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edititem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "QuantityType", c => c.String());
            AddColumn("dbo.Items", "BaseQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "CreationDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Items", "AmmountInKgs");
            DropColumn("dbo.Items", "Supplier");
            DropColumn("dbo.Items", "LowerThreshhold");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "LowerThreshhold", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "Supplier", c => c.String());
            AddColumn("dbo.Items", "AmmountInKgs", c => c.Int(nullable: false));
            DropColumn("dbo.Items", "CreationDate");
            DropColumn("dbo.Items", "BaseQuantity");
            DropColumn("dbo.Items", "QuantityType");
            DropColumn("dbo.Items", "Quantity");
        }
    }
}
