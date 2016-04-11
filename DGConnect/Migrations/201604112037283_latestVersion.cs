namespace DGConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class latestVersion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EditUserViewModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EditUserViewModels");
        }
    }
}
