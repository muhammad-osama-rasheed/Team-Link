namespace EmployeeManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateEmployee1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Role");
        }
    }
}
