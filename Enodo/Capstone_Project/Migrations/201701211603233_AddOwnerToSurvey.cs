namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOwnerToSurvey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Surveys", "Owner", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Surveys", "Owner");
        }
    }
}
