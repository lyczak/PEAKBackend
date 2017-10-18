namespace PEAKBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocationsModulesHintsAndHintCatagories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HintCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModuleId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HintCategories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Modules", t => t.ModuleId, cascadeDelete: true)
                .Index(t => t.ModuleId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ModuleId = c.Int(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Radius = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Modules", t => t.ModuleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ModuleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Locations", "ModuleId", "dbo.Modules");
            DropForeignKey("dbo.Hints", "ModuleId", "dbo.Modules");
            DropForeignKey("dbo.Hints", "CategoryId", "dbo.HintCategories");
            DropIndex("dbo.Locations", new[] { "ModuleId" });
            DropIndex("dbo.Locations", new[] { "UserId" });
            DropIndex("dbo.Hints", new[] { "CategoryId" });
            DropIndex("dbo.Hints", new[] { "ModuleId" });
            DropTable("dbo.Locations");
            DropTable("dbo.Modules");
            DropTable("dbo.Hints");
            DropTable("dbo.HintCategories");
        }
    }
}
