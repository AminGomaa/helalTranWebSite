namespace Helalzahbi_Trans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ApplyForJobs", "ApplyDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ApplyForJobs", "ApplyDate", c => c.String());
        }
    }
}
