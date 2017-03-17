namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSecondDemographicId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "DemographicTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DemographicTypeId", c => c.Byte(nullable: false));
        }
    }
}
