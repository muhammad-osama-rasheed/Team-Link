using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeManagementSystem.Models
{
    public class ApplicationDbContexts : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeApplication> EmployeeApplications { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}