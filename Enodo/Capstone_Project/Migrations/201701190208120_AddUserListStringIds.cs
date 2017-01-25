namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserListStringIds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "SurveyId", "dbo.Surveys");
            DropIndex("dbo.Users", new[] { "SurveyId" });
            DropColumn("dbo.Users", "SurveyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "SurveyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "SurveyId");
            AddForeignKey("dbo.Users", "SurveyId", "dbo.Surveys", "Id", cascadeDelete: true);
        }
    }
}
