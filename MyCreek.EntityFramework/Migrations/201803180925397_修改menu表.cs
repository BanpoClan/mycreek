namespace MyCreek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class 修改menu表 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuItemDefines", "IndexPageTemplate", c => c.String());
            AddColumn("dbo.MenuItemDefines", "CreatePageTemplate", c => c.String());
            AddColumn("dbo.MenuItemDefines", "UpdatePageTemplate", c => c.String());
            AddColumn("dbo.MenuItemDefines", "GeneralPageTemplate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MenuItemDefines", "GeneralPageTemplate");
            DropColumn("dbo.MenuItemDefines", "UpdatePageTemplate");
            DropColumn("dbo.MenuItemDefines", "CreatePageTemplate");
            DropColumn("dbo.MenuItemDefines", "IndexPageTemplate");
        }
    }
}
