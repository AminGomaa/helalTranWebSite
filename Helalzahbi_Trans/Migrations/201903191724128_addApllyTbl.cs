namespace Helalzahbi_Trans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addApllyTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplyForJobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        ApplyDate = c.String(),
                        JobId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.JobId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplyForJobs", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplyForJobs", "JobId", "dbo.Jobs");
            DropIndex("dbo.ApplyForJobs", new[] { "UserId" });
            DropIndex("dbo.ApplyForJobs", new[] { "JobId" });
            DropTable("dbo.ApplyForJobs");
        }
    }
}
