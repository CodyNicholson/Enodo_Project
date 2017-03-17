namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDemographic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Demographics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Demographic_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Demographic_Id");
            AddForeignKey("dbo.AspNetUsers", "Demographic_Id", "dbo.Demographics", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Demographic_Id", "dbo.Demographics");
            DropIndex("dbo.AspNetUsers", new[] { "Demographic_Id" });
            DropColumn("dbo.AspNetUsers", "Demographic_Id");
            DropTable("dbo.Demographics");
        }
    }
}
