namespace DGConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditUserModelChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EditUserViewModels", "PDGA", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EditUserViewModels", "PDGA");
        }
    }
}
