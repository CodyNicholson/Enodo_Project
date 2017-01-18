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
            
            AddColumn("dbo.Users", "SurveyId", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Survey_Id", c => c.Byte());
            CreateIndex("dbo.Users", "Survey_Id");
            AddForeignKey("dbo.Users", "Survey_Id", "dbo.Surveys", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Survey_Id", "dbo.Surveys");
            DropIndex("dbo.Users", new[] { "Survey_Id" });
            DropColumn("dbo.Users", "Survey_Id");
            DropColumn("dbo.Users", "SurveyId");
            DropTable("dbo.Surveys");
        }
    }
}
