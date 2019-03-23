namespace Helalzahbi_Trans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addjobtbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        jobtitl = c.String(nullable: false),
                        jobcontent = c.String(nullable: false),
                        jobimage = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Jobs", new[] { "CategoryId" });
            DropTable("dbo.Jobs");
        }
    }
}
