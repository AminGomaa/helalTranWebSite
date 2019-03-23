namespace Helalzahbi_Trans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editcatogry : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "catDesc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "catDesc", c => c.String(nullable: false));
        }
    }
}
