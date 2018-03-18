namespace MyCreek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class 修改field字段 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fields", "Order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fields", "Order");
        }
    }
}
