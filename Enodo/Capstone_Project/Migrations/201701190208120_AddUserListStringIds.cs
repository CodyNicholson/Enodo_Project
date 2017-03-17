namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserListStringIds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "SurveyId", "dbo.Surveys");
            DropIndex("dbo.AspNetUsers", new[] { "SurveyId" });
            DropColumn("dbo.AspNetUsers", "SurveyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "SurveyId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "SurveyId");
            AddForeignKey("dbo.AspNetUsers", "SurveyId", "dbo.Surveys", "Id", cascadeDelete: true);
        }
    }
}
