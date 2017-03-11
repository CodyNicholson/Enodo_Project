namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContryToUserModelRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Country", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Country", c => c.String());
        }
    }
}
