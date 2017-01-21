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
            
            AddColumn("dbo.Users", "Demographic_Id", c => c.Int());
            CreateIndex("dbo.Users", "Demographic_Id");
            AddForeignKey("dbo.Users", "Demographic_Id", "dbo.Demographics", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Demographic_Id", "dbo.Demographics");
            DropIndex("dbo.Users", new[] { "Demographic_Id" });
            DropColumn("dbo.Users", "Demographic_Id");
            DropTable("dbo.Demographics");
        }
    }
}
