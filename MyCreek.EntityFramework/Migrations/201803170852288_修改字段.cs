namespace MyCreek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class 修改字段 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MenuItemDefines", "Description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MenuItemDefines", "Description", c => c.Int(nullable: false));
        }
    }
}
