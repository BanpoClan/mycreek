namespace MyCreek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class 添加菜单状态对象 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuGuid = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MenuStatus");
        }
    }
}
