namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDemographicId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "DemographicTypeId", c => c.Byte(nullable: false));
            DropColumn("dbo.Users", "DemographicId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "DemographicId", c => c.Byte(nullable: false));
            DropColumn("dbo.Users", "DemographicTypeId");
        }
    }
}
