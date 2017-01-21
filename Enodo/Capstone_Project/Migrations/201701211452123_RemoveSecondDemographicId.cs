namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSecondDemographicId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "DemographicTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "DemographicTypeId", c => c.Byte(nullable: false));
        }
    }
}
