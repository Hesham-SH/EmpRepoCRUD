using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace Day8.Models
{
    public class CompanyDBContext : DbContext
    {
        public CompanyDBContext()
        {

        }
        public CompanyDBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =.;Initial Catalog = Repo;Integrated Security=True;TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentLocation>().HasKey(k => new { k.DeptNumber, k.Location });
            modelBuilder.Entity<WorksOnProject>().HasKey(k => new { k.EmpSSN, k.projNum });
            modelBuilder.Entity<Dependant>().HasKey(k => new { k.Name, k.EmpSSN });

            modelBuilder.Entity<Employee>().HasOne(s => s.Supervisor).WithMany(e => e.Employees);
            modelBuilder.Entity<Employee>().HasOne(k => k.department).WithMany(k => k.Employees);
            modelBuilder.Entity<Employee>().HasOne(k => k.Deptmanage).WithOne(k => k.EmployeeManage);
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<DepartmentLocation> DepartmentLocation { get; set; }
        public DbSet<WorksOnProject> WorksOnProjects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Dependant> Dependants { get; set; }

    }
}
