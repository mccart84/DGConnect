namespace DGConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Courses", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "State", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "Country", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Country", c => c.String());
            AlterColumn("dbo.Courses", "State", c => c.String());
            AlterColumn("dbo.Courses", "City", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String());
        }
    }
}
