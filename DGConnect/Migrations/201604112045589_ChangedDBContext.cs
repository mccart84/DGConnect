namespace DGConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDBContext : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.EditUserViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EditUserViewModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        PDGA = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
