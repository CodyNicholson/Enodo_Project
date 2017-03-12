namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryToFixSurveyId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Surveys");
            AlterColumn("dbo.Surveys", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Surveys", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Surveys");
            AlterColumn("dbo.Surveys", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Surveys", "Id");
        }
    }
}
