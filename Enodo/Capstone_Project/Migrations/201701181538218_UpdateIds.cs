namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Survey_Id", "dbo.Surveys");
            DropIndex("dbo.Users", new[] { "Survey_Id" });
            DropColumn("dbo.Users", "SurveyId");
            RenameColumn(table: "dbo.Users", name: "Survey_Id", newName: "SurveyId");
            DropPrimaryKey("dbo.Surveys");
            AlterColumn("dbo.Users", "SurveyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "SurveyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Surveys", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Surveys", "Id");
            CreateIndex("dbo.Users", "SurveyId");
            AddForeignKey("dbo.Users", "SurveyId", "dbo.Surveys", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "SurveyId", "dbo.Surveys");
            DropIndex("dbo.Users", new[] { "SurveyId" });
            DropPrimaryKey("dbo.Surveys");
            AlterColumn("dbo.Surveys", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Users", "SurveyId", c => c.Byte());
            AlterColumn("dbo.Users", "SurveyId", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Surveys", "Id");
            RenameColumn(table: "dbo.Users", name: "SurveyId", newName: "Survey_Id");
            AddColumn("dbo.Users", "SurveyId", c => c.String(nullable: false));
            CreateIndex("dbo.Users", "Survey_Id");
            AddForeignKey("dbo.Users", "Survey_Id", "dbo.Surveys", "Id");
        }
    }
}
