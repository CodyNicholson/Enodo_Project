namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOptionOrderStringToSurveyResults : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurveyResults", "OptionOrder", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SurveyResults", "OptionOrder");
        }
    }
}
