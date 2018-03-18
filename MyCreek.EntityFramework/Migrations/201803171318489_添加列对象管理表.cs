namespace MyCreek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class 添加列对象管理表 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fields",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColName = c.String(),
                        ColType = c.String(),
                        IsNull = c.Boolean(nullable: false),
                        MenuItemDefine_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuItemDefines", t => t.MenuItemDefine_Id)
                .Index(t => t.MenuItemDefine_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Fields", "MenuItemDefine_Id", "dbo.MenuItemDefines");
            DropIndex("dbo.Fields", new[] { "MenuItemDefine_Id" });
            DropTable("dbo.Fields");
        }
    }
}
