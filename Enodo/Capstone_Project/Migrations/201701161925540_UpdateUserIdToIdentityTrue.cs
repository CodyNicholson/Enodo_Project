namespace Capstone_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserIdToIdentityTrue : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Id", c => c.Byte(nullable: false, identity: true));
        }

        public override void Down()
        {
            AlterColumn("dbo.Users", "Id", c => c.String());
        }
    }
}
