namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSurveyOptionSurveyId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SurveyOptions", new[] { "Survey_Id1" });
            DropColumn("dbo.SurveyOptions", "Survey_Id");
            RenameColumn(table: "dbo.SurveyOptions", name: "Survey_Id1", newName: "Survey_Id");
            AlterColumn("dbo.SurveyOptions", "Survey_Id", c => c.Int());
            CreateIndex("dbo.SurveyOptions", "Survey_Id");
            DropColumn("dbo.SurveyOptions", "OptionNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SurveyOptions", "OptionNumber", c => c.Int(nullable: false));
            DropIndex("dbo.SurveyOptions", new[] { "Survey_Id" });
            AlterColumn("dbo.SurveyOptions", "Survey_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.SurveyOptions", name: "Survey_Id", newName: "Survey_Id1");
            AddColumn("dbo.SurveyOptions", "Survey_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.SurveyOptions", "Survey_Id1");
        }
    }
}
