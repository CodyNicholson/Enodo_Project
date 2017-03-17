namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddToUserListOfSurveyIds : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.AspNetUsers");
            AlterColumn("dbo.AspNetUsers", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.AspNetUsers");
            AlterColumn("dbo.AspNetUsers", "Id", c => c.Byte(nullable: false, identity: true));
            AddPrimaryKey("dbo.AspNetUsers", "Id");
        }
    }
}
