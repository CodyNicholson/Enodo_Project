namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDemographicId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "DemographicId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "DemographicId");
            AddForeignKey("dbo.Users", "DemographicId", "dbo.Demographics", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "DemographicId", "dbo.Demographics");
            DropIndex("dbo.Users", new[] { "DemographicId" });
            DropColumn("dbo.Users", "DemographicId");
        }
    }
}
