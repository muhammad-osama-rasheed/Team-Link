namespace EmployeeManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class updateEmployee : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Employees"); 
            DropColumn("dbo.Employees", "EmployeeId"); 
            AddColumn("dbo.Employees", "Id", c => c.Int(nullable: false, identity: true));  
            AddPrimaryKey("dbo.Employees", "Id"); 
        }

        public override void Down()
        {
            DropPrimaryKey("dbo.Employees");  
            DropColumn("dbo.Employees", "Id"); 
            AddColumn("dbo.Employees", "EmployeeId", c => c.Int(nullable: false, identity: true));  
            AddPrimaryKey("dbo.Employees", "EmployeeId");  
        }
    }
}
