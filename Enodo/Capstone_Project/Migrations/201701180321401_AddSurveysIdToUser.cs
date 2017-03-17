namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSurveysIdToUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "SurveyId", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Survey_Id", c => c.Byte());
            CreateIndex("dbo.AspNetUsers", "Survey_Id");
            AddForeignKey("dbo.AspNetUsers", "Survey_Id", "dbo.Surveys", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Survey_Id", "dbo.Surveys");
            DropIndex("dbo.AspNetUsers", new[] { "Survey_Id" });
            DropColumn("dbo.AspNetUsers", "Survey_Id");
            DropColumn("dbo.AspNetUsers", "SurveyId");
            DropTable("dbo.Surveys");
        }
    }
}
