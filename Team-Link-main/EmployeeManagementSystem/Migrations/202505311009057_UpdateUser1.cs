namespace EmployeeManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Confirm_Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Confirm_Password", c => c.String(nullable: false));
        }
    }
}
