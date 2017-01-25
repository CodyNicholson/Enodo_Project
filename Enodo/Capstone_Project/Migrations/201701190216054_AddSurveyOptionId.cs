namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSurveyOptionId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurveyOptions", "OptionNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SurveyOptions", "OptionNumber");
        }
    }
}
