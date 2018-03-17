namespace MyCreek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class 新增字段 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuItemDefines", "Description", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MenuItemDefines", "Description");
        }
    }
}
