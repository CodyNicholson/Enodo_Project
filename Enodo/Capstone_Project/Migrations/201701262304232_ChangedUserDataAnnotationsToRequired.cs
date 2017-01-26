namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUserDataAnnotationsToRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Birthdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Birthdate", c => c.DateTime());
        }
    }
}
