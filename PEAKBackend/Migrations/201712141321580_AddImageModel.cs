namespace PEAKBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContentType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Modules", "ImageId", c => c.Int());
            CreateIndex("dbo.Modules", "ImageId");
            AddForeignKey("dbo.Modules", "ImageId", "dbo.Images", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modules", "ImageId", "dbo.Images");
            DropIndex("dbo.Modules", new[] { "ImageId" });
            DropColumn("dbo.Modules", "ImageId");
            DropTable("dbo.Images");
        }
    }
}
