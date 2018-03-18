namespace MyCreek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class 修改外键关系 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Fields", "MenuItemDefine_Id", "dbo.MenuItemDefines");
            DropIndex("dbo.Fields", new[] { "MenuItemDefine_Id" });
            AddColumn("dbo.Fields", "MenuItemDefine_MenuGuid", c => c.String());
            DropColumn("dbo.Fields", "MenuItemDefine_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fields", "MenuItemDefine_Id", c => c.Int());
            DropColumn("dbo.Fields", "MenuItemDefine_MenuGuid");
            CreateIndex("dbo.Fields", "MenuItemDefine_Id");
            AddForeignKey("dbo.Fields", "MenuItemDefine_Id", "dbo.MenuItemDefines", "Id");
        }
    }
}
