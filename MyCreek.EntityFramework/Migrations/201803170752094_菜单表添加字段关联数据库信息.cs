namespace MyCreek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class 菜单表添加字段关联数据库信息 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuItemDefines", "DBTable", c => c.String());
            AddColumn("dbo.MenuItemDefines", "ExecSQL", c => c.String());
            AddColumn("dbo.MenuItemDefines", "DBView", c => c.String());
            AddColumn("dbo.MenuItemDefines", "Procedure", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MenuItemDefines", "Procedure");
            DropColumn("dbo.MenuItemDefines", "DBView");
            DropColumn("dbo.MenuItemDefines", "ExecSQL");
            DropColumn("dbo.MenuItemDefines", "DBTable");
        }
    }
}
