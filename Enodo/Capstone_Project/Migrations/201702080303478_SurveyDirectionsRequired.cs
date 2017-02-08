namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SurveyDirectionsRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Surveys", "Directions", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Surveys", "Directions", c => c.String());
        }
    }
}
