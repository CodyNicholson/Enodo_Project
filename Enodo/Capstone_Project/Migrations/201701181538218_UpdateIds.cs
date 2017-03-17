namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Survey_Id", "dbo.Surveys");
            DropIndex("dbo.AspNetUsers", new[] { "Survey_Id" });
            DropColumn("dbo.AspNetUsers", "SurveyId");
            RenameColumn(table: "dbo.AspNetUsers", name: "Survey_Id", newName: "SurveyId");
            DropPrimaryKey("dbo.Surveys");
            AlterColumn("dbo.AspNetUsers", "SurveyId", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "SurveyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Surveys", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Surveys", "Id");
            CreateIndex("dbo.AspNetUsers", "SurveyId");
            AddForeignKey("dbo.AspNetUsers", "SurveyId", "dbo.Surveys", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "SurveyId", "dbo.Surveys");
            DropIndex("dbo.AspNetUsers", new[] { "SurveyId" });
            DropPrimaryKey("dbo.Surveys");
            AlterColumn("dbo.Surveys", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.AspNetUsers", "SurveyId", c => c.Byte());
            AlterColumn("dbo.AspNetUsers", "SurveyId", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Surveys", "Id");
            RenameColumn(table: "dbo.AspNetUsers", name: "SurveyId", newName: "Survey_Id");
            AddColumn("dbo.AspNetUsers", "SurveyId", c => c.String(nullable: false));
            CreateIndex("dbo.AspNetUsers", "Survey_Id");
            AddForeignKey("dbo.AspNetUsers", "Survey_Id", "dbo.Surveys", "Id");
        }
    }
}
