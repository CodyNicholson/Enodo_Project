namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToSurvey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Surveys", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Surveys", "Name");
        }
    }
}
