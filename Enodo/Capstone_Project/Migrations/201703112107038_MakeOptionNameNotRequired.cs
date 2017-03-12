namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeOptionNameNotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Options", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Options", "Name", c => c.String(nullable: false));
        }
    }
}
