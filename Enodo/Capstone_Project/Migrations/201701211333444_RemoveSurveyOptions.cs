namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSurveyOptions : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SurveyOptions", "Survey_Id", "dbo.Surveys");
            DropIndex("dbo.SurveyOptions", new[] { "Survey_Id" });
            DropTable("dbo.SurveyOptions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SurveyOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Survey_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.SurveyOptions", "Survey_Id");
            AddForeignKey("dbo.SurveyOptions", "Survey_Id", "dbo.Surveys", "Id");
        }
    }
}
