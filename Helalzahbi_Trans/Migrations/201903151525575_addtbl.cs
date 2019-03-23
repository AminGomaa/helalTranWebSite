namespace Helalzahbi_Trans.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        categName = c.String(nullable: false),
                        catDesc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}
