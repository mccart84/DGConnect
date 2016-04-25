namespace DGConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tournaments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        TournamentDate = c.DateTime(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tournaments", "CourseID", "dbo.Courses");
            DropIndex("dbo.Tournaments", new[] { "CourseID" });
            DropTable("dbo.Tournaments");
        }
    }
}
