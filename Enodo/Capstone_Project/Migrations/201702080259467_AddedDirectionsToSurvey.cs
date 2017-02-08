namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDirectionsToSurvey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Surveys", "Directions", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Surveys", "Directions");
        }
    }
}
