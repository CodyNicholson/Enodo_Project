namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDemographicId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DemographicId", c => c.Byte(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false));
            DropColumn("dbo.AspNetUsers", "DemographicId");
        }
    }
}
