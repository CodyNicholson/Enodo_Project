namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddToUserListOfSurveyIds : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "Id", c => c.Byte(nullable: false, identity: true));
            AddPrimaryKey("dbo.Users", "Id");
        }
    }
}
