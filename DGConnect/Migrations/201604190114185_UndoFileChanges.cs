namespace DGConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UndoFileChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Files", "Users_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Files", new[] { "Users_Id" });
            DropTable("dbo.Files");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        Users_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FileId);
            
            CreateIndex("dbo.Files", "Users_Id");
            AddForeignKey("dbo.Files", "Users_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
