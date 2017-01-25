namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSurveyOptions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SurveyOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Survey_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Surveys", t => t.Survey_Id)
                .Index(t => t.Survey_Id);
            
            AlterColumn("dbo.Surveys", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SurveyOptions", "Survey_Id", "dbo.Surveys");
            DropIndex("dbo.SurveyOptions", new[] { "Survey_Id" });
            AlterColumn("dbo.Surveys", "Name", c => c.String());
            DropTable("dbo.SurveyOptions");
        }
    }
}
