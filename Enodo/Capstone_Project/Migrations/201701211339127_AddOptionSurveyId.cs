namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptionSurveyId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Options", "SurveyId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Options", "SurveyId");
        }
    }
}
