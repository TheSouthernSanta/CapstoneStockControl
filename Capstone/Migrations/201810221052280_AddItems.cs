namespace Capstone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Ammount = c.Int(nullable: false),
                        Supplier = c.Int(nullable: false),
                        UseBy = c.Int(nullable: false),
                        Threshhold = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Items");
        }
    }
}
