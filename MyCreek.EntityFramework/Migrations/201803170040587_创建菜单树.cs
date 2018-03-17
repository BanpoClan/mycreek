namespace MyCreek.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class 创建菜单树 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuItemDefines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuGuid = c.String(),
                        ParentMenuGuid = c.String(),
                        Name = c.String(),
                        DisplayName = c.String(),
                        Url = c.String(),
                        Icon = c.String(),
                        Order = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_MenuItemDefine_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MenuItemDefines",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_MenuItemDefine_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
