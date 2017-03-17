namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDemographicId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DemographicId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "DemographicId");
            AddForeignKey("dbo.AspNetUsers", "DemographicId", "dbo.Demographics", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "DemographicId", "dbo.Demographics");
            DropIndex("dbo.AspNetUsers", new[] { "DemographicId" });
            DropColumn("dbo.AspNetUsers", "DemographicId");
        }
    }
}
