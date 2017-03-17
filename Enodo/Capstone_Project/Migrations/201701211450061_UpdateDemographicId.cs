namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDemographicId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DemographicTypeId", c => c.Byte(nullable: false));
            DropColumn("dbo.AspNetUsers", "DemographicId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DemographicId", c => c.Byte(nullable: false));
            DropColumn("dbo.AspNetUsers", "DemographicTypeId");
        }
    }
}
