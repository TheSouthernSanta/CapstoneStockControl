namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateItems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "AmmountInKgs", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "LowerThreshhold", c => c.Int(nullable: false));
            AlterColumn("dbo.Items", "Name", c => c.String());
            AlterColumn("dbo.Items", "Supplier", c => c.String());
            AlterColumn("dbo.Items", "UseBy", c => c.DateTime(nullable: false));
            DropColumn("dbo.Items", "Ammount");
            DropColumn("dbo.Items", "Threshhold");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Threshhold", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "Ammount", c => c.Int(nullable: false));
            AlterColumn("dbo.Items", "UseBy", c => c.Int(nullable: false));
            AlterColumn("dbo.Items", "Supplier", c => c.Int(nullable: false));
            AlterColumn("dbo.Items", "Name", c => c.Int(nullable: false));
            DropColumn("dbo.Items", "LowerThreshhold");
            DropColumn("dbo.Items", "AmmountInKgs");
        }
    }
}
