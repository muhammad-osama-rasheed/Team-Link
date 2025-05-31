namespace EmployeeManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeApplication : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeApplications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        EmployeeId = c.String(),
                        Subject = c.String(maxLength: 200),
                        Message = c.String(nullable: false, maxLength: 200),
                        Reply = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeeApplications");
        }
    }
}
