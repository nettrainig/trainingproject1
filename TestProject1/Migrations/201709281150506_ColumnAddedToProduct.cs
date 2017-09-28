namespace TestProject1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnAddedToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "WarehouseID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "WarehouseID");
        }
    }
}
