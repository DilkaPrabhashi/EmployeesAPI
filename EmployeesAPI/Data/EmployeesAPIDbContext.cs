using EmployeesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesAPI.Data
{
    public class EmployeesAPIDbContext: DbContext
    {
        public EmployeesAPIDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employees> EmployeesTb { get; set; }

    }
}
